using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pnprpg.DomainService.IServices;
using Pnprpg.WebCore.Enums;
using Pnprpg.WebCore.Helpers;

namespace Pnprpg.WebCore.Pages.Shared.Pdf
{
    public class MagicSheetModel : PdfPage
    {
        public MagicSheetModel(IPageRenderer pageRenderer, IMajorService majorService) : base(pageRenderer, majorService)
        {
        }

        public async Task<FileResult> OnGet()
        {
            ViewData["Title"] = "Лист заклинаний";
            return await LoadPdf(Converter, SitePages.SharedPdfMagicSheet, FileType.MagicSheet, this);
        }
    }
}
