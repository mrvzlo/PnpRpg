using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Pnprpg.Domain.Services;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.Helpers;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;
using Pnprpg.Web.Helpers;

namespace Pnprpg.Web.Controllers
{
    [Authorize(Roles = "Admin,Editor")]
    public class PerkEditorController : BaseController
    {
        private readonly IPerkService _perkService;
        private readonly IRequirementService _requirementService;

        public PerkEditorController(IPerkService perkService, IRequirementService requirementService)
        {
            _perkService = perkService;
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
            PreparePerkEditViewBags(perk.BranchId);
            return View(perk);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPerk(PerkEditModel model)
        {
            if (!ModelState.IsValid)
            {
                PreparePerkEditViewBags(model.BranchId);
                return View(model);
            }

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

        private void PreparePerkEditViewBags(int branchId)
        {
            var branches = _perkService.GetAllBranches().ToList();
            ViewBag.Branches = new SelectList(branches,
                nameof(BranchModel.Id), nameof(BranchModel.Name), branchId);
        }

        public JsonResult RequirementSelectModel(int position, int id = (int)RequirementType.Ability)
        {
            var model = GetRequirementSelectModel(position, 0, 0, id);
            var partial = this.RenderPartialViewToString("_RequirementSelect", model);
            return Json(new { partial }, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult ShowRequirementSelectModel(int pos, int value, int? abilityId, int reqType = (int)RequirementType.Ability)
        {
            var model = GetRequirementSelectModel(pos, value, abilityId, reqType);
            return PartialView("_RequirementSelect", model);
        }

        private RequirementSelectModel GetRequirementSelectModel(int pos, int value, int? abilityId, int reqType)
        {
            var requirements = new[] { RequirementType.Ability, RequirementType.Perk, RequirementType.Race }
                .Select(x => new Selectable((int)x, x.Description())).ToList();
            var model = RequirementCommonModel.New((RequirementType)reqType);
            var selectList = _requirementService.GetVariants(model);

            RequirementCommonModel selected = RequirementCommonModel.New((RequirementType)reqType);
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
    }
}