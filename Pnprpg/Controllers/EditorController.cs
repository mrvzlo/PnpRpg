using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Pnprpg.Domain.Services;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.Helpers;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;
using Pnprpg.DomainService.Models.Common;
using Pnprpg.DomainService.Models.Perks;
using Pnprpg.DomainService.Models.Requirements;
using Pnprpg.DomainService.Models.Skills;
using Pnprpg.DomainService.Models.Weapon;
using Pnprpg.Web.Helpers;

namespace Pnprpg.Web.Controllers
{
    [Authorize(Roles = "Admin,Editor")]
    public class EditorController : BaseController
    {
        private readonly IPerkService _perkService;
        private readonly IWeaponService _weaponService;
        private readonly ISkillService _skillService;
        private readonly IRequirementService _requirementService;

        public EditorController(IPerkService perkService, IWeaponService weaponService, ISkillService skillService, 
            IRequirementService requirementService)
        {
            _perkService = perkService;
            _weaponService = weaponService;
            _skillService = skillService;
            _requirementService = requirementService;
        }

        public ActionResult Perks()
        {
            return View();
        }

        public PartialViewResult PerksGrid()
        {
            var list = _perkService.GetAll();
            return PartialView("_PerksGrid", list);
        }

        public ActionResult EditPerk(int? id = null)
        {
            var perk = _perkService.GetForEdit(id);
            return View(perk);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPerk(PerkEditModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _perkService.SavePerk(model);

            return RedirectToAction("Perks");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePerk(int perkId)
        {
            _perkService.DeletePerk(perkId);
            return RedirectToAction("Perks");
        }

        public JsonResult RequirementSelectModel(int position, int id = (int)RequirementType.Ability)
        {
            var model = GetRequirementSelectModel(position, 0, 0, id);
            var partial = this.RenderPartialViewToString("_RequirementSelect", model);
            return Json(new {partial}, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult ShowRequirementSelectModel(int pos, int value, int abilityId, int reqType = (int)RequirementType.Ability)
        {
            var model = GetRequirementSelectModel(pos, value, abilityId, reqType);
            return PartialView("_RequirementSelect", model);
        }

        public ActionResult Weapons()
        {
            return View();
        }

        public PartialViewResult WeaponsGrid()
        {
            var weapons = _weaponService.GetAll();
            return PartialView("_WeaponsGrid", weapons);
        }

        public ActionResult EditWeapon(int? id = null)
        {
            var model = _weaponService.GetForEdit(id);
            PrepareWeaponEditViewBags(model.SkillId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditWeapon(WeaponEditModel model)
        {
            if (!ModelState.IsValid)
            {
                PrepareWeaponEditViewBags(model.SkillId);
                return View(model);
            }

            _weaponService.SaveWeapon(model);

            return RedirectToAction("Weapons");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteWeapon(int weaponId)
        {
            _weaponService.DeleteWeapon(weaponId);
            return RedirectToAction("Weapons");
        }

        public JsonResult BonusSelectModel(int position, int bonusId = 1)
        {
            var model = GetBonusesSelectModel(position, bonusId);
            var partial = this.RenderPartialViewToString("_BonusSelect", model);
            return Json(new { partial }, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult ShowBonusSelectModel(int position, int bonusId = 1)
        {
            return PartialView("_BonusSelect", GetBonusesSelectModel(position, bonusId));
        }

        private void PrepareWeaponEditViewBags(int skillId)
        {
            var skills = _skillService.GetSkillsByGroup((int)SkillGroupKey.Weapon).ToList();
            ViewBag.SkillList = new SelectList(skills, nameof(SkillModel.Id), nameof(SkillModel.Name), skillId);
        }

        private RequirementSelectModel GetRequirementSelectModel(int pos, int value, int abilityId, int reqType)
        {
            var requirements = new []{RequirementType.Ability, RequirementType.Perk, RequirementType.Race}
                .Select(x=> new Selectable((int)x, x.Description())).ToList();
            var model = RequirementCommonModel.New((RequirementType) reqType);
            var selectList = _requirementService.GetVariants(model);

            RequirementCommonModel selected = RequirementCommonModel.New((RequirementType) reqType);
            selected.AbilityId = abilityId;
            selected.Value = value;
            return new RequirementSelectModel
            {
                Position = pos,
                Selected = selected,
                Requirements = SelectableListToSelectList(requirements, reqType),
                Values = SelectableListToSelectList(selectList)
            };
        }

        private SelectList SelectableListToSelectList(List<Selectable> list, int? selected = null) => 
            new SelectList(list, nameof(Selectable.Value), nameof(Selectable.Text), selected);

        private SelectListPosition GetBonusesSelectModel(int position, int bonusId = 1)
        {
            var bonuses = _weaponService.GetAllBonuses();
            return new SelectListPosition
            {
                Values = new SelectList(bonuses, nameof(BonusModel.Id), nameof(BonusModel.Name), bonusId),
                Position = position
            };
        }
    }
}