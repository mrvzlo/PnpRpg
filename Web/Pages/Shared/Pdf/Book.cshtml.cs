using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pnprpg.DomainService.Helpers;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;
using Pnprpg.WebCore.Enums;
using Pnprpg.WebCore.Helpers;
using Rocket.PdfGenerator;

namespace Pnprpg.WebCore.Pages.Shared.Pdf
{
    public class BookModel : PdfPage
    {
        public bool IsLocal { get; set; }
        public string RootPath { get; set; }
        public AlchemySummary Alchemy { get; set; }
        public List<AbilityDescriptionModel> Abilities { get; set; }
        public List<RaceViewModel> Races { get; set; }
        public List<BranchViewModel> Branches { get; set; }
        public List<TraitModel> Traits { get; set; }
        public List<SkillViewModel> Skills { get; set; }
        public List<MagicSchoolModel> MagicSchools { get; set; }

        private readonly IAlchemyService _alchemyService;
        private readonly IRaceService _raceService;
        private readonly ITraitService _traitService;
        private readonly ISkillService _skillService;
        private readonly IMagicService _magicService;
        private readonly IAbilityService _abilityService;
        private readonly IBranchService _branchService;

        public BookModel(IPageRenderer pageRenderer, IAlchemyService alchemyService, IRaceService raceService, ITraitService traitService, ISkillService skillService,
            IMagicService magicService, IAbilityService abilityService, IBranchService branchService, IMajorService majorService) : 
            base(pageRenderer, majorService)
        {
            _alchemyService = alchemyService;
            _raceService = raceService;
            _traitService = traitService;
            _skillService = skillService;
            _magicService = magicService;
            _abilityService = abilityService;
            _branchService = branchService;

        }

        public async Task<FileResult> OnGet()
        {
            Setup();
            Converter.Margins = new PageMargins
            {
                Top = 20,
                Bottom = 20
            };
            Converter.PageFooterHtml = "<div style='text-align: center'><b class='page'></b></div>";
            return await LoadPdf(Converter, SitePages.SharedPdfBook, FileType.Book, this);
        }

        private void Setup()
        {
            var url = HttpContext.Request.GetDisplayUrl();
            IsLocal = url.Contains("localhost");
            RootPath = url.Remove(url.IndexOf("Shared"));
            Abilities = _abilityService.GetAll<AbilityDescriptionModel>().ToList();
            Races = _raceService.GetAll().ToList();
            Branches = _branchService.GetAllWithPerks();
            Traits = _traitService.GetAll().ToList();
            Skills = _skillService.GetAll().ToList();
            MagicSchools = _magicService.GetAllSchools().ToList();
            Alchemy = _alchemyService.GetSummary();
        }
    }
}
