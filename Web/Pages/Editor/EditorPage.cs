using Pnprpg.DomainService.Enums;
using Pnprpg.WebCore.Helpers;

namespace Pnprpg.WebCore.Pages.Editor
{
    [CustomAuthorize(UserRole.Editor)]
    public class EditorPage : BasePage
    {
    }
}
