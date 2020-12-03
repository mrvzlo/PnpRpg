using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Pnprpg.Domain.Services;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;
using Pnprpg.WebCore.Enums;
using Pnprpg.WebCore.Helpers;
using Rocket.PdfGenerator;

namespace Pnprpg.WebCore.Pages.Shared.Pdf
{
    public class HeroSheetModel : PdfPage
    {
        public HeroModel Hero { get; set; }
        public string RootPath { get; set; }

        private readonly ICoreLogic _coreLogic;
        private readonly IConfiguration _configuration;
        private readonly ISkillService _skillService;

        public HeroSheetModel(IPageRenderer pageRenderer, ICoreLogic coreLogic, IConfiguration configuration, ISkillService skillService) : base(pageRenderer)
        {
            _coreLogic = coreLogic;
            _configuration = configuration;
            _skillService = skillService;
        }

        public async Task<FileResult> OnGet(bool cookie = false)
        {
            var url = HttpContext.Request.GetDisplayUrl();
            RootPath = url.Remove(url.IndexOf("Shared"));
            Converter.Orientation = PageOrientation.Landscape;
            if (cookie)
            {
                var encoded = GetCookie(CookieType.Hero);
                Hero = _coreLogic.DecodeHero(encoded, _configuration["Version"]);
            }
            Hero ??= _coreLogic.CreateHero(Company.Fantasy);
            Hero.Skills = _skillService.GetHeroSkillGroup(Hero);
            return await LoadPdf(Converter, SitePages.SharedPdfHeroSheet, this, cookie);
        }
    }
}
