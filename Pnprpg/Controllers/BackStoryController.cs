using System.Linq;
using System.Web.Mvc;
using Pnprpg.DomainService.Enums;
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
            return ReturnJson(this.RenderPartialViewToString("_Races", races));
        }

        public JsonResult PickRace(int id)
        {
            var hero = GetHeroFromCookies();
            var response = _raceService.AssignRace(hero, id);
            if (!response.Successful())
            {
                var statusMessage = this.RenderPartialViewToString("_Status", new StatusResult(false, "Ошибка, некорректные атрибуты"));
                var partial = this.RenderPartialViewToString("_Races", hero);
                return ReturnJson(partial, statusMessage);
            }

            hero = response.Object;
            hero.SetStatus(HeroGenStatus.Branch);
            SaveHeroToCookies(hero);
            return Branches();
        }

        public JsonResult Branches()
        {
            var query = _branchService.GetAllWithPerks();
            return ReturnJson(this.RenderPartialViewToString("_Branches", query));
        }

        public JsonResult PickBranch(int id)
        {
            var hero = GetHeroFromCookies();
            var response = _branchService.Assign(hero, id, 0);
            if (!response.Successful())
            {
                var statusMessage = this.RenderPartialViewToString("_Status", new StatusResult(false, "Ошибка, некорректные атрибуты"));
                var partial = this.RenderPartialViewToString("_Branches", hero);
                return ReturnJson(partial, statusMessage);
            }

            hero = response.Object;
            hero.SetStatus(HeroGenStatus.Traits);
            SaveHeroToCookies(hero);
            return Traits();
        }

        public JsonResult Traits()
        {
            var hero = GetHeroFromCookies();
            return ReturnJson(GetTraitsPartial(hero));
        }

        public JsonResult ChooseTrait(int id)
        {
            var hero = GetHeroFromCookies();
            var response = _traitService.AssignTraitToHero(hero, id);
            if (response.Successful())
            {
                hero = response.Object;
                hero.SetStatus(HeroGenStatus.Abilities);
                SaveHeroToCookies(hero);
                return ReturnJson(GetTraitsPartial(hero));
            }

            var status = this.RenderPartialViewToString("_Status", new StatusResult(false, "Ошибка, некорректные атрибуты"));
            return ReturnJson(GetTraitsPartial(hero), status);
        }

        public JsonResult ResetTraits()
        {
            var hero = GetHeroFromCookies();
            hero = _traitService.ResetTraitsForHero(hero).Object;
            SaveHeroToCookies(hero);
            return ReturnJson(GetTraitsPartial(hero));
        }

        private string GetTraitsPartial(HeroModel hero)
        {
            var traits = _traitService.GetForHero(hero);
            return this.RenderPartialViewToString("_Traits", traits);
        }
    }
}