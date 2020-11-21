using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pnprpg.DomainService.IServices;

namespace Pnprpg.WebCore.Pages.Editor.Perks
{
    public class IndexModel : EditorPage
    {
        private readonly IPerkService _perkService;

        public IndexModel(IPerkService perkService)
        {
            _perkService = perkService;
        }

        public void OnGet() { }

        public PartialViewResult OnGetGrid()
        {
            var list = _perkService.GetAll().OrderBy(x => x.BranchId);
            return Partial(SitePages.EditorPerks_Grid, list);
        }

        public ActionResult OnPostDelete(int modelId)
        {
            _perkService.Delete(modelId);
            return RedirectToPage(SitePages.EditorPerksIndex);
        }
    }
}
