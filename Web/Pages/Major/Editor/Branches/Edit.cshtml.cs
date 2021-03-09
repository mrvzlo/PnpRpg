using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.WebCore.Pages.Major.Editor.Branches
{
    public class EditModel : EditorPage
    {
        [BindProperty]
        public BranchEditModel Input { get; set; }
        public List<Selectable> Bonuses { get; set; }

        private readonly ICoreLogic _coreLogic;
        private readonly IBranchService _branchService;
        private readonly IBonusService _bonusService;

        public EditModel(IBonusService bonusService, ICoreLogic coreLogic, IBranchService branchService, IMajorService majorService) : base(majorService)
        {
            _bonusService = bonusService;
            _coreLogic = coreLogic;
            _branchService = branchService;
        }

        public void OnGet(MajorType major, int? id)
        {
            Prepare(major, id);
        }

        public IActionResult OnPost(MajorType major)
        {
            if (ModelState.IsValid)
            {
                Input.MajorId = major;
                var newId = _branchService.Save(Input);
                if (Input.Id != newId)
                    return CustomRedirect(SitePages.MajorEditorBranchesEdit, new { id = newId });
            }

            Prepare(major, Input.Id);
            return Page();
        }

        private void Prepare(MajorType major, int? id)
        {
            Input = _branchService.GetForEdit(id);
            var bonuses = _bonusService.GetAll(major, (int)BonusType.Branch);
            Bonuses = _coreLogic.ToSelectableList(bonuses);
        }
    }
}
