using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.WebCore.Pages.HeroGen
{
    public class RaceModel : HeroGenPage
    {
        public IQueryable<RaceViewModel> Races { get; set; }

        private readonly IRaceService _raceService;

        public RaceModel(ICoreLogic coreLogic, IConfiguration configuration, IRaceService raceService, IMajorService majorService) 
            : base(coreLogic, configuration, HeroGenStage.Race, majorService)
        {
            _raceService = raceService;
        }

        public void OnGet(bool isPartial = false)
        {
            Hero = GetHeroFromCookies();
            IsPartial = isPartial;
            Races = _raceService.GetAll();
        }

        public ActionResult OnPost(int id)
        {
            Hero = GetHeroFromCookies();
            var response = _raceService.AssignRace(Hero, id);
            if (!response.Successful())
            {
                IsPartial = true;
                Status = new StatusResult(response.Errors);
                Races = _raceService.GetAll();
                return Page();
            }

            Hero = response.Object;
            return GoNext();
        }
    }
}
