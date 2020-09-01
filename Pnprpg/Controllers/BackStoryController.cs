using System.Linq;
using System.Web.Mvc;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;
using Pnprpg.Web.Enums;
using Pnprpg.Web.Helpers;

namespace Pnprpg.Web.Controllers
{
    public class BackStoryController : BaseGenController
    {
        private readonly IRaceService _raceService;
        private readonly IBranchService _branchService;
        private readonly ITraitService _traitService;

        public BackStoryController(IRaceService raceService, ICoreLogic coreLogic, IBranchService branchService, ITraitService traitService) : base(coreLogic)
        {
            _raceService = raceService;
            _branchService = branchService;
            _traitService = traitService;
        }

        public JsonResult Races()
        {
            var races = _raceService.GetAll();
            return ReturnJson(this.RenderPartialViewToString("_Races", races), GetUrl(Status.Race));
        }

        public JsonResult PickRace(int id)
        {
            var hero = GetHeroFromCookies();
            var response = _raceService.AssignRace(hero, id);
            if (!response.Successful())
            {
                var statusMessage = this.RenderPartialViewToString("_Status", new StatusResult(false, "Ошибка, некорректные атрибуты"));
                var partial = this.RenderPartialViewToString("_Races", hero);
                return ReturnJson(partial, GetUrl(Status.Race), statusMessage);
            }

            hero = response.Object;
            SaveHeroToCookies(hero);
            return Branches();
        }

        public JsonResult Branches()
        {
            var query = _branchService.GetAll();
            return ReturnJson(this.RenderPartialViewToString("_Branches", query), GetUrl(Status.Branch));
        }

        public JsonResult PickBranch(int id)
        {
            var hero = GetHeroFromCookies();
            var response = _branchService.Assign(hero, id, 0);
            string partial;
            if (!response.Successful())
            {
                var statusMessage = this.RenderPartialViewToString("_Status", new StatusResult(false, "Ошибка, некорректные атрибуты"));
                partial = this.RenderPartialViewToString("_Branches", hero);
                return ReturnJson(partial, GetUrl(Status.Branch), statusMessage);
            }

            hero = response.Object;
            SaveHeroToCookies(hero);
            partial = this.RenderPartialViewToString("HeroInfo/_AbilityEdit", hero);
            return ReturnJson(partial, GetUrl(Status.Branch));
        }

        public JsonResult Traits()
        {
            var hero = GetHeroFromCookies();
            return ReturnJson(GetTraitsPartial(hero), GetUrl(Status.Traits));
        }

        public JsonResult ChooseTrait(int id)
        {
            var hero = GetHeroFromCookies();
            var response = _traitService.AssignTraitToHero(hero, id);
            if (response.Successful())
            {
                hero = response.Object;
                SaveHeroToCookies(hero);
                return ReturnJson(GetTraitsPartial(hero), GetUrl(Status.Traits));
            }

            var status = this.RenderPartialViewToString("_Status", new StatusResult(false, "Ошибка, некорректные атрибуты"));
            return ReturnJson(GetTraitsPartial(hero), GetUrl(Status.Traits), status);
        }

        public JsonResult ResetTraits()
        {
            var hero = GetHeroFromCookies();
            hero = _traitService.ResetTraitsForHero(hero).Object;
            SaveHeroToCookies(hero);
            return ReturnJson(GetTraitsPartial(hero), GetUrl(Status.Traits));
        }

        private string GetTraitsPartial(HeroModel hero)
        {
            var traits = _traitService.GetForHero(hero);
            return this.RenderPartialViewToString("_Traits", traits);
        }
    }
}