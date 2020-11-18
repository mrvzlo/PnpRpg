using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Pnprpg.DomainService.Enums;

namespace Pnprpg.WebCore.Pages.Admin
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = nameof(UserRole.Admin))]
    public class AdminPage : BasePage
    {
    }
}
