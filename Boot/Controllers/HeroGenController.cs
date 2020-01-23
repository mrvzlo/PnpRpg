using System.Web.Mvc;
using Boot.Enums;
using Boot.Helpers;
using Boot.Models;

namespace Boot.Controllers
{
    public class HeroGenController : BaseController
    {
        public ActionResult Index(Status status = Status.Chaos)
        {
            ViewBag.Status = status;
            return View(GetHeroFromCookies());
        }
        public ActionResult Skills() => View();

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

        public JsonResult GetSkills()
        {
            var hero = GetHeroFromCookies();
            var partial = this.RenderPartialViewToString("_SkillEdit", hero);
            return ReturnJson(partial, GetUrl(Status.Skills));
        }

        private HeroModel GetHeroFromCookies() => new HeroModel(GetCookie(CookieType.Hero));

        private void SaveHeroToCookies(HeroModel model) => SaveCookie(CookieType.Hero, model.ToString());

        public PartialViewResult SkillGroup(int id, bool editable)
        {
            var path = Server.MapPath($"~/App_Data/{Files.Skills.Description()}");
            var hero = editable ? GetHeroFromCookies() : null;
            var model = new SkillGroupModel(id, path, editable, hero);
            return PartialView("_SkillGroup", model);
        }

        public JsonResult AddSkill(string name)
        {
            var hero = GetHeroFromCookies();
            hero.AddSkill();
        }

        public JsonResult ResetSkills()
        {
            var hero = GetHeroFromCookies();
            hero.ResetSkills();
            SaveHeroToCookies(hero);
            var partial = this.RenderPartialViewToString("_SkillList", true);
            return ReturnJson(partial, GetUrl(Status.Skills));
        }

        private string GetUrl(Status status) => Url.Action("Index", new {status});
    }
}