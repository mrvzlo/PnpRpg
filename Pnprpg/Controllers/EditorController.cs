using Boot.Models;
using Boot.Enums;
using System.Linq;
using System.Web.Mvc;
using Boot.Helpers;
using System.Collections.Generic;
using Boot.Models.JsonModels;
using System.Xml.Linq;

namespace Boot.Controllers
{
    [Authorize(Roles = "Admin,Editor")]
    public class EditorController : BaseController
    {
        public ActionResult Perks()
        {
            return View();
        }

        public PartialViewResult PerksGrid()
        {
            return PartialView("_PerksGrid", GetPerks());
        }

        public ActionResult EditPerk(int? id = null)
        {
            var perk = GetPerks().SingleOrDefault(x => x.Id == id);
            var model = new PerkEditModel();

            if (perk != null)
            {
                model.Id = perk.Id;
                model.Desc = perk.Desc;
                model.Name = perk.Name;
                model.Level = perk.Requirements.Single(x => x.Type == RequirementType.Level).Value;
                model.Requirements = perk.Requirements.Where(x => x.Type != RequirementType.Level).ToList();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPerk(PerkEditModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var perks = GetPerks();
            Perk perk = null;
            if (model.Id != null)
                perk = perks.Single(x => x.Id == model.Id);

            if (perk == null)
                perk = new Perk { Id = perks.Max(x => x.Id) + 1 };
            else
                perks.Remove(perk);

            var reqs = model.Requirements ?? new List<Requirement>();
            reqs.Add(new Requirement { Type = RequirementType.Level, Value = model.Level });

            perk.Name = model.Name;
            perk.Desc = model.Desc;
            perk.Requirements = reqs;

            perks.Add(perk);

            SaveJsonToFile(perks, FileNames.Perks);

            return RedirectToAction("Perks");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePerk(int perkId)
        {
            var perks = GetPerks();
            perks.Remove(perks.FirstOrDefault(x => x.Id == perkId));
            SaveJsonToFile(perks, FileNames.Perks);
            return RedirectToAction("Perks");
        }

        public JsonResult ReqirementSelectModel(int pos, int id = (int)RequirementType.Stat)
        {
            var model = GetReqirementSelectModel(pos, 0, null, id);
            var partial = this.RenderPartialViewToString("_RequirementSelect", model);
            return ReturnJson(partial, null);
        }

        public PartialViewResult ShowReqirementSelectModel(int pos, int value, string statId, int reqType = (int)RequirementType.Stat)
        {
            var model = GetReqirementSelectModel(pos, value, statId, reqType);
            return PartialView("_RequirementSelect", model);
        }

        private RequirementSelectModel GetReqirementSelectModel(int pos, int value, string statId, int reqType)
        {
            var requirements = new[] { RequirementType.Stat, RequirementType.Race, RequirementType.Perk };
            var reqSelectList = requirements.Select(x => new { Value = (int)x, Text = x.Description() });
            SelectList selectList = null;
            List<SelectListItem> values;

            switch ((RequirementType)reqType)
            {
                case RequirementType.Stat:
                    var stats = GetJsonFromFile<List<Stat>>(FileNames.Stats);
                    values = stats.Select(x => new SelectListItem { Value = x.Id, Text = x.Name }).ToList();
                    selectList = new SelectList(values, "Value", "Text", statId);
                    break;
                case RequirementType.Perk:
                    var perks = GetJsonFromFile<List<Perk>>(FileNames.Perks);
                    values = perks.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList();
                    selectList = new SelectList(values, "Value", "Text", value);
                    break;
                case RequirementType.Race:
                    var races = GetJsonFromFile<List<Race>>(FileNames.Races);
                    values = races.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList();
                    selectList = new SelectList(values, "Value", "Text", value);
                    break;
            }

            return new RequirementSelectModel
            {
                Pos = pos,
                Selected = new Requirement { StatId = statId, Type = (RequirementType)reqType, Value = value },
                Requirements = new SelectList(reqSelectList, "Value", "Text", reqType),
                Values = selectList
            };
        }

        public ActionResult Weapons()
        {
            return View();
        }

        public PartialViewResult WeaponsGrid()
        {
            var weapons = GetJsonFromFile<List<Weapon>>(FileNames.Weapons);
            var skillList = GetJsonFromFile<List<SkillGroup>>(FileNames.Skills)
                .SelectMany(x => x.Skills).ToList();
            weapons.ForEach(x => x.Skill = skillList.Single(y => y.Id == x.SkillId));
            return PartialView("_WeaponsGrid", weapons);
        }

        public ActionResult EditWeapon(int? id = null)
        {
            var weapon = GetJsonFromFile<List<Weapon>>(FileNames.Weapons).SingleOrDefault(x => x.Id == id);
            var model = new WeaponEditModel();
            if (weapon != null)
            {
                model.Id = weapon.Id;
                model.Name = weapon.Name;
                model.Level = weapon.Level;
                model.Weight = weapon.Weight;
                model.SkillId = weapon.SkillId;
            }

            PrepareWeaponEditViewbags(model.SkillId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditWeapon(WeaponEditModel model)
        {
            if (!ModelState.IsValid)
            {
                PrepareWeaponEditViewbags(model.SkillId);
                return View(model);
            }

            var weapons = GetJsonFromFile<List<Weapon>>(FileNames.Weapons);
            Weapon weapon = null;
            if (model.Id != null)
                weapon = weapons.Single(x => x.Id == model.Id);

            if (weapon == null)
                weapon = new Weapon { Id = weapons.Max(x => x.Id) + 1 };
            else
                weapons.Remove(weapon);

            weapon.Name = model.Name;
            weapon.SkillId = model.SkillId;
            weapon.Weight = model.Weight;
            weapon.Level = model.Level;

            weapons.Add(weapon);

            SaveJsonToFile(weapons, FileNames.Weapons);

            return RedirectToAction("Weapons");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteWeapon(int weaponId)
        {
            var weapons = GetJsonFromFile<List<Weapon>>(FileNames.Weapons);
            weapons.Remove(weapons.FirstOrDefault(x => x.Id == weaponId));
            SaveJsonToFile(weapons, FileNames.Weapons);
            return RedirectToAction("Weapons");
        }

        private void PrepareWeaponEditViewbags(int skillId)
        {
            var skillList = GetJsonFromFile<List<SkillGroup>>(FileNames.Skills).First().Skills;
            var values = skillList.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = StringHelper.FormatToSentence(x.Name) }).ToList();
            ViewBag.SkillList = new SelectList(values, "Value", "Text", skillId);
        }
    }
}