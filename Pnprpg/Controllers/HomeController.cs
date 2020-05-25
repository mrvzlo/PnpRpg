using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Boot.Enums;
using Boot.Models.JsonModels;
using WebGrease.Css.Extensions;

namespace Boot.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index() => View();

        public ActionResult Perks()
        {
            var perks = GetJsonFromFile<List<Perk>>(FileType.Perks);
            var races = GetJsonFromFile<List<Race>>(FileType.Races);
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
            var list = GetJsonFromFile<List<MagicSchoolGroup>>(FileType.MagicSchools);
            return View(list);
        }

        public ActionResult Weaponry()
        {
            var weapons = GetJsonFromFile<List<Weapon>>(FileType.Weapons);
            var skills = GetJsonFromFile<List<SkillGroup>>(FileType.Skills).SelectMany(x => x.skills);
            weapons.ForEach(weapon => weapon.Skill = skills.First(skill => skill.Id == weapon.SkillId));
            return View(weapons);
        }
    }
}