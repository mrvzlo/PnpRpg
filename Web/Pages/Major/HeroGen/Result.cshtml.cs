using Microsoft.AspNetCore.Mvc;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;

namespace Pnprpg.WebCore.Pages.Major.HeroGen
{
    public class ResultModel : HeroGenPage
    {
        public ResultModel(ICoreLogic coreLogic, IMajorService majorService) 
            : base(coreLogic, HeroGenStage.Result, majorService)
        {
        }

        public ActionResult OnGet(MajorType major, bool isPartial = false)
        {
            IsPartial = isPartial;
            Hero = GetHeroFromCookies(major);
            return IsValid() ? Page() : CustomRedirect(SitePages.MajorHeroGenIndex);
        }

        public ActionResult OnPost(MajorType major, string name)
        {
            Hero = GetHeroFromCookies(major);
            Hero.Name = name;
            SaveHeroToCookies(Hero);
            var result = CoreLogic.EncodeHero(Hero, major);
            return CustomRedirect(SitePages.SharedPdfHeroSheet, new { cookie = true });
        }
    }
}
