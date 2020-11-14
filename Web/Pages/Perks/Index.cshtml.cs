using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.WebCore.Pages.Perks
{
    public class IndexModel : PageModel
    {
        public IQueryable<PerkViewModel> Perks { get; set; }

        private readonly IPerkService _perkService;

        public IndexModel(IPerkService perkService)
        {
            _perkService = perkService;
        }

        public void OnGet()
        {
            Perks = _perkService.GetAllSimplified();
        }
    }
}
