using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pnprpg.DomainService.IServices;

namespace Pnprpg.WebCore.Pages.Editor.Branches
{
    public class IndexModel : EditorPage
    {
        private readonly IBranchService _branchService;

        public IndexModel(IBranchService branchService, IMajorService majorService) : base(majorService)
        {
            _branchService = branchService;
        }

        public void OnGet() { }

        public PartialViewResult OnGetGrid()
        {
            var list = _branchService.GetAll().OrderBy(x => x.Id);
            return Partial(SitePages.EditorBranches_Grid, list);
        }

        public ActionResult OnPostDelete(int modelId)
        {
            _branchService.Delete(modelId);
            return RedirectToPage(SitePages.EditorBranchesIndex);
        }
    }
}
