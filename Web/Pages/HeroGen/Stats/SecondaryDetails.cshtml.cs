using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Pnprpg.WebCore.Pages.HeroGen
{
    public class SecondaryDetails : PageModel
    {
        public string Color { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }
}
