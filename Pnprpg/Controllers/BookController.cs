using Boot.Helpers;
using Boot.Models;
using Boot.Models.JsonModels;
using Rotativa;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace Boot.Controllers
{
    public class BookController : BaseController
    {
        public ActionResult Index()
        {
            var path = Server.MapPath($"~/App_Data/{FileNames.RuleBook}");
            if (!System.IO.File.Exists(path))
            {
                var pdf = new ViewAsPdf("Index")
                {
                    PageMargins = new Rotativa.Options.Margins(30, 10, 25, 10),
                    PageSize = Rotativa.Options.Size.A4,
                    PageOrientation = Rotativa.Options.Orientation.Portrait
                };
                SaveRotativa(pdf, path);
            }

            var file = new FileStream(path, FileMode.Open, FileAccess.Read);
            return File(file, "application/pdf");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBook()
        {
            var path = Server.MapPath($"~/App_Data/{FileNames.RuleBook}");
            System.IO.File.Delete(path);
            return RedirectToAction("Index");
        }

        public PartialViewResult Stats()
        {
            var list = GetJsonFromFile<List<Stat>>(FileNames.Stats);
            return PartialView("_Stats", list);
        }

        public PartialViewResult Races()
        {
            var list = GetJsonFromFile<List<Race>>(FileNames.Races);
            var stats = GetJsonFromFile<List<Stat>>(FileNames.Stats);
            foreach(var race in list)
                if (race.effects != null)
                    race.effects.ForEach(y => y.Stat = stats.Single(z => z.Id == y.statId));
            return PartialView("_Races", list);
        }

        public PartialViewResult Traits()
        {
            var list = GetJsonFromFile<List<Trait>>(FileNames.Traits);
            var stats = GetJsonFromFile<List<Stat>>(FileNames.Stats);
            foreach (var trait in list)
                foreach (var effect in trait.effects)
                    if (!string.IsNullOrEmpty(effect.statId))
                        effect.Stat = stats.Single(x => x.Id == effect.statId);
            return PartialView("_Traits", list);
        }

        public PartialViewResult Skills()
        {
            return PartialView("_Skills", GetSkillGroupList().Groups);
        }

        public PartialViewResult Spells()
        {
            return PartialView("_Spells", GetMagicSchoolGroups());
        }

        public PartialViewResult Perks()
        {
            return PartialView("_Perks", GetPerks());
        }

        public PartialViewResult Alchemy()
        {
            var reagents = GetJsonFromFile<List<SymbolInfo>>(FileNames.Reagents);
            var processes = GetJsonFromFile<List<SymbolInfo>>(FileNames.Processes);
            var potions = GetJsonFromFile<List<Potion>>(FileNames.Potions);
            var reacionts = GetJsonFromFile<List<Reaction>>(FileNames.Reactions);
            reacionts.ForEach(x => x.Potion = potions.Single(y => y.id == x.result));
            var model = new AlchemySummary
            {
                Reactions = reacionts,
                Reagents = reagents,
                Processes = processes
            };
            return PartialView("_Alchemy", model);
        }

        public PartialViewResult ShortSkillList()
        {
            var skills = GetSkillGroupList().Groups.SelectMany(x => x.skills).ToList();
            return PartialView("_ShortSkillList", skills);
        }

        public ActionResult HeroSheet()
        {
            var path = Server.MapPath($"~/App_Data/{FileNames.CharacterSheet}");
            var file = new FileStream(path, FileMode.Open, FileAccess.Read);
            return File(file, "application/pdf");
        }
    }
}