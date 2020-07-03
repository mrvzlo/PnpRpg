using Boot.Enums;
using System.Security.Principal;
using System.Web;
using System.Web.WebPages;

namespace Boot.Helpers
{
    public class AccessHelper
    {
        public static bool UserInRole(HttpRequestBase requst, IPrincipal user, UserRole minRole)
        {
            return requst.IsAuthenticated && (user.IsInRole(minRole.ToString()) || user.IsInRole(UserRole.Admin.ToString()));
        }
    }
}