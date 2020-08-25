using System.IO;
using System.Linq;
using System.Web.Mvc;
using NReco.PdfGenerator;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;
using Pnprpg.Web.Helpers;

namespace Pnprpg.Web.Controllers
{
    public class BookController : BaseController
    {
        private readonly IAlchemyService _alchemyService;
        private readonly IPerkService _perkService;
        private readonly IRaceService _raceService;
        private readonly ITraitService _traitService;
        private readonly ISkillService _skillService;
        private readonly IMagicService _magicService;
        private readonly IAbilityService _abilityService;
        private readonly ICoreLogic _coreLogic;
        private readonly IBranchService _branchService;

        public BookController(IAlchemyService alchemyService, IPerkService perkService, 
            IRaceService raceService, ITraitService traitService, ISkillService skillService, IMagicService magicService, IAbilityService abilityService, ICoreLogic coreLogic, IBranchService branchService)
        {
            _alchemyService = alchemyService;
            _perkService = perkService;
            _raceService = raceService;
            _traitService = traitService;
            _skillService = skillService;
            _magicService = magicService;
            _abilityService = abilityService;
            _coreLogic = coreLogic;
            _branchService = branchService;
        }

        public ActionResult Index()
        {
            var generator = new HtmlToPdfConverter { };
            var path = Server.MapPath($"~/App_Data/{FileNames.RuleBook}");
            if (!System.IO.File.Exists(path) || Request.IsLocal) 
                SavePdf(generator, "Index", path);

            var file = new FileStream(path, FileMode.Open, FileAccess.Read);
            return File(file, "application/pdf");
        }

        public ActionResult UpdateBook()
        {
            var path = Server.MapPath($"~/App_Data/{FileNames.RuleBook}");
            System.IO.File.Delete(path);
            return RedirectToAction("Index");
        }

        public PartialViewResult Abilities()
        {
            var list = _abilityService.GetAll<AbilityDescriptionModel>();
            return PartialView("_Stats", list);
        }

        public PartialViewResult Races()
        {
            var list = _raceService.GetAll();
            return PartialView("_Races", list);
        }

        public PartialViewResult Traits()
        {
            var list = _traitService.GetAll();
            return PartialView("_Traits", list);
        }

        public PartialViewResult Skills()
        {
            var list = _skillService.GetAll();
            return PartialView("_Skills", list.ToList());
        }

        public PartialViewResult Spells()
        {
            var list = _magicService.GetAll();
            return PartialView("_Spells", list);
        }

        public PartialViewResult Perks()
        {
            var list = _perkService.GetAll();
            return PartialView("_Perks", list);
        }

        public PartialViewResult Alchemy()
        {
            var summary = _alchemyService.GetSummary();
            return PartialView("_Alchemy", summary);
        }

        public PartialViewResult ShortSkillList()
        {
            var list = _skillService.GetAll();
            return PartialView("_ShortSkillList", list);
        }

        public ActionResult HeroSheet(bool clean = false)
        {
            var generator = new HtmlToPdfConverter { Orientation = PageOrientation.Landscape };
            var path = Server.MapPath($"~/App_Data/{FileNames.CharacterSheet}");
            if (!System.IO.File.Exists(path) || Request.IsLocal)
            {
                var hero = _coreLogic.CreateHero(ChaosLevel.Null);
                if (clean)
                    return View("HeroSheet", hero);
                SavePdf(generator, "HeroSheet", path, hero);
            }

            var file = new FileStream(path, FileMode.Open, FileAccess.Read);
            return File(file, "application/pdf");
        }

        public string HeroSheetStyle()
        {
            var path = Url.Content("~/Content/HeroSheet.css");
            path = Server.MapPath(path);
            return System.IO.File.ReadAllText(path);
        }
    }
}