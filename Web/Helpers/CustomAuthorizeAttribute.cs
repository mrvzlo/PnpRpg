using System;
using System.Net;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Pnprpg.DomainService.Enums;

namespace Pnprpg.WebCore.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public sealed class CustomAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly UserRole _role;

        public CustomAuthorizeAttribute(UserRole role)
        {
            AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme;
            _role = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            if (!user.Identity.IsAuthenticated)
                return;
            if (!AccessHelper.UserInRole(user, _role))
                context.Result = new StatusCodeResult((int)HttpStatusCode.Forbidden);
        }
    }
}
