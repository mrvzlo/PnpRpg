using Microsoft.AspNetCore.Mvc.RazorPages;
using Pnprpg.DomainService.Models;

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

    }
}
