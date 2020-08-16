using System.Linq;
using System.Web.Mvc;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;
using Pnprpg.Web.Helpers;

namespace Pnprpg.Web.Controllers
{
    public class RaceController : BaseGenController
    {
        private readonly IRaceService _raceService;

        public RaceController(IRaceService raceService, ICoreLogic coreLogic) : base(coreLogic)
        {
            _raceService = raceService;
        }

        public PartialViewResult RacesDropdown(int chosen)
        {
            var races = _raceService.GetAll().Select(x => new SelectListItem
            {
                Selected = x.Id == chosen,
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();
            return PartialView("_RacesDropdown", races);
        }

        public JsonResult PickRace(int id)
        {
            var hero = GetHeroFromCookies();
            var partial = this.RenderPartialViewToString("HeroInfo/_AbilityEdit", hero);
            var response = _raceService.AssignRace(hero, id);
            if (!response.Successful())
            {
                var status = this.RenderPartialViewToString("_Status",
                    new StatusResult(false, "Ошибка, некорректные атрибуты"));
                return ReturnJson(partial, GetUrl(Status.Stats), status);
            }

            hero = response.Object;
            partial = this.RenderPartialViewToString("HeroInfo/_AbilityEdit", hero);
            SaveHeroToCookies(hero);
            return ReturnJson(partial, GetUrl(Status.Stats));
        }
    }
}