using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Pnprpg.DomainService.Models;
using Pnprpg.DomainService.Models.Processing;
using Pnprpg.Web.Enums;
using Rotativa;

namespace Pnprpg.Web.Controllers
{
    public class BaseController : Controller
    {
        protected JsonResult ReturnJson(string partial = null, string url = null, string status = null) =>
            Json(new { url, partial, status }, 0);

        protected void SaveCookie(CookieType t, string data) =>
            Response.Cookies.Add(CreateCookie(t.ToString().ToLower(), data));

        protected string GetCookie(CookieType t) => Request.Cookies[t.ToString().ToLower()]?.Value;

        private HttpCookie CreateCookie(string name, string data, int hours = 24) =>
            new HttpCookie(name) { Value = data, Expires = DateTime.Now.AddHours(hours) };

        protected void AddModelStateErrors<T>(ServiceResponse<T> response) where T : class
        {
            if (response.Successful()) return;
            foreach (var error in response.Errors)
                ModelState.AddModelError(error.Key, error.Error);
        }

        protected void SaveRotativa(ViewAsPdf pdf, string path)
        {
            var byteArray = pdf.BuildFile(ControllerContext);
            var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            fileStream.Write(byteArray, 0, byteArray.Length);
            fileStream.Close();
        }
    }
}