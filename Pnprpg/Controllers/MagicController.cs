using System.IO;
using System.Web.Mvc;
using Pnprpg.DomainService.IServices;
using Pnprpg.Web.Helpers;

namespace Pnprpg.Web.Controllers
{
    public class MagicController : BaseController
    {
        private readonly IMagicService _magicSchoolService;

        public MagicController(IMagicService magicSchoolService)
        {
            _magicSchoolService = magicSchoolService;
        }

        public ActionResult Index()
        {
            var list = _magicSchoolService.GetAll();
            return View(list);
        }

        public JsonResult RandomSpell()
        {
            var spell = _magicSchoolService.GetRandomSpell();
            var partial = this.RenderPartialViewToString("_RandomSpell", spell);
            return Json(new { partial }, JsonRequestBehavior.AllowGet);
        }
    }
}