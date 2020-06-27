using System;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Boot.Enums;
using Boot.Helpers;
using Boot.Models;
using Newtonsoft.Json;

namespace Boot.Controllers
{
    public class BaseController : Controller
    {
        protected void SaveCookie(CookieType t, string data) =>
            Response.Cookies.Add(CreateCookie(t.ToString().ToLower(), data));

        protected string GetCookie(CookieType t) => Request.Cookies[t.ToString().ToLower()]?.Value;

        private HttpCookie CreateCookie(string name, string data, int hours = 24) =>
            new HttpCookie(name) { Value = data, Expires = DateTime.Now.AddHours(hours) };

        protected JsonResult ReturnJson(string partial, string url, string status = null) =>
            Json(new { url, partial, status }, 0);

        protected T GetJsonFromFile<T>(string fileName)
        {
            var path = Server.MapPath($"~/App_Data/{fileName}");
            var json = System.IO.File.ReadAllText(path, Encoding.UTF8);
            return JsonConvert.DeserializeObject<T>(json);
        }

        protected void SaveJsonToFile<T>(T obj, string fileName)
        {
            var path = Server.MapPath($"~/App_Data/{fileName}");
            var content = JsonConvert.SerializeObject(obj);
            System.IO.File.WriteAllText(path, content, Encoding.UTF8);
        }

        protected void AddModelStateErrors(ServiceResponse response)
        {
            if (response.Successful()) return;
            foreach (var error in response.Errors)
                ModelState.AddModelError(error.Key, error.Error);
        }

    }
}