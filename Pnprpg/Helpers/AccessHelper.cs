using Boot.Enums;
using System.Security.Principal;
using System.Web;
using System.Web.WebPages;

namespace Boot.Helpers
{
    public class AccessHelper
    {
        public static bool UserInRole(HttpRequestBase request, IPrincipal user, UserRole minRole)
        {
            return request.IsAuthenticated && (user.IsInRole(minRole.ToString()) || user.IsInRole(UserRole.Admin.ToString()));
        }
    }
}