using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Boot.Enums;
using Boot.Helpers;
using Boot.Models;
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
            var stats = GetJsonFromFile<List<Stat>>(FileNames.Stats);
            ViewBag.MaxLevel = perks
                .Max(x => x.requirements.Single(y => y.type == RequirementType.Level)
                .value);

            perks.SelectMany(perk => perk.requirements)
                .Where(req => req.type == RequirementType.Race)
                    .ForEach(req => req.strValue = races.Single(x => x.id == req.value).name);

            perks.SelectMany(perk => perk.requirements)
                .Where(req => req.type == RequirementType.Stat)
                    .ForEach(req => req.strValue = stats.Single(x => x.Id == req.statId).Name);

            return View(perks);
        }

        public ActionResult Magic()
        {
            var list = GetJsonFromFile<List<MagicSchoolGroup>>(FileNames.MagicSchools);
            var stats = GetJsonFromFile<List<Stat>>(FileNames.Stats);
            var spells = GetJsonFromFile<List<Spell>>(FileNames.Spells);
            foreach (var ms in list)
            {
                ms.Stat = stats.Single(x => x.Id == ms.StatId);
                foreach (var s in ms.Schools)
                    s.Spells = spells.Where(x => x.School == s.Id).OrderBy(x => x.Level).ToList();
            }
            return View(list);
        }

        public ActionResult Weaponry()
        {
            var stats = GetJsonFromFile<List<Stat>>(FileNames.Stats);
            var weapons = GetJsonFromFile<List<Weapon>>(FileNames.Weapons);
            var skills = GetJsonFromFile<List<SkillGroup>>(FileNames.Skills).SelectMany(x => x.skills);
            foreach (var skill in skills)
                skill.Stat = stats.Single(x => x.Id == skill.StatId);
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