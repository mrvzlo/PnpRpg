using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;

namespace Pnprpg.WebCore.Pages.Major.Editor.Branches
{
    public class IndexModel : EditorPage
    {
        private readonly IBranchService _branchService;

        public IndexModel(IBranchService branchService, IMajorService majorService) : base(majorService)
        {
            _branchService = branchService;
        }

        public void OnGet() { }

        public PartialViewResult OnGetGrid(MajorType major)
        {
            var list = _branchService.GetAll(major).OrderBy(x => x.Id);
            return Partial(SitePages.MajorEditorBranches_Grid, list);
        }

        public ActionResult OnPostDelete(int modelId)
        {
            _branchService.Delete(modelId);
            return CustomRedirect(SitePages.MajorEditorBranchesIndex);
        }
    }
}
