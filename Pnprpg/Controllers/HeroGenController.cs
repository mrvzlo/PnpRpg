using System.Web.Mvc;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;
using Pnprpg.Web.Helpers;
using Rocket.PdfGenerator;

namespace Pnprpg.Web.Controllers
{
    public class HeroGenController : BaseGenController
    {
        private readonly ICoreLogic _coreLogic;

        public HeroGenController(ICoreLogic coreLogic) : base(coreLogic)
        {
            _coreLogic = coreLogic;
        }

        public ActionResult Index(HeroGenStatus status = HeroGenStatus.Race)
        {
            var hero = GetHeroFromCookies();
            ViewBag.Status = status;
            return View(hero);
        }

        public JsonResult Result()
        {
            var hero = GetHeroFromCookies();
            var partial = this.RenderPartialViewToString("_HeroInfo", hero);
            if (hero.MaxStatus != HeroGenStatus.Result)
            {
                hero.SetStatus(HeroGenStatus.Result);
                SaveHeroToCookies(hero);
            }

            return ReturnJson(partial);
        }

        public PartialViewResult Wizard(HeroGenStatus status)
        {
            var hero = GetHeroFromCookies();
            ViewBag.Current = status;
            return PartialView("_Wizard", hero.MaxStatus);
        }

        [HttpPost]
        public ActionResult Save(HeroModel model)
        {
            var hero = GetHeroFromCookies();
            hero.Name = model.Name;
            SaveHeroToCookies(hero);
            Converter.Orientation = PageOrientation.Landscape;
            hero = _coreLogic.GetFullHeroInfo(hero);
            return PersonalPdf(Converter, "HeroInfo/MainSheet", hero);
        }
    }
}