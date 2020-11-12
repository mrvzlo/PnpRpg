using System.Collections.Generic;
using System.Web.Mvc;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.Web.Controllers
{
    public class NewsController : BaseController
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        public ActionResult Index() => View();

        public PartialViewResult NewsGrid()
        {
            var list = _newsService.GetAll();
            return PartialView("_NewsGrid", list);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            var model = _newsService.GetForEdit(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken, Authorize(Roles = "Admin")]
        public ActionResult Edit(NewsEditModel model)
        {
            _newsService.Save(model);
            return RedirectToAction("Index", "Home");
        }
    }
}