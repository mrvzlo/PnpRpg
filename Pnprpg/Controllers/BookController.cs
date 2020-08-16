using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Pnprpg.DomainService.IServices;
using Pnprpg.Web.Helpers;
using Rotativa;
using Rotativa.Options;

namespace Pnprpg.Web.Controllers
{
    public class BookController : BaseController
    {
        private readonly IWeaponService _weaponService;
        private readonly IAlchemyService _alchemyService;
        private readonly IPerkService _perkService;
        private readonly IRaceService _raceService;
        private readonly ITraitService _traitService;
        private readonly ISkillService _skillService;
        private readonly IMagicService _magicService;
        private readonly IAbilityService _abilityService;

        public BookController(IWeaponService weaponService, IAlchemyService alchemyService, IPerkService perkService, 
            IRaceService raceService, ITraitService traitService, ISkillService skillService, IMagicService magicService, IAbilityService abilityService)
        {
            _weaponService = weaponService;
            _alchemyService = alchemyService;
            _perkService = perkService;
            _raceService = raceService;
            _traitService = traitService;
            _skillService = skillService;
            _magicService = magicService;
            _abilityService = abilityService;
        }

        public ActionResult Index()
        {
            var path = Server.MapPath($"~/App_Data/{FileNames.RuleBook}");
            if (Request.IsLocal)
            {
                var pdf = new ViewAsPdf("Index")
                {
                    PageMargins = new Margins(30, 10, 25, 10),
                    PageSize = Size.A4,
                    PageOrientation = Orientation.Portrait
                };
                SaveRotativa(pdf, path);
            }

            var file = new FileStream(path, FileMode.Open, FileAccess.Read);
            return File(file, "application/pdf");
        }

        public ActionResult WebBook()
        {
            return View("Index");
        }

        public ActionResult DeleteBook()
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
            var file = new FileStream(path, FileMode.Open, FileAccess.Read);
            return File(file, "application/pdf");
        }
    }
}