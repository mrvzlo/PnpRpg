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

        public ActionResult Index()
        {
            var list = _newsService.GetAll();
            return View(list);
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
            return Edit(model.Id);
        }
    }
}