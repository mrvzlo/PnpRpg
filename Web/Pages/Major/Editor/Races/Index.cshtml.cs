using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;

namespace Pnprpg.WebCore.Pages.Major.Editor.Races
{
    public class IndexModel : EditorPage
    {
        private readonly IRaceService _raceService;

        public IndexModel(IRaceService raceService, IMajorService majorService) : base(majorService)
        {
            _raceService = raceService;
        }

        public void OnGet() { }

        public PartialViewResult OnGetGrid(MajorType major)
        {
            var list = _raceService.GetAll(major).OrderBy(x => x.Id);
            return Partial(SitePages.MajorEditorRaces_Grid, list);
        }

        public ActionResult OnPostDelete(int modelId)
        {
            _raceService.Delete(modelId);
            return CustomRedirect(SitePages.MajorEditorRacesIndex);
        }
    }
}
