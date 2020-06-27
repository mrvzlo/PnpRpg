using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Boot.Enums;
using Boot.Helpers;
using Boot.Models.JsonModels;
using WebGrease.Css.Extensions;

namespace Boot.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index() => View();

        public ActionResult Perks()
        {
            var perks = GetJsonFromFile<List<Perk>>(FileNames.Perks);
            var races = GetJsonFromFile<List<Race>>(FileNames.Races);
            ViewBag.MaxLevel = perks
                .Max(x => x.requirements.Single(y => y.type == RequirementType.Level)
                .value);

            perks.SelectMany(perk => perk.requirements)
                .Where(req => req.type == RequirementType.Race)
                    .ForEach(req => req.strValue = races.Single(x => x.id == req.value).name);
            return View(perks);
        }

        public ActionResult Magic()
        {
            var list = GetJsonFromFile<List<MagicSchoolGroup>>(FileNames.MagicSchools);
            var spells = GetJsonFromFile<List<Spell>>(FileNames.Spells);
            foreach (var ms in list)
                foreach (var s in ms.Schools)
                    s.Spells = spells.Where(x => x.School == s.Id).OrderBy(x => x.Level).ToList();
            return View(list);
        }

        public ActionResult Weaponry()
        {
            var weapons = GetJsonFromFile<List<Weapon>>(FileNames.Weapons);
            var skills = GetJsonFromFile<List<SkillGroup>>(FileNames.Skills).SelectMany(x => x.skills);
            weapons.ForEach(weapon => weapon.Skill = skills.First(skill => skill.Id == weapon.SkillId));
            return View(weapons);
        }

        public JsonResult RandomSpell()
        {
            var spells = GetJsonFromFile<List<Spell>>(FileNames.Spells);
            var r = new Random().Next(spells.Count);
            var potion = spells[r].Name;
            var partial = this.RenderPartialViewToString("_RandomSpell", potion);
            return Json(new { partial }, JsonRequestBehavior.AllowGet);
        }

        public FileResult CharacterList()
        {
            var path = Server.MapPath($"~/App_Data/{FileNames.CharacterSheet}");
            var file = new FileStream(path, FileMode.Open, FileAccess.Read);
            return File(file, "application/pdf");
        }
    }
}