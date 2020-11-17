using Microsoft.AspNetCore.Mvc.RazorPages;
using Pnprpg.DomainService.Models;

namespace Pnprpg.WebCore.Pages.HeroGen
{
    public class IncStatModel : PageModel
    {
        public AbilityModel Ability { get; set; }
        public int Value { get; set; }
        public int Remaining { get; set; }
        public bool OnlyLg { get; set; }
    }
}
