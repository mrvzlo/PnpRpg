using Microsoft.AspNetCore.Authorization;

namespace Pnprpg.WebCore.Pages.Editor
{
    [Authorize(Roles = "Editor")]
    public class EditorPage : BasePage
    {
    }
}
