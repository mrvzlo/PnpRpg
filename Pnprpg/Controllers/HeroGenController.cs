using System.Web.Mvc;
using Pnprpg.DomainService.IServices;
using Pnprpg.Web.Enums;
using Pnprpg.Web.Helpers;

namespace Pnprpg.Web.Controllers
{
    public class HeroGenController : BaseGenController
    {
        public HeroGenController(ICoreLogic coreLogic) : base(coreLogic) { }

        public ActionResult Index(Status status = Status.Race)
        {
            ViewBag.Status = status;
            return View(GetHeroFromCookies());
        }

        public JsonResult GetHeroModel()
        {
            var heroModel = CreateHero();
            SaveHeroToCookies(heroModel);
            var partial = this.RenderPartialViewToString("_StatEdit", heroModel);
            return ReturnJson(partial, GetUrl(Status.Abilities));
        }

        public JsonResult Result()
        {
            var partial = this.RenderPartialViewToString("_Result", GetHeroFromCookies());
            return ReturnJson(partial, GetUrl(Status.Result));
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