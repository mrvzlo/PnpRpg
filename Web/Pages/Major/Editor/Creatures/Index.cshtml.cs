using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;

namespace Pnprpg.WebCore.Pages.Major.Editor.Creatures
{
    public class IndexModel : EditorPage
    {
        private readonly ICreatureService _creatureService;

        public IndexModel(ICreatureService creatureService, IMajorService majorService) : base(majorService)
        {
            _creatureService = creatureService;
        }
        
        public PartialViewResult OnGetGrid(MajorType major)
        {
            var list = _creatureService.GetAll(major).OrderBy(x => x.Id);
            return Partial(SitePages.MajorEditorCreatures_Grid, list);
        }

        public ActionResult OnPostDelete(int modelId)
        {
            _creatureService.Delete(modelId);
            return CustomRedirect(SitePages.MajorEditorCreaturesIndex);
        }
    }
}
