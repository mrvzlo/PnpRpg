using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using Antlr.Runtime.Misc;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.Helpers;
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

        public EditorController(IRaceService raceService, IAbilityService abilityService, ISkillService skillService, IWeaponService weaponService, IPerkService perkService, IBranchService branchService, IBonusService bonusService)
        {
            _raceService = raceService;
            _perkService = perkService;
            _skillService = skillService;
            _bonusService = bonusService;
            _weaponService = weaponService;
            _branchService = branchService;
            _abilityService = abilityService;
        }

        public ActionResult Races() => View();
        public ActionResult RacesGrid() => Grid(_raceService);
        public ActionResult EditRace(int? id = null)
        {
            var model = _raceService.GetForEdit(id);
            return Edit(model, PrepareRaceEditViewBags);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult EditRace(RaceEditModel model) =>
            Edit(() => _raceService.Save(model), PrepareRaceEditViewBags, model, RedirectToAction("Races"));
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult DeleteRace(int raceId) => Delete(_raceService, raceId);

        private void PrepareRaceEditViewBags()
        {
            var abilities = _abilityService.GetAll<Selectable>().ToList();
            ViewBag.Abilities = SelectableListToSelectList(abilities);
        }


        public ActionResult Skills() => View();
        public ActionResult SkillsGrid() => Grid(_skillService);
        public ActionResult EditSkill(int? id = null)
        {
            var model = _skillService.GetForEdit(id);
            return Edit(model, () => PrepareSkillEditViewBags(model));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult EditSkill(SkillEditModel model) =>
            Edit(() => _skillService.Save(model), () => PrepareSkillEditViewBags(model), model, RedirectToAction("Skills"));
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult DeleteSkill(int skillId) => Delete(_skillService, skillId);

        private void PrepareSkillEditViewBags(SkillEditModel model)
        {
            var branches = _branchService.GetAll();
            var abilities = _abilityService.GetAll<Selectable>();
            var skillTypes = new[] { SkillType.None, SkillType.Weapon, SkillType.Magic }
                .Select(x => new Selectable((int)x, x.Description())).ToList();

            ViewBag.Types = SelectableListToSelectList(skillTypes, (int)model.Type);
            ViewBag.Branches = new SelectList(branches, nameof(BranchViewModel.Id), nameof(BranchViewModel.Name), model.BranchId);
            ViewBag.Abilities = SelectableListToSelectList(abilities.ToList(), model.AbilityId);
        }

        public ActionResult Branches() => View();
        public ActionResult BranchesGrid() => Grid(_branchService);
        public ActionResult EditBranch(int id)
        {
            var model = _branchService.GetForEdit(id);
            return Edit(model, null);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult EditBranch(BranchEditModel model) =>
            Edit(() => _branchService.Save(model), null, model, RedirectToAction("Branches"));


        public ActionResult Weapons() => View();
        public ActionResult WeaponsGrid() => Grid(_weaponService);
        public ActionResult EditWeapon(int? id = null)
        {
            var model = _weaponService.GetForEdit(id);
            return Edit(model, () => PrepareWeaponEditViewBags(model));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult EditWeapon(WeaponEditModel model) =>
            Edit(() => _weaponService.Save(model), () => PrepareWeaponEditViewBags(model), model, RedirectToAction("Weapons"));
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult DeleteWeapon(int weaponId) => Delete(_weaponService, weaponId);

        private void PrepareWeaponEditViewBags(WeaponEditModel model)
        {
            var skills = _skillService.SelectSkills(type: SkillType.Weapon).ToList();
            var bonuses = _bonusService.Select(BonusType.Weapon).ToList();
            ViewBag.SkillList = new SelectList(skills, nameof(SkillViewModel.Id), nameof(SkillViewModel.Name), model.SkillId);
            ViewBag.Bonuses = new SelectList(bonuses, nameof(BonusViewModel.Id), nameof(BonusViewModel.Name));
        }


        public ActionResult Bonuses() => View();
        public ActionResult BonusesGrid() => Grid(_bonusService);
        public ActionResult EditBonus(int? id = null)
        {
            var model = _bonusService.GetForEdit(id);
            return Edit(model, () => PrepareBonusEditViewBags(model));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult EditBonus(BonusEditModel model) =>
            Edit(() => _bonusService.Save(model), () => PrepareBonusEditViewBags(model), model, RedirectToAction("Bonuses"));
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult DeleteBonus(int weaponId) => Delete(_weaponService, weaponId);

        private void PrepareBonusEditViewBags(BonusEditModel model)
        {
            var types = new[] { BonusType.Weapon, BonusType.Branch, BonusType.Race }
                .Select(x => new Selectable((int)x, x.Description())).ToList();

            ViewBag.Types = SelectableListToSelectList(types, (int)model.Type);
        }


        public ActionResult Perks() => View();
        public ActionResult PerksGrid() => Grid(_perkService);
        public ActionResult EditPerk(int? id = null)
        {
            var model = _perkService.GetForEdit(id);
            return Edit(model, () => PreparePerkEditViewBags(model));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult EditPerk(PerkEditModel model) =>
            Edit(() => _perkService.Save(model), () => PreparePerkEditViewBags(model), model, RedirectToAction("Perks"));
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult DeletePerk(int perkId) => Delete(_perkService, perkId);

        private void PreparePerkEditViewBags(PerkEditModel model)
        {
            var branches = _branchService.GetAll();
            ViewBag.Branches = new SelectList(branches, nameof(BranchViewModel.Id), nameof(BranchViewModel.Name), model.BranchId);
        }


        private PartialViewResult Grid(IViewService<IBaseViewModel> service) =>
            PartialView($"Grids/_{Caller()}", service.GetAll());

        private ActionResult Edit(IBaseEditModel model, Action prepare)
        {
            prepare?.Invoke();
            return View($"Edit/{Caller()}", model);
        }

        private ActionResult Edit(Action edit, Action prepare, IBaseEditModel model, RedirectToRouteResult redirectOnSuccess)
        {
            if (!ModelState.IsValid)
            {
                prepare?.Invoke();
                return View($"Edit/{Caller()}", model);
            }

            edit();
            return redirectOnSuccess;
        }

        private ActionResult Delete(IEditService<IBaseEditModel> service, int id)
        {
            service.Delete(id);
            return RedirectToAction(Caller());
        }

        private string Caller() => new StackTrace().GetFrame(2).GetMethod().Name;
    }
}