using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using NReco.PdfGenerator;
using Pnprpg.DomainService.Models;
using Pnprpg.Web.Enums;
using Pnprpg.Web.Helpers;

namespace Pnprpg.Web.Controllers
{
    public class BaseController : Controller
    {
        protected readonly HtmlToPdfConverter Converter;

        public BaseController()
        {
            Converter = new HtmlToPdfConverter { Size = PageSize.A4 };
        }

        protected JsonResult ReturnJson(string partial = null, string status = null) =>
            Json(new { partial, status }, JsonRequestBehavior.AllowGet);

        protected void SaveCookie(CookieType t, string data) =>
            Response.Cookies.Add(CreateCookie(t.ToString().ToLower(), data));

        protected string GetCookie(CookieType t) => Request.Cookies[t.ToString().ToLower()]?.Value;

        private HttpCookie CreateCookie(string name, string data, int hours = 24) =>
            new HttpCookie(name) { Value = data, Expires = DateTime.Now.AddHours(hours), SameSite = SameSiteMode.Lax};

        protected void AddModelStateErrors<T>(ServiceResponse<T> response) where T : class
        {
            if (response.Successful()) return;
            foreach (var error in response.Errors)
                ModelState.AddModelError(error.Key, error.Error);
        }

        protected FileResult LoadPdf(HtmlToPdfConverter generator, string fileName, string viewName, object model = null)
        {
            var path = Server.MapPath($"~/App_Data/{fileName}");
            if (!System.IO.File.Exists(path) || Request.IsLocal)
                SavePdf(generator, viewName, path, model);

            var file = new FileStream(path, FileMode.Open, FileAccess.Read);
            return File(file, "application/pdf");
        }

        protected ActionResult PersonalPdf(HtmlToPdfConverter generator, string viewName, object model = null)
        {
            var pdfBytes = GeneratePdf(generator, viewName, model);

            return File(pdfBytes, "application/pdf");
        }

        private void SavePdf(HtmlToPdfConverter generator, string view, string path, object model = null)
        {
            var pdfBytes = GeneratePdf(generator, view, model);
            var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            fileStream.Write(pdfBytes, 0, pdfBytes.Length);
            fileStream.Close();
        }

        private byte[] GeneratePdf(HtmlToPdfConverter generator, string view, object model = null)
        {
            var viewAsString = this.RenderPartialViewToString(view, model);
            return generator.GeneratePdf(viewAsString);
        }
    }
}