using System.Configuration;
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

        protected HeroModel CreateHero() => CoreLogic.CreateHero(Company.Fantasy);

        protected HeroModel GetHeroFromCookies()
        {
            var cookie = GetCookie(CookieType.Hero);
            var hero = CoreLogic.DecodeHero(cookie, ConfigurationManager.AppSettings["Version"]);
            return hero ?? (User.IsInRole(UserRole.Master.ToString()) ? null : CreateHero());
        }

        protected void SaveHeroToCookies(HeroModel model)
        {
            SaveCookie(CookieType.Hero, CoreLogic.EncodeHero(model, ConfigurationManager.AppSettings["Version"]));
        }

        protected string GetUrl(Status status) => Url.Action("Index", "HeroGen", new { status });
    }
}