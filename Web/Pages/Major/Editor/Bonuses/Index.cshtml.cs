using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;

namespace Pnprpg.WebCore.Pages.Major.Editor.Bonuses
{
    public class IndexModel : EditorPage
    {
        private readonly IBonusService _bonusService;

        public IndexModel(IBonusService bonusService, IMajorService majorService) : base(majorService)
        {
            _bonusService = bonusService;
        }

        public void OnGet() { }

        public PartialViewResult OnGetGrid(MajorType major)
        {
            var list = _bonusService.GetAll(major).OrderBy(x => x.Id);
            return Partial(SitePages.MajorEditorBonuses_Grid, list);
        }

        public ActionResult OnPostDelete(int modelId)
        {
            _bonusService.Delete(modelId);
            return CustomRedirect(SitePages.MajorEditorBonusesIndex);
        }
    }
}
