using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.WebCore.Pages.Major.HeroGen
{
    public class AbilitiesModel : HeroGenPage
    {
        public AbilitiesModel Abilities { get; set; }

        private readonly IAbilityService _abilityService;
        public AbilitiesModel(ICoreLogic coreLogic, IAbilityService abilityService, IMajorService majorService)
            : base(coreLogic, HeroGenStage.Abilities, majorService)
        {
            _abilityService = abilityService;
        }

        public ActionResult OnGet(MajorType major, bool isPartial = false)
        {
            IsPartial = isPartial;
            Hero = GetHeroFromCookies(major);
            return IsValid() ? Page() : CustomRedirect(SitePages.MajorHeroGenIndex);
        }

        public ActionResult OnPost(MajorType major, AbilityType abilityType, int value)
        {
            IsPartial = true;
            Hero = GetHeroFromCookies(major);
            var result = _abilityService.UpgradeAbility(Hero, abilityType, value);
            if (result.Successful())
            {
                Hero = result.Object;
                SaveHeroToCookies(Hero);
                return Page();
            }

            Status = new StatusResult(result.Errors);
            return Page();
        }

        public ActionResult OnPostSave(MajorType major)
        {
            Hero = GetHeroFromCookies(major);
            return GoNext();
        }
    }
}
