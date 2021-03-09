using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Pnprpg.WebCore.Pages.Major.HeroGen
{
    public class SecondaryDetails : PageModel
    {
        public string Color { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }

        public SecondaryDetails(string color, string name, int value)
        {
            Color = color;
            Name = name;
            Value = value;
        }
    }
}
