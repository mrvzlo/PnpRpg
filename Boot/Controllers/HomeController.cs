using System;
using System.Web.Mvc;
using Boot.Enums;
using Boot.Helpers;
using Boot.Models;

namespace Boot.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(Status status = Status.Intro, string heroModel = null)
        {
            ViewBag.Status = status;
            return View(model: heroModel);
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
            var heroModelString = heroModel.ToString();
            var partial = this.RenderPartialViewToString("_Attributes", heroModel);
            var url = Url.Action("Index", new { status = Status.Attributes, heroModel = heroModelString });
            return ReturnJson(partial, url);
        }

        public JsonResult ChangeAttr(string heroEnc, AttributeType attr, bool inc)
        {
            var hero = new HeroModel(heroEnc);
            hero.ChangeAttr(attr, inc ? 1 : -1);
            var heroModelString = hero.ToString();
            var partial = this.RenderPartialViewToString("_Attributes", hero);
            var url = Url.Action("Index", new { status = Status.Attributes, heroModel = heroModelString });
            return ReturnJson(partial, url);
        }

        private JsonResult ReturnJson(string partial, string url) =>
            Json(new { url, partial }, 0);
    }
}