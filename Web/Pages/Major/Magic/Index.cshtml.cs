using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.WebCore.Pages.Major.Magic
{
    public class IndexModel : PageModel
    {
        public IQueryable<MagicSchoolModel> Schools { get; set; }

        private readonly IMagicService _magicService;

        public IndexModel(IMagicService magicService)
        {
            _magicService = magicService;
        }

        public void OnGet()
        {
            Schools = _magicService.GetAllSchools();
        }

        public PartialViewResult OnGetRandom()
        {
            var spell = _magicService.GetRandomSpell();
            return Partial(SitePages.MajorMagic_Random, spell);
        }
    }
}
