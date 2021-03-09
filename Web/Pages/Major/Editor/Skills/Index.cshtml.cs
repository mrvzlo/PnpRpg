using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;

namespace Pnprpg.WebCore.Pages.Major.Editor.Skills
{
    public class IndexModel : EditorPage
    {
        private readonly ISkillService _skillService;

        public IndexModel(ISkillService skillService, IMajorService majorService) : base(majorService)
        {
            _skillService = skillService;
        }

        public void OnGet() { }

        public PartialViewResult OnGetGrid(MajorType major)
        {
            var list = _skillService.GetAll(major).OrderBy(x => x.Id);
            return Partial(SitePages.MajorEditorSkills_Grid, list);
        }

        public ActionResult OnPostDelete(int modelId)
        {
            _skillService.Delete(modelId);
            return CustomRedirect(SitePages.MajorEditorSkillsIndex);
        }
    }
}
