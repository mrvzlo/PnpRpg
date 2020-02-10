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
            var reagents = GetJsonFromFile<List<SymbolInfo>>(FileType.Reagents);
            var processes = GetJsonFromFile<List<SymbolInfo>>(FileType.Processes);
            ViewBag.Reagents = reagents.Select(x => x.ToSelectListItem()).ToList();
            ViewBag.Processes = processes.Select(x => x.ToSelectListItem()).ToList();
            return View();
        }

        public PartialViewResult AlchemyResult(int reagent, int process)
        {
            process %= 4;
            var reactions = GetJsonFromFile<List<Reaction>>(FileType.Reactions);

            var reaction = reactions.Single(x => x.reagent == reagent && x.process == process);
            string model;
            if (reaction.transmute)
            {
                var reagents = GetJsonFromFile<List<SymbolInfo>>(FileType.Reagents);
                model = reagents.Single(x => x.id == reaction.result).ToString();
            }
            else
            {
                var potions = GetJsonFromFile<List<Potion>>(FileType.Potions);
                model = potions.Single(x => x.id == reaction.result).name;
            }

            return PartialView("_ReactionResult", model);
        }

        public JsonResult Random()
        {
            var potions = GetJsonFromFile<List<Potion>>(FileType.Potions);
            var r = new Random().Next(potions.Count);
            var potion = potions.Single(x => x.id == r).name;
            var partial = this.RenderPartialViewToString("_RandomResult", potion);
            return Json(new { partial }, JsonRequestBehavior.AllowGet);
        }
    }
}