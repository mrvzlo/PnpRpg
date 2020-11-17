using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.WebCore.Pages.HeroGen
{
    public class AbilitiesModel : HeroGenPage
    {
        public AbilitiesModel Abilities { get; set; }

        private readonly IAbilityService _abilityService;
        public AbilitiesModel(ICoreLogic coreLogic, IConfiguration configuration, IAbilityService abilityService)
            : base(coreLogic, configuration, HeroGenStage.Abilities)
        {
            _abilityService = abilityService;
        }

        public ActionResult OnGet(bool isPartial = false)
        {
            IsPartial = isPartial;
            Hero = GetHeroFromCookies();
            if (!IsValid())
                return RedirectToPage(SitePages.HeroGenIndex);
            return Page();
        }

        public ActionResult OnPost(int abilityId, int value)
        {
            IsPartial = true;
            Hero = GetHeroFromCookies();
            var result = _abilityService.UpgradeAbility(Hero, abilityId, value);
            if (result.Successful())
            {
                Hero = result.Object;
                SaveHeroToCookies(Hero);
                return Page();
            }

            Status = new StatusResult(result.Errors);
            return Page();
        }

        public ActionResult OnPostSave()
        {
            Hero = GetHeroFromCookies();
            return GoNext();
        }
    }
}
