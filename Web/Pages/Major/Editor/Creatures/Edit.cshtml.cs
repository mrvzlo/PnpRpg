using Microsoft.AspNetCore.Mvc;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.WebCore.Pages.Major.Editor.Creatures
{
    public class EditModel : EditorPage
    {
        [BindProperty]
        public CreatureEditModel Input { get; set; }

        private readonly ICreatureService _creatureService;

        public EditModel(ICreatureService creatureService, IMajorService majorService) : base(majorService)
        {
            _creatureService = creatureService;
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
                var newId = _creatureService.Save(Input);
                if (Input.Id != newId)
                    return CustomRedirect(SitePages.MajorEditorCreaturesEdit, new { id = newId });
            }

            Prepare(Input.Id);
            return Page();
        }

        private void Prepare(int? id)
        {
            Input = _creatureService.GetForEdit(id);
        }
    }
}
