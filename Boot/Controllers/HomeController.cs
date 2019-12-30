using System.Web.Mvc;
using Boot.Helpers;
using Boot.Models;

namespace Boot.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(Status status = Status.Intro, HeroModel model = null)
        {
            ViewBag.Status = status;
            return View(model);
        }

        public JsonResult GetChaosChoice()
        {
            var partial = this.RenderPartialViewToString("_Chaos");
            var url = Url.Action("Index", new { status = Status.Chaos });
            return ReturnJson(partial, url);
        }

        public JsonResult GetHeroModel(ChaosLevel level)
        {
            var heroModel = new HeroModel(level);
            var partial = this.RenderPartialViewToString("_Attributes", heroModel);
            var url = Url.Action("Index", new {status = Status.Attributes, model = heroModel });
            return ReturnJson(partial, url);
        }

        private JsonResult ReturnJson(string partial, string url) =>
            Json(new { url, partial }, 0);
    }
}