using Pnprpg.Domain.Services;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;
using Pnprpg.Web.Enums;

namespace Pnprpg.Web.Controllers
{
    public class BaseGenController : BaseController
    {
        protected readonly ICoreLogic _coreLogic;

        public BaseGenController(ICoreLogic coreLogic)
        {
            _coreLogic = coreLogic;
        }

        protected HeroModel CreateHero(ChaosLevel chaos)
        {
            return _coreLogic.CreateHero(chaos);
        }

        protected HeroModel GetHeroFromCookies()
        {
            var cookie = GetCookie(CookieType.Hero);
            var hero = _coreLogic.DecodeHero(cookie);
            return hero ?? (User.IsInRole(UserRole.Master.ToString()) 
                ? null 
                : CreateHero(ChaosLevel.Normal));
        }

        protected void SaveHeroToCookies(HeroModel model)
        {
            SaveCookie(CookieType.Hero, _coreLogic.EncodeHero(model));
        }

        protected string GetUrl(Status status) => Url.Action("Index", "HeroGen", new { status });
    }
}