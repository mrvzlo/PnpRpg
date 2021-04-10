using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;
using Pnprpg.WebCore.Enums;
using Pnprpg.WebCore.Helpers;
using Rocket.PdfGenerator;

namespace Pnprpg.WebCore.Pages.Shared.Major
{
    public class HeroSheetModel : PdfPage
    {
        public HeroModel Hero { get; set; }
        public string RootPath { get; set; }

        private readonly ICoreLogic _coreLogic;
        private readonly IConfiguration _configuration;
        private readonly ISkillService _skillService;

        public HeroSheetModel(IPageRenderer pageRenderer, ICoreLogic coreLogic, IConfiguration configuration, 
            ISkillService skillService, IMajorService majorService) : base(pageRenderer, majorService)
        {
            _coreLogic = coreLogic;
            _configuration = configuration;
            _skillService = skillService;
        }

        public async Task<FileResult> OnGet(MajorType major, bool getFromCookies = false)
        {
            var url = HttpContext.Request.GetDisplayUrl();
            RootPath = url.Remove(url.IndexOf("shared"));
            Converter.Orientation = PageOrientation.Landscape;
            if (getFromCookies)
            {
                var encoded = HttpContext.GetCookie(CookieType.Hero);
                Hero = _coreLogic.DecodeHero(encoded, major);
            }

            if (Hero == null)
            {
                getFromCookies = false;
                Hero = _coreLogic.CreateHero(major);
            }
            
            var fileType = getFromCookies ? FileType.FilledHeroSheet : FileType.BaseHeroSheet;

            Hero.Skills = _skillService.GetHeroSkillGroup(Hero);
            return await LoadPdf(Converter, SitePages.SharedMajorHeroSheet, fileType, this, getFromCookies);
        }
    }
}
