using System.Web.Mvc;

namespace Boot.Controllers
{
    public class BaseController : Controller
    {
        protected JsonResult ReturnJson(string partial, string url) =>
            Json(new { url, partial }, 0);
    }
}