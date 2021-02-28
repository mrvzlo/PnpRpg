using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pnprpg.DomainService.IServices;

namespace Pnprpg.WebCore.Pages.Creatures
{
    public class IndexModel : PageModel
    {
        private readonly ICreatureService _creatureService;

        public IndexModel(ICreatureService creatureService)
        {
            _creatureService = creatureService;
        }

        public void OnGet() { }

        public PartialViewResult OnGetGrid()
        {
            var list = _creatureService.GetAll();
            return Partial(SitePages.Creatures_Grid, list);
        }
    }
}
