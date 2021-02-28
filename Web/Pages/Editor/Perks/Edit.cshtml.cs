using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.WebCore.Pages.Editor.Perks
{
    public class EditModel : EditorPage
    {
        [BindProperty]
        public PerkEditModel Input { get; set; }
        public List<Selectable> Branches { get; set; }

        private readonly IPerkService _perkService;
        private readonly ICoreLogic _coreLogic;
        private readonly IBranchService _branchService;

        public EditModel(IPerkService perkService, ICoreLogic coreLogic, IBranchService branchService, IMajorService majorService) : base(majorService)
        {
            _perkService = perkService;
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
                var newId = _perkService.Save(Input);
                if (Input.Id != newId)
                    return RedirectToPage(SitePages.EditorPerksEdit, new { id = newId });
            }

            Prepare(Input.Id);
            return Page();
        }

        private void Prepare(int? id)
        {
            Input = _perkService.GetForEdit(id);
            var branches = _branchService.GetAll();
            Branches = _coreLogic.ToSelectableList(branches);
        }
    }
}
