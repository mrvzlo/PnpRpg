using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.WebCore.Pages.Major.Editor.Spells
{
    public class EditModel : EditorPage
    {
        [BindProperty]
        public SpellEditModel Input { get; set; }
        public List<Selectable> Schools { get; set; }

        private readonly IMagicService _magicService;
        private readonly ICoreLogic _coreLogic;

        public EditModel(IMagicService magicService, ICoreLogic coreLogic, IMajorService majorService) : base(majorService)
        {
            _magicService = magicService;
            _coreLogic = coreLogic;
        }

        public void OnGet(int? id)
        {
            Prepare(id);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var newId = _magicService.Save(Input);
                if (Input.Id != newId)
                    return CustomRedirect(SitePages.MajorEditorSpellsEdit, new { id = newId });
            }

            Prepare(Input.Id);
            return Page();
        }

        private void Prepare(int? id)
        {
            Input = _magicService.GetForEdit(id);
            var schools = _magicService.GetAllSchools();
            Schools = _coreLogic.ToSelectableList(schools);
        }
    }
}
