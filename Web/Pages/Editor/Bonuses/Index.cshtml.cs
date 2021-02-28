using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pnprpg.DomainService.IServices;

namespace Pnprpg.WebCore.Pages.Editor.Bonuses
{
    public class IndexModel : EditorPage
    {
        private readonly IBonusService _bonusService;

        public IndexModel(IBonusService bonusService, IMajorService majorService) : base(majorService)
        {
            _bonusService = bonusService;
        }

        public void OnGet() { }

        public PartialViewResult OnGetGrid()
        {
            var list = _bonusService.GetAll().OrderBy(x => x.Id);
            return Partial(SitePages.EditorBonuses_Grid, list);
        }

        public ActionResult OnPostDelete(int modelId)
        {
            _bonusService.Delete(modelId);
            return RedirectToPage(SitePages.EditorBonusesIndex);
        }
    }
}
