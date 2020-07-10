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
            return View(GetPerks());
        }

        public ActionResult EditPerk(int? id = null)
        {
            var perk = GetPerks().SingleOrDefault(x => x.id == id);
            var model = new PerkEditModel();

            if (perk != null)
            {
                model.Id = perk.id;
                model.Desc = perk.desc;
                model.Name = perk.name;
                model.Level = perk.requirements.Single(x => x.type == RequirementType.Level).value;
                model.Requirements = perk.requirements.Where(x => x.type != RequirementType.Level).ToList();
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
                perk = perks.Single(x => x.id == model.Id);

            if (perk == null)
                perk = new Perk { id = perks.Max(x => x.id) + 1 };
            else
                perks.Remove(perk);

            var reqs = model.Requirements ?? new List<Requirement>();
            reqs.Add(new Requirement { type = RequirementType.Level, value = model.Level });

            perk.name = model.Name;
            perk.desc = model.Desc;
            perk.requirements = reqs;

            perks.Add(perk);

            SaveJsonToFile(perks, FileNames.Perks);

            return RedirectToAction("Perks");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePerk(int perkId)
        {
            var perks = GetPerks();
            perks.Remove(perks.FirstOrDefault(x => x.id == perkId));
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
                    values = perks.Select(x => new SelectListItem { Value = x.id.ToString(), Text = x.name }).ToList();
                    selectList = new SelectList(values, "Value", "Text", value);
                    break;
                case RequirementType.Race:
                    var races = GetJsonFromFile<List<Race>>(FileNames.Races);
                    values = races.Select(x => new SelectListItem { Value = x.id.ToString(), Text = x.name }).ToList();
                    selectList = new SelectList(values, "Value", "Text", value);
                    break;
            }

            return new RequirementSelectModel
            {
                Pos = pos,
                Selected = new Requirement { statId = statId, type = (RequirementType)reqType, value = value },
                Requirements = new SelectList(reqSelectList, "Value", "Text", reqType),
                Values = selectList
            };
        }

        public ActionResult Weapons()
        {
            var weapons = GetJsonFromFile<List<Weapon>>(FileNames.Weapons);
            var skillList = GetJsonFromFile<List<SkillGroup>>(FileNames.Skills)
                .SelectMany(x => x.skills).ToList();
            weapons.ForEach(x => x.Skill = skillList.Single(y => y.Id == x.SkillId));
            return View(weapons.OrderBy(x => x.Level).ToList());
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
            var skillList = GetJsonFromFile<List<SkillGroup>>(FileNames.Skills).First().skills;
            var values = skillList.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = StringHelper.FormatToSentence(x.Name) }).ToList();
            ViewBag.SkillList = new SelectList(values, "Value", "Text", skillId);
        }
    }
}