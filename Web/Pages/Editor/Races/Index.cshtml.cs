using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pnprpg.DomainService.IServices;

namespace Pnprpg.WebCore.Pages.Editor.Races
{
    public class IndexModel : EditorPage
    {
        private readonly IRaceService _raceService;

        public IndexModel(IRaceService raceService)
        {
            _raceService = raceService;
        }

        public void OnGet() { }

        public PartialViewResult OnGetGrid()
        {
            var list = _raceService.GetAll().OrderBy(x => x.Id);
            return Partial(SitePages.EditorRaces_Grid, list);
        }

        public ActionResult OnPostDelete(int modelId)
        {
            _raceService.Delete(modelId);
            return RedirectToPage(SitePages.EditorRacesIndex);
        }
    }
}
