using Microsoft.AspNetCore.Mvc.RazorPages;
using Pnprpg.DomainService.Enums;

namespace Pnprpg.WebCore.Pages.Major.Sheets
{
    public class IndexModel : PageModel
    {
        public MajorType Major;

        public void OnGet(MajorType major)
        {
            Major = major;
        }
    }
}
