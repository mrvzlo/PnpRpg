using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Boot.Enums;
using Boot.Helpers;
using Boot.Models.JsonModels;

namespace Boot.Controllers
{
    public class AlchemyController : BaseController
    {

        public ActionResult Index()
        {
            var reagents = GetJsonFromFile<List<SymbolInfo>>(FileNames.Reagents);
            var processes = GetJsonFromFile<List<SymbolInfo>>(FileNames.Processes);
            ViewBag.Reagents = reagents.Select(x => x.ToSelectListItem()).ToList();
            ViewBag.Processes = processes.Select(x => x.ToSelectListItem()).ToList();
            return View();
        }

        public PartialViewResult AlchemyResult(int reagent, int process)
        {
            process %= 4;
            var reactions = GetJsonFromFile<List<Reaction>>(FileNames.Reactions);

            var reaction = reactions.Single(x => x.reagent == reagent && x.process == process);

            var potions = GetJsonFromFile<List<Potion>>(FileNames.Potions);
            var model = potions.Single(x => x.id == reaction.result).name;

            return PartialView("_ReactionResult", model);
        }

        public JsonResult Random()
        {
            var potions = GetJsonFromFile<List<Potion>>(FileNames.Potions);
            var r = new Random().Next(potions.Count);
            var potion = potions[r].name;
            var partial = this.RenderPartialViewToString("_ReactionResult", potion);
            return Json(new { partial }, JsonRequestBehavior.AllowGet);
        }
    }
}