using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pnprpg.WebCore.Helpers;

namespace Pnprpg.WebCore.Pages.Shared.Pdf
{
    public class MagicSheetModel : PdfPage
    {
        public MagicSheetModel(IPageRenderer pageRenderer) : base(pageRenderer)
        {
        }

        public async Task<FileResult> OnGet()
        {
            ViewData["Title"] = "Лист заклинаний";
            return await LoadPdf(Converter, SitePages.SharedPdfMagicSheet, this);
        }
    }
}
