using System.IO;
using System.Web.Mvc;
using Pnprpg.DomainService.IServices;
using Pnprpg.Web.Helpers;

namespace Pnprpg.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IWeaponService _weaponService;
        private readonly IPerkService _perkService;
        private readonly INewsService _newsService;

        public HomeController(IPerkService perkService, IWeaponService weaponService, INewsService newsService)
        {
            _perkService = perkService;
            _weaponService = weaponService;
            _newsService = newsService;
        }

        public ActionResult Index()
        {
            var model = _newsService.GetLatest();
            return View(model);
        }

        public ActionResult Perks()
        {
            var list = _perkService.GetAllSimplified();
            return View(list);
        }

        public ActionResult Weaponry()
        {
            var list = _weaponService.GetAll();
            return View(list);
        }

        public FileResult CharacterSheet()
        {
            var path = Server.MapPath($"~/App_Data/{FileNames.CharacterSheet}");
            var file = new FileStream(path, FileMode.Open, FileAccess.Read);
            return File(file, "application/pdf");
        }
    }
}