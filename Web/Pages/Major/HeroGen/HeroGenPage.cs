using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;
using Pnprpg.WebCore.Enums;
using Pnprpg.WebCore.Helpers;

namespace Pnprpg.WebCore.Pages.Major.HeroGen
{
    public class HeroGenPage : MajorPage
    {
        public bool IsPartial { get; set; }
        public StatusResult Status { get; set; }
        public HeroModel Hero { get; set; }
        public readonly HeroGenStage CurrentStage;

        protected readonly ICoreLogic CoreLogic;

        public HeroGenPage(ICoreLogic coreLogic, HeroGenStage stage, IMajorService majorService) : base(majorService)
        {
            CoreLogic = coreLogic;
            CurrentStage = stage;
        }

        protected ActionResult GoNext()
        {
            var nextStage = CurrentStage + 1;
            Hero.SetStatus(nextStage);
            SaveHeroToCookies(Hero);
            return CustomRedirect(StageHelper.GetPage(nextStage), new { IsPartial = true });
        }

        protected bool IsValid() => Hero.MaxStage >= CurrentStage;

        private HeroModel CreateHero(MajorType major) => CoreLogic.CreateHero(major);

        protected HeroModel GetHeroFromCookies(MajorType major)
        {
            var cookie = HttpContext.GetCookie(CookieType.Hero);
            var hero = CoreLogic.DecodeHero(cookie, major);
            return hero ?? (User.IsInRole(UserRole.Master.ToString()) ? null : CreateHero(major));
        }

        protected void SaveHeroToCookies(HeroModel model)
        {
            HttpContext.SaveCookie(CookieType.Hero, CoreLogic.EncodeHero(model, model.Major));
        }
    }
}
