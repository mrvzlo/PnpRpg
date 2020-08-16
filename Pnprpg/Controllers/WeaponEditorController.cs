using System.Linq;
using System.Web.Mvc;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;
using Pnprpg.Web.Helpers;

namespace Pnprpg.Web.Controllers
{
    [Authorize(Roles = "Admin,Editor")]
    public class WeaponEditorController : BaseController
    {
        private readonly IWeaponService _weaponService;
        private readonly ISkillService _skillService;

        public WeaponEditorController(IWeaponService weaponService, ISkillService skillService)
        {
            _weaponService = weaponService;
            _skillService = skillService;
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

        private void PrepareWeaponEditViewBags(int skillId)
        {
            var skills = _skillService.GetAllSkills(type: SkillType.Weapon).ToList();
            ViewBag.SkillList = new SelectList(skills, 
                nameof(SkillViewModel.Id), nameof(SkillViewModel.Name), skillId);
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