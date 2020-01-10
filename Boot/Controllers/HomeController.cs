using System.Web.Mvc;

namespace Boot.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index() => View("Index");

        public ActionResult Magic() => View();
    }
}