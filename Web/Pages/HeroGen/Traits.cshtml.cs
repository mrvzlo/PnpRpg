using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.WebCore.Pages.HeroGen
{
    public class TraitsModel : HeroGenPage
    {
        public TraitGroup Traits { get; set; }
        private readonly ITraitService _traitService;

        public TraitsModel(ICoreLogic coreLogic, IConfiguration configuration, ITraitService traitService) 
            : base(coreLogic, configuration, HeroGenStage.Traits)
        {
            _traitService = traitService;
        }

        public ActionResult OnGet(bool isPartial = false)
        {
            IsPartial = isPartial;
            Hero = GetHeroFromCookies();
            Traits = _traitService.GetForHero(Hero);
            if (!IsValid())
                return RedirectToPage(SitePages.HeroGenIndex);
            return Page();
        }

        public ActionResult OnPost(int id)
        {
            IsPartial = true;
            Hero = GetHeroFromCookies();
            var response = _traitService.AssignTraitToHero(Hero, id);
            if (!response.Successful())
            {
                IsPartial = true;
                Status = new StatusResult(response.Errors);
                Traits = _traitService.GetForHero(Hero);
                return Page();
            }

            Hero = response.Object;
            SaveHeroToCookies(Hero);
            Traits = _traitService.GetForHero(Hero);
            return Page();
        }

        public ActionResult OnPostReset()
        {
            IsPartial = true;
            OnGet(true);
            Hero = _traitService.ResetTraitsForHero(Hero).Object;
            SaveHeroToCookies(Hero);
            Traits = _traitService.GetForHero(Hero);
            return Page();
        }

        public ActionResult OnPostSave()
        {
            Hero = GetHeroFromCookies();
            return GoNext();
        }
    }
}
