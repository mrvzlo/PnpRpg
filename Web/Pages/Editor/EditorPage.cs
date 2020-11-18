using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Pnprpg.DomainService.Enums;

namespace Pnprpg.WebCore.Pages.Editor
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = nameof(UserRole.Editor))]
    public class EditorPage : BasePage
    {
    }
}
