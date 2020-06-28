using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Boot.Enums;
using Boot.Helpers;
using Boot.Models;
using Boot.Models.JsonModels;
using Rotativa;
using WebGrease.Css.Extensions;

namespace Boot.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index() => View();

        public ActionResult Perks()
        {
            return View(GetPerks());
        }

        public ActionResult Magic()
        {
            return View(GetMagicSchoolGroups());
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

        public FileResult CharacterSheet()
        {
            var path = Server.MapPath($"~/App_Data/{FileNames.CharacterSheet}");
            var file = new FileStream(path, FileMode.Open, FileAccess.Read);
            return File(file, "application/pdf");
        }
    }
}