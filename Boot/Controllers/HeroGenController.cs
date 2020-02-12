using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.WebSockets;
using Boot.Enums;
using Boot.Helpers;
using Boot.Models;
using Boot.Models.JsonModels;

namespace Boot.Controllers
{
    public class HeroGenController : BaseController
    {
        public ActionResult Index(Status status = Status.Chaos)
        {
            ViewBag.Status = status;
            return View(GetHeroFromCookies());
        }

        public JsonResult GetChaosChoice()
        {
            var partial = this.RenderPartialViewToString("_Chaos");
            return ReturnJson(partial, GetUrl(Status.Chaos));
        }

        public JsonResult GetHeroModel(ChaosLevel level)
        {
            var heroModel = new HeroModel(level);
            SaveHeroToCookies(heroModel);
            var partial = this.RenderPartialViewToString("_StatEdit", heroModel);
            return ReturnJson(partial, GetUrl(Status.Stats));
        }

        public JsonResult ChangeStat(StatType stat, int value)
        {
            var hero = GetHeroFromCookies();
            hero.IncStat((int)stat, value);
            SaveHeroToCookies(hero);
            var partial = this.RenderPartialViewToString("_StatEdit", hero);
            return ReturnJson(partial, GetUrl(Status.Stats));
        }

        public PartialViewResult RacesDropdown(int chosen)
        {
            var races = GetJsonFromFile<List<Race>>(FileType.Races);
            foreach (var race in races) 
                race.Chosen = race.id == chosen;
            return PartialView("_RacesDropdown", races);
        }

        public JsonResult PickRace(int id)
        {
            var races = GetJsonFromFile<List<Race>>(FileType.Races);
            var hero = GetHeroFromCookies();
            var partial = this.RenderPartialViewToString("_StatEdit", hero);
            var newRace = races.Single(x => x.id == id);
            var oldRace = races.Single(x => x.id == hero.Race);
            var success = hero.ChangeRace(oldRace, newRace);
            if (success)
            {
                partial = this.RenderPartialViewToString("_StatEdit", hero);
                SaveHeroToCookies(hero);
                return ReturnJson(partial, GetUrl(Status.Stats));
            }

            var status = this.RenderPartialViewToString("_Status", 
                new StatusResult(false, "Ошибка, некорректные атрибуты"));
            return ReturnJson(partial, GetUrl(Status.Stats), status);
        }

        #region Traits

        public ActionResult TraitsPage()
        {
            var hero = GetHeroFromCookies();
            return PartialView("_Traits", GetTraits(hero));
        }

        public JsonResult Traits()
        {
            var hero = GetHeroFromCookies();
            var partial = this.RenderPartialViewToString("_Traits", GetTraits(hero));
            return ReturnJson(partial, GetUrl(Status.Traits));
        }

        public List<Trait> GetTraits(HeroModel hero)
        {
            var traits = GetJsonFromFile<List<Trait>>(FileType.Traits);
            foreach (var trait in traits)
                trait.Chosen = hero.Traits.Contains(trait.id);

            return traits;
        }

        public JsonResult ChooseTrait(int id)
        {
            var hero = GetHeroFromCookies();
            hero.AddTrait(id);
            SaveHeroToCookies(hero);
            var partial = this.RenderPartialViewToString("_Traits", GetTraits(hero));
            return ReturnJson(partial, GetUrl(Status.Traits));
        }

        public JsonResult ResetTraits()
        {
            var hero = GetHeroFromCookies();
            hero.ResetTraits();
            SaveHeroToCookies(hero);
            var partial = this.RenderPartialViewToString("_Traits", GetTraits(hero));
            return ReturnJson(partial, GetUrl(Status.Traits));
        }

        public PartialViewResult GetTraitsNames(List<int> ids)
        {
            var traits = GetJsonFromFile<List<Trait>>(FileType.Traits);
            var names = ids.Where(x => x >= 0).Select(x => traits[x].name).ToList();
            return PartialView("_List", names);
        }

        #endregion

        #region Skills

        public ActionResult Skills() => View();

        public PartialViewResult SkillGroupList(bool editable)
        {
            var list = new SkillGroupList { Groups = GetJsonFromFile<List<SkillGroup>>(FileType.Skills) };
            var hero = editable ? GetHeroFromCookies() : null;

            if (hero != null)
                UpdateSkillsForHero(hero, ref list);

            return PartialView("_SkillList", list);
        }
        public JsonResult GetSkills()
        {
            var hero = GetHeroFromCookies();
            var partial = this.RenderPartialViewToString("_SkillEdit", hero);
            return ReturnJson(partial, GetUrl(Status.Skills));
        }

        public JsonResult AddSkill(int group, int id)
        {
            var hero = GetHeroFromCookies();
            var list = new SkillGroupList { Groups = GetJsonFromFile<List<SkillGroup>>(FileType.Skills) };
            var skill = list.Groups[group].skills[id % 10];
            hero.AddSkill(skill);
            SaveHeroToCookies(hero);
            UpdateSkillsForHero(hero, ref list);
            list.Selected = group;
            var partial = this.RenderPartialViewToString("_SkillList", list);
            return ReturnJson(partial, GetUrl(Status.Skills));
        }

        public JsonResult ResetSkills()
        {
            var hero = GetHeroFromCookies();
            var list = new SkillGroupList { Groups = GetJsonFromFile<List<SkillGroup>>(FileType.Skills) };
            hero.ResetSkills();
            SaveHeroToCookies(hero);
            UpdateSkillsForHero(hero, ref list);
            var partial = this.RenderPartialViewToString("_SkillList", list);
            return ReturnJson(partial, GetUrl(Status.Skills));
        }

        public PartialViewResult GetSkillsNames(Dictionary<int, int> ids)
        {
            var skillList = GetJsonFromFile<List<SkillGroup>>(FileType.Skills)
                .SelectMany(x => x.skills).ToList();
            var skills = skillList.Where(x => ids.ContainsKey(x.Id)).ToList();
            foreach (var skill in skills)
                skill.Level = ids[skill.Id];
            return PartialView("_List", skills.Select(x => x.ToString()).ToList());
        }

        #endregion

        public JsonResult Result()
        {
            var partial = this.RenderPartialViewToString("_Result", GetHeroFromCookies());
            return ReturnJson(partial, GetUrl(Status.Result));
        }

        #region private

        private HeroModel GetHeroFromCookies()
        {
            var cookie = GetCookie(CookieType.Hero);
            if (string.IsNullOrEmpty(cookie)) return null;
            var hero = new HeroModel(cookie);
            var list = new SkillGroupList { Groups = GetJsonFromFile<List<SkillGroup>>(FileType.Skills) };
            hero.RaceStr = GetJsonFromFile<List<Race>>(FileType.Races).Single(x => x.id == hero.Race).name;
            hero.UsedSkillPoints = CoreLogic.CalculateSkillPoints(hero, list);
            return hero;
        }

        private void SaveHeroToCookies(HeroModel model) => SaveCookie(CookieType.Hero, model.ToString());

        private string GetUrl(Status status) => Url.Action("Index", new { status });

        private void UpdateSkillsForHero(HeroModel hero, ref SkillGroupList list)
        {
            list.Editable = true;
            list.FreePoints = hero.FreeSkillPoints();
            foreach (var skill in list.Groups.SelectMany(group => group.skills))
            {
                skill.CanInc = hero.CanIncSkill(skill);
                skill.Level = hero.Skills[skill.Id];
            }
        }

        #endregion
    }
}