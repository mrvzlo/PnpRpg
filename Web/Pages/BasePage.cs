using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;
using Pnprpg.WebCore.Enums;

namespace Pnprpg.WebCore.Pages
{
    public class BasePage : PageModel
    {
        protected void AddModelStateErrors<T>(ServiceResponse<T> response) where T : class
        {
            if (response.Successful()) return;
            foreach (var error in response.Errors)
                ModelState.AddModelError(error.Key, error.Error);
        }

        protected void SaveCookie(CookieType t, string data) =>
            HttpContext.Response.Cookies.Append(t.ToString().ToLower(), data, CreateCookieOptions());

        protected string GetCookie(CookieType t) => HttpContext.Request.Cookies[t.ToString().ToLower()];

        private CookieOptions CreateCookieOptions(int hours = 24) =>
            new CookieOptions{ Expires = DateTime.Now.AddHours(hours), SameSite = SameSiteMode.Lax };

    }
}
