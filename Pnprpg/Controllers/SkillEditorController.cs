using System.Linq;
using System.Web.Mvc;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.Helpers;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.Web.Controllers
{
    [Authorize(Roles = "Admin,Editor")]
    public class SkillEditorController : BaseController
    {
        private readonly ISkillService _skillService;
        private readonly IAbilityService _abilityService;

        public SkillEditorController(ISkillService skillService, IAbilityService abilityService)
        {
            _skillService = skillService;
            _abilityService = abilityService;
        }

        public ActionResult Skills()
        {
            return View();
        }

        public PartialViewResult SkillsGrid()
        {
            var list = _skillService.GetAllSkills();
            return PartialView("_SkillsGrid", list);
        }

        public ActionResult EditSkill(int? id = null)
        {
            var model = _skillService.GetForEdit(id);
            PrepareSkillEditViewBags(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSkill(SkillEditModel model)
        {
            if (!ModelState.IsValid)
            {
                PrepareSkillEditViewBags(model);
                return View(model);
            }

            _skillService.Save(model);

            return RedirectToAction("Skills");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSkill(int skillId)
        {
            _skillService.Delete(skillId);
            return RedirectToAction("Skills");
        }

        private void PrepareSkillEditViewBags(SkillEditModel model)
        {
            var branches = _skillService.GetAllBranches();
            var abilities = _abilityService.GetAll();
            var skillTypes = new[] { SkillType.None, SkillType.Weapon, SkillType.Magic }
                .Select(x => new Selectable((int)x, x.Description())).ToList();

            ViewBag.Types = SelectableListToSelectList(skillTypes, (int)model.Type);
            ViewBag.Branches = new SelectList(branches, nameof(BranchModel.Id), nameof(BranchModel.Name), model.BranchId);
            ViewBag.Abilities = new SelectList(abilities, nameof(AbilityModel.Id), nameof(AbilityModel.Name), model.AbilityId);
        }
    }
}