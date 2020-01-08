using System.Web.Mvc;
using Boot.Enums;
using Boot.Helpers;
using Boot.Models;

namespace Boot.Controllers
{
    public class HeroGenController : BaseController
    {
        public ActionResult Index(Status status = Status.Chaos)
        {
            ViewBag.Status = status;
            return View(GetHeroFromCookies());
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
            SaveHeroToCookies(heroModel);
            var partial = this.RenderPartialViewToString("_Attributes", heroModel);
            var url = Url.Action("Index", new { status = Status.Attributes });
            return ReturnJson(partial, url);
        }

        public JsonResult ChangeAttr(StatType attr, bool inc)
        {
            var hero = GetHeroFromCookies();
            hero.ChangeAttr(attr, inc ? 1 : -1);
            SaveHeroToCookies(hero);
            var partial = this.RenderPartialViewToString("_Attributes", hero);
            var url = Url.Action("Index", new { status = Status.Attributes });
            return ReturnJson(partial, url);
        }

        private HeroModel GetHeroFromCookies() => new HeroModel(GetCookie(CookieType.Hero));

        private void SaveHeroToCookies(HeroModel model) => SaveCookie(CookieType.Hero, model.ToString());
    }
}