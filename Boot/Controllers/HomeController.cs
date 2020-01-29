using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Boot.Enums;
using Boot.Models.JsonModels;
using Newtonsoft.Json;

namespace Boot.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index() => View();

        public ActionResult Alchemy()
        {
            var reagents = GetJsonFromFile<List<SymbolInfo>>(FileType.Reagents);
            var processes = GetJsonFromFile<List<SymbolInfo>>(FileType.Processes);
            ViewBag.Reagents = reagents.Select(x => x.ToSelectListItem()).ToList();
            ViewBag.Processes = processes.Select(x => x.ToSelectListItem()).ToList();
            return View();
        }

        public PartialViewResult AlchemyResult(int reagent, int process)
        {
            var reactions = GetJsonFromFile<List<Reaction>>(FileType.Reactions);
            var reagents = GetJsonFromFile<List<SymbolInfo>>(FileType.Reagents);

            process %= 4;
            var reaction = reactions.Single(x => x.reagent == reagent && x.process == process);
            var model =  reaction.transmute 
                ? reagents.Single(x => x.id == reaction.transmuteTo).ToString() 
                : reaction.result;
            return PartialView("_ReactionResult", model);
        }

        public ActionResult Magic()
        {
            var list = GetJsonFromFile<List<MagicSchoolGroup>>(FileType.MagicSchools);
            return View(list);
        }
    }
}