using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.WebCore.Pages.Editor.Skills
{
    public class EditModel : EditorPage
    {
        [BindProperty]
        public SkillEditModel Input { get; set; }
        public List<Selectable> Types { get; set; }
        public List<Selectable> Branches { get; set; }
        public List<Selectable> Abilities { get; set; }

        private readonly IBranchService _branchService;
        private readonly IAbilityService _abilityService;
        private readonly ISkillService _skillService;
        private readonly ICoreLogic _coreLogic;

        public EditModel(IBranchService branchService, IAbilityService abilityService, ICoreLogic coreLogic, ISkillService skillService)
        {
            _branchService = branchService;
            _abilityService = abilityService;
            _coreLogic = coreLogic;
            _skillService = skillService;
        }

        public void OnGet(int? id)
        {
            Prepare(id);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var newId = _skillService.Save(Input);
                if (Input.Id != newId)
                    return RedirectToPage(SitePages.EditorRacesEdit, new { id = newId });
            }

            Prepare(Input.Id);
            return Page();
        }

        private void Prepare(int? id)
        {
            Input = _skillService.GetForEdit(id);
            var branches = _branchService.GetAll();
            var abilities = _abilityService.GetAll<AbilityModel>();
            var skillTypes = new Enum[] { SkillType.None, SkillType.Weapon, SkillType.Magic };

            Types = _coreLogic.ToSelectableList(skillTypes, Input.Type.ToString());
            Branches = _coreLogic.ToSelectableList(branches, Input.BranchId.ToString());
            Abilities = _coreLogic.ToSelectableList(abilities, Input.AbilityId.ToString());
        }

    }
}
