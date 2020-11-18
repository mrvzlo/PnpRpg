using System.Linq;
using System.Security.Principal;
using Pnprpg.DomainService.Enums;

namespace Pnprpg.WebCore.Helpers
{
    public class AccessHelper
    {
        public static bool UserInRole(IPrincipal user, UserRole minRole)
        {
            return user.Identity != null && user.Identity.IsAuthenticated
                                         && GetHighers(minRole).Any(x => user.IsInRole(x.ToString()));
        }

        private static UserRole[] GetHighers(UserRole role)
        {
            return role switch
            {
                UserRole.Editor => new[] { UserRole.Editor, UserRole.Admin },
                UserRole.Master => new[] { UserRole.Master, UserRole.Admin },
                UserRole.Admin => new[] { UserRole.Admin },
                _ => new[] { UserRole.Player, UserRole.Editor, UserRole.Master, UserRole.Admin }
            };
        }
    }
}