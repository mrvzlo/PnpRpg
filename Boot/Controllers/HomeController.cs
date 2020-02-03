using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Boot.Enums;
using Boot.Models.JsonModels;

namespace Boot.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index() => View();

        public ActionResult Perks()
        {
            var list = GetJsonFromFile<List<Perk>>(FileType.Perks);
            ViewBag.MaxLevel = list.Max(x => x.requirements.Single(y => y.type == RequirementType.Level).value);
            return View(list);
        }

        public ActionResult Magic()
        {
            var list = GetJsonFromFile<List<MagicSchoolGroup>>(FileType.MagicSchools);
            return View(list);
        }
    }
}