using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pnprpg.DomainService.Models;
using Pnprpg.WebCore.Helpers;

namespace Pnprpg.WebCore.Pages
{
    public class BasePage : PageModel
    {
        protected void AddModelStateErrors<T>(ServiceResponse<T> response) where T : class
        {
            if (response.Successful()) return;
            foreach (var error in response.Errors)
                ModelState.AddModelError(error.Key, error.Error);
        }

        protected ActionResult CustomRedirect(string page, object routeValues = null)
        {
            return Redirect(Url.CustomPage(page, routeValues));
        }
    }
}
