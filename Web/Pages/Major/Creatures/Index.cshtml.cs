using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;

namespace Pnprpg.WebCore.Pages.Major.Creatures
{
    public class IndexModel : PageModel
    {
        private readonly ICreatureService _creatureService;

        public IndexModel(ICreatureService creatureService)
        {
            _creatureService = creatureService;
        }

        public void OnGet(MajorType major) { }

        public PartialViewResult OnGetGrid(MajorType major)
        {
            var list = _creatureService.GetAll(major);
            return Partial(SitePages.MajorCreatures_Grid, list);
        }
    }
}
