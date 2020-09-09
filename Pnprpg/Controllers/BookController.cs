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

        //todo news, books, versions

        public ActionResult Index()
        {
            Converter.Margins.Top = 20;
            Converter.Margins.Bottom = 20;
            Converter.PageFooterHtml = "<div style='text-align: center'><span class='page'></span></div>";
            return LoadPdf(Converter, FileNames.RuleBook, "Index");
        }

        public ActionResult HeroSheets() => View();

        public ActionResult MainSheet()
        {
            Converter.Orientation = PageOrientation.Landscape;
            var hero = _coreLogic.CreateHero(Company.Fantasy);
            hero.Skills = _skillService.GetHeroSkillGroup(hero);
            return LoadPdf(Converter, FileNames.CharacterSheet, "HeroInfo/MainSheet", hero);
        }

        public ActionResult MagicSheet()
        {
            return LoadPdf(Converter, FileNames.MagicBook, "MagicSheet");
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

        public PartialViewResult Branches()
        {
            var list = _branchService.GetAll().ToList();
            return PartialView("_Branches", list);
        }

        public PartialViewResult Traits()
        {
            var list = _traitService.GetAll().ToList();
            return PartialView("_Traits", list);
        }

        public PartialViewResult Skills()
        {
            var list = _skillService.GetAll().ToList();
            return PartialView("_Skills", list);
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

        public string HeroSheetStyle()
        {
            var path = Url.Content("~/Content/HeroSheet.css");
            path = Server.MapPath(path);
            return System.IO.File.ReadAllText(path);
        }
    }
}