using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Boot.Enums;
using Boot.Models.JsonModels;
using Newtonsoft.Json;

namespace Boot.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index() => View();

        public ActionResult Magic()
        {
            var list = GetJsonFromFile<List<MagicSchoolGroup>>(FileType.MagicSchools);
            return View(list);
        }
    }
}