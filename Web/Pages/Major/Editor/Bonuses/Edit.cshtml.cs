using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;
using Pnprpg.WebCore.Helpers;

namespace Pnprpg.WebCore.Pages.Major.Editor.Bonuses
{
    public class EditModel : EditorPage
    {
        [BindProperty]
        public BonusEditModel Input { get; set; }
        public List<Selectable> TypeOptions { get; set; }

        private readonly IBonusService _bonusService;
        private readonly ICoreLogic _coreLogic;

        public EditModel(IBonusService bonusService, ICoreLogic coreLogic, IMajorService majorService) : base(majorService)
        {
            _bonusService = bonusService;
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
                var newId = _bonusService.Save(Input);
                if (Input.Id != newId)
                    return CustomRedirect(SitePages.MajorEditorBonusesEdit, new { id = newId });
            }

            Prepare(Input.Id);
            return Page();
        }

        private void Prepare(int? id)
        {
            Input = _bonusService.GetForEdit(id);
            var types = new Enum[] { BonusType.Weapon, BonusType.Branch, BonusType.Race };
            TypeOptions = _coreLogic.ToSelectableList(types);
        }
    }
}
