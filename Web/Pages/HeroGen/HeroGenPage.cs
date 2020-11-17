using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;
using Pnprpg.WebCore.Enums;
using Pnprpg.WebCore.Helpers;

namespace Pnprpg.WebCore.Pages.HeroGen
{
    public class HeroGenPage : BasePage
    {
        public bool IsPartial { get; set; }
        public StatusResult Status { get; set; }
        public HeroModel Hero { get; set; }
        public readonly HeroGenStage CurrentStage;

        protected readonly ICoreLogic CoreLogic;
        protected readonly IConfiguration Configuration;

        public HeroGenPage(ICoreLogic coreLogic, IConfiguration configuration, HeroGenStage stage)
        {
            CoreLogic = coreLogic;
            Configuration = configuration;
            CurrentStage = stage;
        }

        protected ActionResult GoNext()
        {
            var nextStage = CurrentStage + 1;
            Hero.SetStatus(nextStage);
            SaveHeroToCookies(Hero);
            return RedirectToPage(StageHelper.GetPage(nextStage), new { IsPartial = true });
        }

        protected bool IsValid() => Hero.MaxStage >= CurrentStage;

        protected HeroModel CreateHero() => CoreLogic.CreateHero(Company.Fantasy);

        protected HeroModel GetHeroFromCookies()
        {
            var cookie = GetCookie(CookieType.Hero);
            var hero = CoreLogic.DecodeHero(cookie, Configuration["Version"]);
            return hero ?? (User.IsInRole(UserRole.Master.ToString()) ? null : CreateHero());
        }

        protected void SaveHeroToCookies(HeroModel model)
        {
            SaveCookie(CookieType.Hero, CoreLogic.EncodeHero(model, Configuration["Version"]));
        }
    }
}
