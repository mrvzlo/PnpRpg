using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pnprpg.DomainService.IServices;

namespace Pnprpg.WebCore.Pages.Editor.Skills
{
    public class IndexModel : EditorPage
    {
        private readonly ISkillService _skillService;

        public IndexModel(ISkillService skillService, IMajorService majorService) : base(majorService)
        {
            _skillService = skillService;
        }

        public void OnGet() { }

        public PartialViewResult OnGetGrid()
        {
            var list = _skillService.GetAll().OrderBy(x => x.Id);
            return Partial(SitePages.EditorSkills_Grid, list);
        }

        public ActionResult OnPostDelete(int modelId)
        {
            _skillService.Delete(modelId);
            return RedirectToPage(SitePages.EditorSkillsIndex);
        }
    }
}
