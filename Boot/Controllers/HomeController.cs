using System.Collections.Generic;
using System.Web.Mvc;
using Boot.Enums;
using Boot.Models.JsonModels;
using Newtonsoft.Json;

namespace Boot.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index() => View("Index");

        public ActionResult Magic()
        {
            var json = GetJsonFromFile(FileType.MagicSchools);
            var list = JsonConvert.DeserializeObject<MagicSchoolGroupList>(json);
            return View(list);
        }
    }
}