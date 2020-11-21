using Microsoft.AspNetCore.Mvc;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;
using Pnprpg.WebCore.Pages.Admin;

namespace Pnprpg.WebCore.Pages.Editor.News
{
    public class EditModel : AdminPage
    {
        [BindProperty]
        public NewsEditModel Input { get; set; }

        private readonly INewsService _newsService;

        public EditModel(INewsService newsService)
        {
            _newsService = newsService;
        }

        public void OnGet(int? id)
        {
            Prepare(id);
        }

        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var newId = _newsService.Save(Input);
                if (Input.Id != newId)
                    return RedirectToPage(SitePages.AdminNewsEdit, new { id = newId });
            }

            Prepare(Input.Id);
            return Page();
        }

        private void Prepare(int? id)
        {
            Input = _newsService.GetForEdit(id);
        }
    }
}
