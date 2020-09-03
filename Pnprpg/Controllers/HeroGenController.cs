using System.Web.Mvc;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.Web.Helpers;

namespace Pnprpg.Web.Controllers
{
    public class HeroGenController : BaseGenController
    {
        public HeroGenController(ICoreLogic coreLogic) : base(coreLogic) { }

        public ActionResult Index(HeroGenStatus status = HeroGenStatus.Race)
        {
            var hero = GetHeroFromCookies();
            ViewBag.Status = status;
            return View(hero);
        }

        public JsonResult Result()
        {
            var hero = GetHeroFromCookies();
            if (hero.MaxStatus != HeroGenStatus.Result)
            {
                hero.SetStatus(HeroGenStatus.Result);
                SaveHeroToCookies(hero);
            }

            var partial = this.RenderPartialViewToString("_HeroInfo", hero);
            return ReturnJson(partial);
        }

        public PartialViewResult Wizard(HeroGenStatus status)
        {
            var hero = GetHeroFromCookies();
            ViewBag.Current = status;
            return PartialView("_Wizard", hero.MaxStatus);
        }

        [Authorize]
        [HttpPost]
        public JsonResult SaveHero(string name)
        {
            var hero = GetHeroFromCookies();
            hero.Name = name;
            hero.Player = User.Identity.Name;
            CoreLogic.SaveHero(hero);
            return Json(this.RenderPartialViewToString("_Redirect", Url.Action("MyHero")));
        }

        [Authorize]
        public ActionResult MyHero()
        {
            var hero = CoreLogic.LoadHero(User.Identity.Name);
            return View(hero);
        }
    }
}