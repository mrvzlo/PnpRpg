using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.WebCore.Pages.HeroGen
{
    public class BranchModel : HeroGenPage
    {
        public List<BranchViewModel> Branches { get; set; }

        private readonly IBranchService _branchService;

        public BranchModel(ICoreLogic coreLogic, IConfiguration configuration, IBranchService branchService) 
            : base(coreLogic, configuration, HeroGenStage.Branch)
        {
            _branchService = branchService;
        }

        public ActionResult OnGet(bool isPartial = false)
        {
            Hero = GetHeroFromCookies();
            IsPartial = isPartial;
            Branches = _branchService.GetAllWithPerks();
            if (!IsValid())
                return RedirectToPage(SitePages.HeroGenIndex);
            return Page();
        }

        public ActionResult OnPost(int id)
        {
            Hero = GetHeroFromCookies();
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
