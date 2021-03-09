using Microsoft.AspNetCore.Mvc;
using Pnprpg.DomainService.IServices;
using Pnprpg.WebCore.Helpers;

namespace Pnprpg.WebCore.Pages.Major
{
    public class MajorPage : BasePage
    {
        [ViewData]
        public string MajorColor { get; set; }

        protected readonly IMajorService MajorService;

        public MajorPage(IMajorService majorService)
        {
            MajorService = majorService;
        }

        private void PrepareMajor(int major)
        {
            MajorColor = MajorService.GetShortModel(major).Color;
        }
    }
}
