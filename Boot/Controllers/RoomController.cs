using System.Web.Mvc;
using Boot.Helpers;

namespace Boot.Controllers
{
    [Authorize]
    public class RoomController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}