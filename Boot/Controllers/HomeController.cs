using System.Web.Mvc;
using Boot.Helpers;

namespace Boot.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() => View();

        public JsonResult GetFormForChaos() => 
            Json(new { modalBody = this.RenderPartialViewToString("_EditCoin") });
    }
}