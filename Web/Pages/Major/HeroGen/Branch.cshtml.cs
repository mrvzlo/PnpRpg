using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.WebCore.Pages.Major.HeroGen
{
    public class BranchModel : HeroGenPage
    {
        public List<BranchViewModel> Branches { get; set; }

        private readonly IBranchService _branchService;

        public BranchModel(ICoreLogic coreLogic, IBranchService branchService, IMajorService majorService) 
            : base(coreLogic, HeroGenStage.Branch, majorService)
        {
            _branchService = branchService;
        }

        public ActionResult OnGet(MajorType major, bool isPartial = false)
        {
            Hero = GetHeroFromCookies(major);
            IsPartial = isPartial;
            Branches = _branchService.GetAllWithPerks(major);
            return IsValid() ? Page() : CustomRedirect(SitePages.MajorHeroGenIndex);
        }

        public ActionResult OnPost(MajorType major, int id)
        {
            Hero = GetHeroFromCookies(major);
            var response = _branchService.Assign(Hero, id, 0);
            if (!response.Successful())
            {
                IsPartial = true;
                Status = new StatusResult(response.Errors);
                return Page();
            }

            Hero = response.Object;
            return GoNext();
        }

    }
}
