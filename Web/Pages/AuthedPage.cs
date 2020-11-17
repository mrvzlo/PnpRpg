using Microsoft.AspNetCore.Authorization;

namespace Pnprpg.WebCore.Pages
{
    [Authorize]
    public class AuthedPage : BasePage
    {
    }
}
