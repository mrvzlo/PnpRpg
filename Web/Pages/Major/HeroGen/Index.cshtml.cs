using Microsoft.AspNetCore.Mvc;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.WebCore.Helpers;

namespace Pnprpg.WebCore.Pages.Major.HeroGen
{
    public class IndexModel : HeroGenPage
    {
        public IndexModel(ICoreLogic coreLogic, IMajorService majorService) 
            : base(coreLogic, 0, majorService) { }

        public ActionResult OnGet(MajorType major, HeroGenStage? stage)
        {
            stage ??= GetHeroFromCookies(major).MaxStage;
            return CustomRedirect(StageHelper.GetPage(stage.Value));
        }
    }
}