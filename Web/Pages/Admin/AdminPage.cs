using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.WebCore.Helpers;

namespace Pnprpg.WebCore.Pages.Admin
{
    [CustomAuthorize(UserRole.Admin)]
    public class AdminPage : BasePage
    {
    }
}
