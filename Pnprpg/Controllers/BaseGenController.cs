using Pnprpg.Domain.Services;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;
using Pnprpg.Web.Enums;

namespace Pnprpg.Web.Controllers
{
    public class BaseGenController : BaseController
    {
        protected readonly ICoreLogic CoreLogic;

        public BaseGenController(ICoreLogic coreLogic)
        {
            CoreLogic = coreLogic;
        }

        protected HeroModel CreateHero(ChaosLevel chaos)
        {
            return CoreLogic.CreateHero(chaos);
        }

        protected HeroModel GetHeroFromCookies()
        {
            var cookie = GetCookie(CookieType.Hero);
            var hero = CoreLogic.DecodeHero(cookie);
            return hero ?? (User.IsInRole(UserRole.Master.ToString()) 
                ? null 
                : CreateHero(ChaosLevel.Normal));
        }

        protected void SaveHeroToCookies(HeroModel model)
        {
            SaveCookie(CookieType.Hero, CoreLogic.EncodeHero(model));
        }

        protected string GetUrl(Status status) => Url.Action("Index", "HeroGen", new { status });
    }
}