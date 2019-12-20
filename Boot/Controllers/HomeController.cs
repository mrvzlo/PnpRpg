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

        public JsonResult GetChaosChoice() =>
            Json(this.RenderPartialViewToString("_Chaos"), JsonRequestBehavior.AllowGet);

        public JsonResult GetHeroModel(ChaosLevel level) =>
            Json(this.RenderPartialViewToString("_Attributes", new HeroModel(level)), JsonRequestBehavior.AllowGet);
    }
}