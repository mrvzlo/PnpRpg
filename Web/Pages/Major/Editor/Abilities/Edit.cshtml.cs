using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.WebCore.Pages.Major.Editor.Abilities
{
    public class EditModel : EditorPage
    {
        [BindProperty]
        public AbilityEditModel Input { get; set; }
        public List<Selectable> SymbolOptions { get; set; }

        private readonly IAbilityService _abilityService;
        private readonly ICoreLogic _coreLogic;

        public EditModel(IAbilityService abilityService, ICoreLogic coreLogic, IMajorService majorService) : base(majorService)
        {
            _abilityService = abilityService;
            _coreLogic = coreLogic;
        }

        public void OnGet(int? id)
        {
            Prepare(id);
        }

        public IActionResult OnPost(MajorType major)
        {
            if (ModelState.IsValid)
            {
                Input.MajorId = major;
                var newId = _abilityService.Save(Input);
                if (Input.Id != newId)
                    return CustomRedirect(SitePages.MajorEditorAbilitiesEdit, new { id = newId });
            }

            Prepare(Input.Id);
            return Page();
        }

        private void Prepare(int? id)
        {
            Input = _abilityService.GetForEdit(id);
            var types = Enum.GetValues(typeof(AbilityType)).Cast<Enum>();
            SymbolOptions = _coreLogic.ToSelectableList(types);
        }
    }
}
