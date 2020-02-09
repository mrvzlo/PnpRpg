using System.Web.Mvc;

namespace Boot.Controllers
{
    public class RoomController : BaseController
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}