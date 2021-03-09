using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.WebCore.Pages.Major.Editor.Perks
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

        public void OnGet(MajorType major, int? id)
        {
            Prepare(major, id);
        }

        public IActionResult OnPost(MajorType major)
        {
            if (ModelState.IsValid)
            {
                Input.MajorId = major;
                var newId = _perkService.Save(Input);
                if (Input.Id != newId)
                    return CustomRedirect(SitePages.MajorEditorPerksEdit, new { id = newId });
            }

            Prepare(major, Input.Id);
            return Page();
        }

        private void Prepare(MajorType major, int? id)
        {
            Input = _perkService.GetForEdit(id);
            var branches = _branchService.GetAll(major);
            Branches = _coreLogic.ToSelectableList(branches);
        }
    }
}
