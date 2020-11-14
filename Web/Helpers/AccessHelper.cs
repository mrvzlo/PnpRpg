using System.Security.Principal;
using Pnprpg.DomainService.Enums;

namespace Pnprpg.WebCore.Helpers
{
    public class AccessHelper
    {
        public static bool UserInRole(IPrincipal user, UserRole minRole)
        {
            return user.Identity.IsAuthenticated && (user.IsInRole(minRole.ToString()) || user.IsInRole(UserRole.Admin.ToString()));
        }
    }
}