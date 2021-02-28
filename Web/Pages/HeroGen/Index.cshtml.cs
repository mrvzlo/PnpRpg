using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.WebCore.Helpers;

namespace Pnprpg.WebCore.Pages.HeroGen
{
    public class IndexModel : HeroGenPage
    {
        public IndexModel(ICoreLogic coreLogic, IConfiguration configuration, IMajorService majorService) 
            : base(coreLogic, configuration, 0, majorService)
        {
        }

        public ActionResult OnGet(HeroGenStage? stage)
        {
            stage ??= GetHeroFromCookies().MaxStage;
            return RedirectToPage(StageHelper.GetPage(stage.Value));
        }
    }
}