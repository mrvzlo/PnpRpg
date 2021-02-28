using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.WebCore.Pages.Editor.Creatures
{
    public class EditModel : EditorPage
    {
        [BindProperty]
        public CreatureEditModel Input { get; set; }

        private readonly ICreatureService _creatureService;
        private readonly ICoreLogic _coreLogic;

        public EditModel(ICreatureService creatureService, ICoreLogic coreLogic, IMajorService majorService) : base(majorService)
        {
            _creatureService = creatureService;
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
                var newId = _creatureService.Save(Input);
                if (Input.Id != newId)
                    return RedirectToPage(SitePages.EditorCreaturesEdit, new { id = newId });
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
