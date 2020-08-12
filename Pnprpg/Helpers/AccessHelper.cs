using System.Security.Principal;
using System.Web;
using Pnprpg.DomainService.Enums;

namespace Pnprpg.Web.Helpers
{
    public class AccessHelper
    {
        public static bool UserInRole(HttpRequestBase request, IPrincipal user, UserRole minRole)
        {
            return request.IsAuthenticated && (user.IsInRole(minRole.ToString()) || user.IsInRole(UserRole.Admin.ToString()));
        }
    }
}