using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pnprpg.DomainService.IServices;

namespace Pnprpg.WebCore.Pages.Editor.Creatures
{
    public class IndexModel : EditorPage
    {
        private readonly ICreatureService _creatureService;

        public IndexModel(ICreatureService creatureService, IMajorService majorService) : base(majorService)
        {
            _creatureService = creatureService;
        }

        public void OnGet() { }

        public PartialViewResult OnGetGrid()
        {
            var list = _creatureService.GetAll().OrderBy(x => x.Id);
            return Partial(SitePages.Creatures_Grid, list);
        }

        public ActionResult OnPostDelete(int modelId)
        {
            _creatureService.Delete(modelId);
            return RedirectToPage(SitePages.EditorCreaturesIndex);
        }
    }
}
