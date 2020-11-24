using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pnprpg.WebCore.Helpers;
using Rocket.PdfGenerator;

namespace Pnprpg.WebCore.Pages.Shared.Pdf
{
    public class PdfPage : BasePage
    {
        protected readonly HtmlToPdfConverter Converter;
        private readonly IPageRenderer _pageRenderer;

        public PdfPage(IPageRenderer pageRenderer)
        {
            _pageRenderer = pageRenderer;
            Converter = new HtmlToPdfConverter { Size = PageSize.A4 };
        }

        protected async Task<FileResult> LoadPdf(HtmlToPdfConverter generator, string pageName, PageModel model)
        {
            pageName = pageName.Replace("/Shared/", "");
            await CheckPdf(generator, pageName, model);
            var file = new FileStream(Path(pageName), FileMode.Open, FileAccess.Read);
            return File(file, "application/pdf");
        }

        private async Task CheckPdf(HtmlToPdfConverter generator, string pageName, PageModel model)
        {
            if (!System.IO.File.Exists(Path(pageName)) || HttpContext.Request.Host.Value.Contains("localhost"))
                await SavePdf(generator, pageName, model);
        }

        private async Task SavePdf(HtmlToPdfConverter generator, string pageName, PageModel model)
        {
            var pdfBytes = await GeneratePdf(generator, pageName, model);
            var fileStream = new FileStream(Path(pageName), FileMode.Create, FileAccess.Write);
            fileStream.Write(pdfBytes, 0, pdfBytes.Length);
            fileStream.Close();
        }

        private async Task<byte[]> GeneratePdf(HtmlToPdfConverter generator, string view, PageModel model)
        {
            var viewAsString = await _pageRenderer.RenderPartialToStringAsync(view, model);
            return generator.GeneratePdf(viewAsString);
        }

        private string Path(string src) => $"wwwroot/{src}.pdf";
    }
}
