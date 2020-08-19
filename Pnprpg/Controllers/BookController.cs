using System.IO;
using System.Linq;
using System.Web.Mvc;
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

        public BookController(IAlchemyService alchemyService, IPerkService perkService, 
            IRaceService raceService, ITraitService traitService, ISkillService skillService, IMagicService magicService, IAbilityService abilityService, ICoreLogic coreLogic)
        {
            _alchemyService = alchemyService;
            _perkService = perkService;
            _raceService = raceService;
            _traitService = traitService;
            _skillService = skillService;
            _magicService = magicService;
            _abilityService = abilityService;
            _coreLogic = coreLogic;
        }

        public ActionResult Index()
        {
            var path = Server.MapPath($"~/App_Data/{FileNames.RuleBook}");
            if (!System.IO.File.Exists(path) || Request.IsLocal) 
                SavePdf("Index", path);

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
            var list = _abilityService.GetAllWithDescription();
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
            var list = _skillService.GetAllBranches();
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
            var list = _skillService.GetAllSkills();
            return PartialView("_ShortSkillList", list);
        }

        public ActionResult HeroSheet()
        {
            var path = Server.MapPath($"~/App_Data/{FileNames.CharacterSheet}");
            if (!System.IO.File.Exists(path) || Request.IsLocal)
            {
                var hero = _coreLogic.CreateHero(ChaosLevel.Null);
                SavePdf("HeroSheet", path, hero);
            }

            var file = new FileStream(path, FileMode.Open, FileAccess.Read);
            return File(file, "application/pdf");
        }
    }
}