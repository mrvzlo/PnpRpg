using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Pnprpg.WebCore.Enums;

namespace Pnprpg.WebCore.Helpers
{
    public static class CookieHelper
    {
        public static void SaveCookie(this HttpContext httpContext, CookieType cookieType, string data, int hours = 24) =>
            httpContext.Response.Cookies.Append(cookieType.ToString().ToLower(), data, CreateCookieOptions(hours));

        public static string GetCookie(this HttpContext httpContext, CookieType cookieType) => 
            httpContext.Request.Cookies[cookieType.ToString().ToLower()];

        private static CookieOptions CreateCookieOptions(int hours) =>
            new CookieOptions { Expires = DateTime.Now.AddHours(hours), SameSite = SameSiteMode.Lax };
    }
}
