using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.Helpers;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;
using Pnprpg.WebCore.Enums;
using Pnprpg.WebCore.Helpers;

namespace Pnprpg.WebCore.Pages
{
    public class IndexModel : PageModel
    {
        [ViewData]
        public string Version { get; set; }
        public NewsViewModel LatestNews { get; set; }
        public List<MajorFullModel> Majors { get; set; }

        private readonly IConfiguration _configuration;
        private readonly INewsService _newsService;
        private readonly IMajorService _majorService;

        public IndexModel(IConfiguration configuration, INewsService newsService, IMajorService majorService)
        {
            _configuration = configuration;
            _newsService = newsService;
            _majorService = majorService;
        }

        public ActionResult OnGet()
        {
            LatestNews = _newsService.GetLatest();
            Version = _configuration["Version"];
            Majors = _majorService.GetAllActive().ToList();
            return Page();
        }
    }
}
