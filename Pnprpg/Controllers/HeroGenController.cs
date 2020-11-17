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

        public ActionResult Index(HeroGenStage stage = HeroGenStage.Race)
        {
            var hero = GetHeroFromCookies();
            ViewBag.Status = stage;
            return View(hero);
        }

        public JsonResult Result()
        {
            var hero = GetHeroFromCookies();
            var partial = this.RenderPartialViewToString("_HeroInfo", hero);
            if (hero.MaxStage != HeroGenStage.Result)
            {
                hero.SetStatus(HeroGenStage.Result);
                SaveHeroToCookies(hero);
            }

            return ReturnJson(partial);
        }

        public PartialViewResult Wizard(HeroGenStage stage)
        {
            var hero = GetHeroFromCookies();
            ViewBag.Current = stage;
            return PartialView("_Wizard", hero.MaxStage);
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