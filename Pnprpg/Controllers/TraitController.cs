using System.Web.Mvc;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;
using Pnprpg.Web.Helpers;

namespace Pnprpg.Web.Controllers
{
    public class TraitController : BaseGenController
    {
        private readonly ITraitService _traitService;

        public TraitController(ITraitService traitService, ICoreLogic coreLogic) : base(coreLogic)
        {
            _traitService = traitService;
        }

        public ActionResult TraitsPage()
        {
            var hero = GetHeroFromCookies();
            var traits = _traitService.GetForHero(hero);
            return PartialView("_Traits", traits);
        }

        public JsonResult Traits()
        {
            var hero = GetHeroFromCookies();
            return ReturnJson(GetPartialForHero(hero), GetUrl(Status.Traits));
        }

        public JsonResult ChooseTrait(int id)
        {
            var hero = GetHeroFromCookies();
            var response = _traitService.AssignTraitToHero(hero, id);
            if (response.Successful())
            {
                hero = response.Object;
                SaveHeroToCookies(hero);
                return ReturnJson(GetPartialForHero(hero), GetUrl(Status.Traits));
            }

            var status = this.RenderPartialViewToString("_Status", new StatusResult(false, "Ошибка, некорректные атрибуты"));
            return ReturnJson(GetPartialForHero(hero), GetUrl(Status.Traits), status);
        }

        public JsonResult ResetTraits()
        {
            var hero = GetHeroFromCookies();
            hero = _traitService.ResetTraitsForHero(hero).Object;
            SaveHeroToCookies(hero);
            return ReturnJson(GetPartialForHero(hero), GetUrl(Status.Traits));
        }

        private string GetPartialForHero(HeroModel hero)
        {
            var traits = _traitService.GetForHero(hero);
            return this.RenderPartialViewToString("_Traits", traits);
        }
    }
}