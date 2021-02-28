using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.WebCore.Pages.Editor.Branches
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

        public void OnGet(int? id)
        {
            Prepare(id);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var newId = _branchService.Save(Input);
                if (Input.Id != newId)
                    return RedirectToPage(SitePages.EditorBranchesEdit, new { id = newId });
            }

            Prepare(Input.Id);
            return Page();
        }

        private void Prepare(int? id)
        {
            Input = _branchService.GetForEdit(id);
            var bonuses = _bonusService.GetAll((int)BonusType.Branch);
            Bonuses = _coreLogic.ToSelectableList(bonuses);
        }
    }
}
