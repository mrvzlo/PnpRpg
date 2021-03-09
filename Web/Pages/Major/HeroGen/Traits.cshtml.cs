using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.WebCore.Pages.Major.HeroGen
{
    public class TraitsModel : HeroGenPage
    {
        public TraitGroup Traits { get; set; }
        private readonly ITraitService _traitService;

        public TraitsModel(ICoreLogic coreLogic, ITraitService traitService, IMajorService majorService) 
            : base(coreLogic, HeroGenStage.Traits, majorService)
        {
            _traitService = traitService;
        }

        public ActionResult OnGet(MajorType major, bool isPartial = false)
        {
            IsPartial = isPartial;
            Hero = GetHeroFromCookies(major);
            Traits = _traitService.GetForHero(Hero);
            return IsValid() ? Page() : CustomRedirect(SitePages.MajorHeroGenIndex);
        }

        public ActionResult OnPost(MajorType major, int id)
        {
            IsPartial = true;
            Hero = GetHeroFromCookies(major);
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

        public ActionResult OnPostReset(MajorType major)
        {
            IsPartial = true;
            OnGet(major, true);
            Hero = _traitService.ResetTraitsForHero(Hero).Object;
            SaveHeroToCookies(Hero);
            Traits = _traitService.GetForHero(Hero);
            return Page();
        }

        public ActionResult OnPostSave(MajorType major)
        {
            Hero = GetHeroFromCookies(major);
            return GoNext();
        }
    }
}
