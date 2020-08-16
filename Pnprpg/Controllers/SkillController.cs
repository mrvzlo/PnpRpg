using System.Web.Mvc;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.Web.Helpers;

namespace Pnprpg.Web.Controllers
{
    public class SkillController : BaseGenController
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService, ICoreLogic coreLogic) : base(coreLogic)
        {
            _skillService = skillService;
        }

        public ActionResult Skills(string prefix)
        {
            return View();
        }

        public PartialViewResult SkillEdit(string prefix) => PartialView("_SkillEdit", model: prefix);

        public PartialViewResult SkillGroupList(bool editable, string prefix)
        {
            var hero = editable ? GetHeroFromCookies() : null;
            var list = _skillService.GetHeroSkillGroup(hero);
            return PartialView("_SkillList", list);
        }

        public JsonResult SkillEditJson()
        {
            var partial = this.RenderPartialViewToString("_SkillEdit");
            return ReturnJson(partial, GetUrl(Status.Skills));
        }

        public JsonResult AddSkill(int group, int id)
        {
            var hero = GetHeroFromCookies();
            var response = _skillService.UpgradeSkill(hero, id);
            if (response.Successful())
                SaveHeroToCookies(response.Object);
            var list = _skillService.GetHeroSkillGroup(hero);
            list.SelectedGroup = group;
            var partial = this.RenderPartialViewToString("_SkillList", list);
            return ReturnJson(partial, GetUrl(Status.Skills));
        }

        public JsonResult ResetSkills()
        {
            var hero = GetHeroFromCookies();
            hero = _skillService.ResetSkills(hero);
            SaveHeroToCookies(hero);
            var list = _skillService.GetHeroSkillGroup(hero);
            var partial = this.RenderPartialViewToString("_SkillList", list);
            return ReturnJson(partial, GetUrl(Status.Skills));
        }

    }
}