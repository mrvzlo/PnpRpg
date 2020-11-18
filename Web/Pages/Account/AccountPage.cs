using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Pnprpg.DomainService.Helpers;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.WebCore.Pages.Account
{
    public class AccountPage : BasePage
    {
        protected readonly IAccountService AccountService;

        public AccountPage(IAccountService accountService)
        {
            AccountService = accountService;
        }

        protected async Task CreateTicket(UserModel user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username), 
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
        }

        protected string GetRedirectUrl(string returnUrl)
        {
            return returnUrl != null && Url.IsLocalUrl(returnUrl) ? returnUrl : SitePages.Index;
        }
    }
}
