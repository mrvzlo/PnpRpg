using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.WebCore.Pages.Major.HeroGen
{
    public class RaceModel : HeroGenPage
    {
        public IQueryable<RaceViewModel> Races { get; set; }

        private readonly IRaceService _raceService;

        public RaceModel(ICoreLogic coreLogic, IRaceService raceService, IMajorService majorService) 
            : base(coreLogic, HeroGenStage.Race, majorService)
        {
            _raceService = raceService;
        }

        public void OnGet(MajorType major, bool isPartial = false)
        {
            Hero = GetHeroFromCookies(major);
            IsPartial = isPartial;
            Races = _raceService.GetAll(major);
        }

        public ActionResult OnPost(MajorType major, int id)
        {
            Hero = GetHeroFromCookies(major);
            var response = _raceService.AssignRace(Hero, id);
            if (!response.Successful())
            {
                IsPartial = true;
                Status = new StatusResult(response.Errors);
                Races = _raceService.GetAll(major);
                return Page();
            }

            Hero = response.Object;
            return GoNext();
        }
    }
}
