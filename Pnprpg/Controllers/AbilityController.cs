using System.Web.Mvc;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.Web.Helpers;

namespace Pnprpg.Web.Controllers
{
    public class AbilityController : BaseGenController
    {
        private readonly IAbilityService _abilityService;

        public AbilityController(IAbilityService abilityService, ICoreLogic coreLogic) : base(coreLogic)
        {
            _abilityService = abilityService;
        }
        
        public PartialViewResult Abilities()
        {
            var hero = GetHeroFromCookies();
            return PartialView("HeroInfo/_Abilities", hero.Abilities);
        }

        public PartialViewResult AbilityEdit()
        {
            var hero = GetHeroFromCookies();
            return PartialView("HeroInfo/_AbilityEdit", hero);
        }

        public JsonResult UpdateAbility(int abilityId, int value)
        {
            var hero = GetHeroFromCookies();
            var result = _abilityService.UpgradeAbility(hero, abilityId, value);
            if (result.Successful())
            {
                hero = result.Object;
                SaveHeroToCookies(hero);
            }

            var partial = this.RenderPartialViewToString("HeroInfo/_AbilityEdit", hero);
            return Json(new {partial}, JsonRequestBehavior.AllowGet);
        }
    }
}