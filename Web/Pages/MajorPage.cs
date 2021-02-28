using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;
using Pnprpg.WebCore.Enums;

namespace Pnprpg.WebCore.Pages
{
    public class MajorPage : BasePage
    {
        [ViewData]
        public MajorShortModel Major { get; set; }

        protected readonly IMajorService MajorService;

        public MajorPage(IMajorService majorService)
        {
            MajorService = majorService;
            // get Major from cache
        }

        protected void PrepareMajor(MajorType major)
        {
            Major = MajorService.GetShortModel((int)major);
        }
    }
}
