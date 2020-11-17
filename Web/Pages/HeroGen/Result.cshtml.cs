using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;

namespace Pnprpg.WebCore.Pages.HeroGen
{
    public class ResultModel : HeroGenPage
    {
        public ResultModel(ICoreLogic coreLogic, IConfiguration configuration) : base(coreLogic, configuration, HeroGenStage.Result)
        {
        }

        public ActionResult OnGet(bool isPartial = false)
        {
            IsPartial = isPartial;
            Hero = GetHeroFromCookies();
            if (!IsValid())
                return RedirectToPage(SitePages.HeroGenIndex);
            return Page();
        }
    }
}
