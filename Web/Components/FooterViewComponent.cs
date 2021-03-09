using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Pnprpg.DomainService.IServices;

namespace Pnprpg.WebCore.Components
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly IMajorService _majorService;

        public FooterViewComponent(IMajorService majorService)
        {
            _majorService = majorService;
        }
        public Task<ViewViewComponentResult> InvokeAsync(bool publicPage = true)
        {
            var list = _majorService.GetAllActive().ToList();
            return Task.FromResult(View("Footer", list));
        }
    }
}
