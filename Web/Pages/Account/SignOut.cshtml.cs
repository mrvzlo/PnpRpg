using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Pnprpg.WebCore.Pages.Account
{
    public class SignOutModel : PageModel
    {
        public ActionResult OnPost()
        {
            HttpContext.SignOutAsync();
            return RedirectToPage(SitePages.Index);
        }
    }
}
