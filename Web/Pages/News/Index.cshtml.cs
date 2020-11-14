using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pnprpg.DomainService.IServices;

namespace Pnprpg.WebCore.Pages.News
{
    public class IndexModel : PageModel
    {
        private readonly INewsService _newsService;

        public IndexModel(INewsService newsService)
        {
            _newsService = newsService;
        }

        public void OnGet()
        {
        }

        public PartialViewResult OnGetGrid()
        {
            var list = _newsService.GetAll();
            return Partial(SitePages.News_Grid, list);
        }
    }
}
