using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.WebCore.Helpers;

namespace Pnprpg.WebCore.Pages.Major.Editor
{
    [CustomAuthorize(UserRole.Editor)]
    public class EditorPage : MajorPage
    {
        public EditorPage(IMajorService majorService) : base(majorService)
        {
        }
    }
}
