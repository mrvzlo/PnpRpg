using System;
using System.Web;
using System.Web.Mvc;
using Boot.Enums;

namespace Boot.Controllers
{
    public class BaseController : Controller
    {
        protected void SaveCookie(CookieType t, string data) =>
            Response.Cookies.Add(CreateCookie(t.ToString(), data));

        protected string GetCookie(CookieType t) => Request.Cookies[t.ToString()]?.Value;

        private HttpCookie CreateCookie(string name, string data, int hours = 24) =>
            new HttpCookie(name) { Value = data, Expires = DateTime.Now.AddHours(hours) };

        protected JsonResult ReturnJson(string partial, string url) =>
            Json(new { url, partial }, 0);
    }
}