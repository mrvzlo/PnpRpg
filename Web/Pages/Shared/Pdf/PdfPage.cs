using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pnprpg.DomainService.IServices;
using Pnprpg.WebCore.Enums;
using Pnprpg.WebCore.Helpers;
using Pnprpg.WebCore.Pages.Major;
using Rocket.PdfGenerator;

namespace Pnprpg.WebCore.Pages.Shared.Pdf
{
    public class PdfPage : MajorPage
    {
        protected readonly HtmlToPdfConverter Converter;
        private readonly IPageRenderer _pageRenderer;

        public PdfPage(IPageRenderer pageRenderer, IMajorService majorService) : base(majorService)
        {
            _pageRenderer = pageRenderer;
            Converter = new HtmlToPdfConverter { Size = PageSize.A4 };
        }

        protected async Task<FileResult> LoadPdf(HtmlToPdfConverter generator, string pageName, FileType fileType, PageModel model, bool rewrite = false)
        {
            pageName = pageName.Replace("/Shared/", "");
            await CheckPdf(generator, pageName, fileType, model, rewrite);
            var file = new FileStream(Path(fileType), FileMode.Open, FileAccess.Read);
            return File(file, "application/pdf");
        }

        private async Task CheckPdf(HtmlToPdfConverter generator, string pageName, FileType fileType, PageModel model, bool rewrite)
        {
            if (rewrite || !System.IO.File.Exists(Path(fileType)) || HttpContext.Request.Host.Value.Contains("localhost"))
                await SavePdf(generator, pageName, fileType, model);
        }

        private async Task SavePdf(HtmlToPdfConverter generator, string pageName, FileType fileType, PageModel model)
        {
            var pdfBytes = await GeneratePdf(generator, pageName, model);
            var fileStream = new FileStream(Path(fileType), FileMode.Create, FileAccess.Write);
            fileStream.Write(pdfBytes, 0, pdfBytes.Length);
            fileStream.Close();
        }

        private async Task<byte[]> GeneratePdf(HtmlToPdfConverter generator, string view, PageModel model)
        {
            var viewAsString = await _pageRenderer.RenderPartialToStringAsync(view, model);
            return generator.GeneratePdf(viewAsString);
        }

        private string Path(FileType src) => $"wwwroot/pdf/{src}.pdf";
    }
}
