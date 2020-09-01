using System;
using System.Reflection;
using System.Web.Mvc;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.Web.Controllers
{
    [Authorize(Roles = "Admin,Editor")]
    public class EditorController : BaseController
    {
        private readonly IRaceService _raceService;
        private readonly ISkillService _skillService;
        private readonly IAbilityService _abilityService;
        private readonly IWeaponService _weaponService;
        private readonly IPerkService _perkService;
        private readonly IBranchService _branchService;
        private readonly IBonusService _bonusService;
        private readonly ICoreLogic _coreLogic;

        public EditorController(IRaceService raceService, IAbilityService abilityService, ISkillService skillService, IWeaponService weaponService, IPerkService perkService, IBranchService branchService, IBonusService bonusService, ICoreLogic coreLogic)
        {
            _raceService = raceService;
            _perkService = perkService;
            _skillService = skillService;
            _bonusService = bonusService;
            _coreLogic = coreLogic;
            _weaponService = weaponService;
            _branchService = branchService;
            _abilityService = abilityService;
        }

        public ActionResult Races() => View();
        public ActionResult RacesGrid() => Grid(_raceService, nameof(RacesGrid));
        public ActionResult EditRace(int? id = null)
        {
            var model = _raceService.GetForEdit(id);
            return Edit(model, PrepareRaceEditViewBags, nameof(EditRace));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult EditRace(RaceEditModel model) =>
            Edit(() => _raceService.Save(model), PrepareRaceEditViewBags, model, nameof(EditRace), nameof(Races));
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult DeleteRace(int modelId) => Delete(_raceService, modelId, nameof(Races));

        private void PrepareRaceEditViewBags()
        {
            var abilities = _abilityService.GetAll<AbilityModel>();
            var bonuses = _bonusService.Select(BonusType.Race);
            ViewBag.Abilities = _coreLogic.ToSelectableList(abilities);
            ViewBag.Bonuses = _coreLogic.ToSelectableList(bonuses);
        }


        public ActionResult Skills() => View();
        public ActionResult SkillsGrid() => Grid(_skillService, nameof(SkillsGrid));
        public ActionResult EditSkill(int? id = null)
        {
            var model = _skillService.GetForEdit(id);
            return Edit(model, () => PrepareSkillEditViewBags(model), nameof(EditSkill));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult EditSkill(SkillEditModel model) =>
            Edit(() => _skillService.Save(model), () => PrepareSkillEditViewBags(model), model, nameof(EditSkill), nameof(Skills));
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult DeleteSkill(int modelId) => Delete(_skillService, modelId, nameof(Skills));

        private void PrepareSkillEditViewBags(SkillEditModel model)
        {
            var branches = _branchService.GetAll();
            var abilities = _abilityService.GetAll<AbilityModel>();
            var skillTypes = new Enum[] {SkillType.None, SkillType.Weapon, SkillType.Magic};

            ViewBag.Types = _coreLogic.ToSelectableList(skillTypes, model.Type);
            ViewBag.Branches = _coreLogic.ToSelectableList(branches, model.BranchId);
            ViewBag.Abilities = _coreLogic.ToSelectableList(abilities, model.AbilityId);
        }


        public ActionResult Branches() => View();
        public ActionResult BranchesGrid() => Grid(_branchService, nameof(BranchesGrid));
        public ActionResult EditBranch(int id)
        {
            var model = _branchService.GetForEdit(id);
            return Edit(model, PrepareBranchEditViewBags, nameof(EditBranch));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult EditBranch(BranchEditModel model) =>
            Edit(() => _branchService.Save(model), PrepareBranchEditViewBags, model, nameof(EditBranch), nameof(Branches));

        private void PrepareBranchEditViewBags()
        {
            var bonuses = _bonusService.Select(BonusType.Branch);
            ViewBag.Bonuses = _coreLogic.ToSelectableList(bonuses);
        }

        public ActionResult Weapons() => View();
        public ActionResult WeaponsGrid() => Grid(_weaponService, nameof(WeaponsGrid));
        public ActionResult EditWeapon(int? id = null)
        {
            var model = _weaponService.GetForEdit(id);
            return Edit(model, () => PrepareWeaponEditViewBags(model), nameof(EditWeapon));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult EditWeapon(WeaponEditModel model) =>
            Edit(() => _weaponService.Save(model), () => PrepareWeaponEditViewBags(model), model, nameof(EditWeapon), nameof(Weapons));
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult DeleteWeapon(int modelId) => Delete(_weaponService, modelId, nameof(Weapons));

        private void PrepareWeaponEditViewBags(WeaponEditModel model)
        {
            var skills = _skillService.SelectSkills(type: SkillType.Weapon);
            var bonuses = _bonusService.Select(BonusType.Weapon);
            ViewBag.SkillList = _coreLogic.ToSelectableList(skills, model.SkillId);
            ViewBag.Bonuses = _coreLogic.ToSelectableList(bonuses);
        }


        public ActionResult Bonuses() => View();
        public ActionResult BonusesGrid() => Grid(_bonusService, nameof(BonusesGrid));
        public ActionResult EditBonus(int? id = null)
        {
            var model = _bonusService.GetForEdit(id);
            return Edit(model, () => PrepareBonusEditViewBags(model), nameof(EditBonus));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult EditBonus(BonusEditModel model) =>
            Edit(() => _bonusService.Save(model), () => PrepareBonusEditViewBags(model), model, nameof(EditBonus), nameof(Bonuses));
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult DeleteBonus(int modelId) => Delete(_weaponService, modelId, nameof(Bonuses));

        private void PrepareBonusEditViewBags(BonusEditModel model)
        {
            var types = new Enum[] {BonusType.Weapon, BonusType.Branch, BonusType.Race};
            ViewBag.Types = _coreLogic.ToSelectableList(types, model.Type);
        }


        public ActionResult Perks() => View();
        public ActionResult PerksGrid() => Grid(_perkService, nameof(PerksGrid));
        public ActionResult EditPerk(int? id = null)
        {
            var model = _perkService.GetForEdit(id);
            return Edit(model, () => PreparePerkEditViewBags(model), nameof(EditPerk));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult EditPerk(PerkEditModel model) =>
            Edit(() => _perkService.Save(model), () => PreparePerkEditViewBags(model), model, nameof(EditPerk), nameof(Perks));
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult DeletePerk(int modelId) => Delete(_perkService, modelId, nameof(Perks));

        private void PreparePerkEditViewBags(PerkEditModel model)
        {
            var branches = _branchService.GetAll();
            ViewBag.Branches = _coreLogic.ToSelectableList(branches, model.BranchId);
        }


        private PartialViewResult Grid(IViewService<IBaseViewModel> service, string gridName) =>
            PartialView($"Grids/_{gridName}", service.GetAll());

        private ActionResult Edit(IBaseEditModel model, Action prepare, string caller)
        {
            prepare?.Invoke();
            return View($"Edit/{caller}", model);
        }

        private ActionResult Edit(Action edit, Action prepare, IBaseEditModel model, string caller, string redirectOnSuccess)
        {
            if (!ModelState.IsValid)
            {
                prepare?.Invoke();
                return View($"Edit/{caller}", model);
            }

            edit();
            return RedirectToAction(redirectOnSuccess);
        }

        private ActionResult Delete(IEditService<IBaseEditModel> service, int id, string redirect)
        {
            service.Delete(id);
            return RedirectToAction(redirect);
        }
    }
}