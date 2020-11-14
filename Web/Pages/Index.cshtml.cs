using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.WebCore.Pages
{
    public class IndexModel : PageModel
    {
        public string Version { get; set; }
        public NewsViewModel LatestNews { get; set; }

        private readonly IConfiguration _configuration;
        private readonly INewsService _newsService;

        public IndexModel(IConfiguration configuration, INewsService newsService)
        {
            _configuration = configuration;
            _newsService = newsService;
        }

        public void OnGet()
        {
            LatestNews = _newsService.GetLatest();
            Version = _configuration["Version"];
            ViewData["HideTitle"] = true;
        }
    }
}
