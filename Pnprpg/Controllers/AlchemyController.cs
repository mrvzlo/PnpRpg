using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;
using Pnprpg.Web.Helpers;

namespace Pnprpg.Web.Controllers
{
    public class AlchemyController : BaseController
    {
        private readonly IAlchemyService _alchemyService;

        public AlchemyController(IAlchemyService alchemyService)
        {
            _alchemyService = alchemyService;
        }

        public ActionResult Index()
        {
            ViewBag.Reagents = ToSelectList(_alchemyService.GetAllReagents().ToList());
            ViewBag.Processes = ToSelectList(_alchemyService.GetAllProcesses().ToList());

            return View();
        }

        public PartialViewResult AlchemyResult(ReactionModel reaction)
        {
            var potion = _alchemyService.GetPotionByReaction(reaction);
            return PartialView("_ReactionResult", potion);
        }

        public JsonResult Random()
        {
            var potion = _alchemyService.GetRandomPotion();
            var partial = this.RenderPartialViewToString("_ReactionResult", potion);
            return Json(new { partial }, 0);
        }

        private List<SelectListItem> ToSelectList(List<AlchemySymbolModel> list)
        {
            return list.Select(x => new SelectListItem
            {
                Text = $"{x.Symbol} {x.Name}",
                Value = x.Value.ToString()
            }).ToList();
        }
    }
}