using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;

namespace Pnprpg.WebCore.Pages.Major.Editor.Perks
{
    public class IndexModel : EditorPage
    {
        private readonly IPerkService _perkService;

        public IndexModel(IPerkService perkService, IMajorService majorService) : base(majorService)
        {
            _perkService = perkService;
        }

        public void OnGet() { }

        public PartialViewResult OnGetGrid(MajorType major)
        {
            var list = _perkService.GetAll(major).OrderBy(x => x.BranchId);
            return Partial(SitePages.MajorEditorPerks_Grid, list);
        }

        public ActionResult OnPostDelete(int modelId)
        {
            _perkService.Delete(modelId);
            return CustomRedirect(SitePages.MajorEditorPerksIndex);
        }
    }
}
