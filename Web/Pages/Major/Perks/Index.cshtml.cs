using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.WebCore.Pages.Major.Perks
{
    public class IndexModel : PageModel
    {
        public IQueryable<PerkViewModel> Perks { get; set; }

        private readonly IPerkService _perkService;

        public IndexModel(IPerkService perkService)
        {
            _perkService = perkService;
        }

        public void OnGet(MajorType major)
        {
            Perks = _perkService.GetAllSimplified(major);
        }
    }
}
