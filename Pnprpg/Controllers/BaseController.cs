using System;
using System.Collections.Generic;
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
        protected JsonResult ReturnJson(string partial = null, string url = null, string status = null) =>
            Json(new { url, partial, status }, 0);

        protected void SaveCookie(CookieType t, string data) =>
            Response.Cookies.Add(CreateCookie(t.ToString().ToLower(), data));

        protected string GetCookie(CookieType t) => Request.Cookies[t.ToString().ToLower()]?.Value;

        private HttpCookie CreateCookie(string name, string data, int hours = 24) =>
            new HttpCookie(name) { Value = data, Expires = DateTime.Now.AddHours(hours) };

        protected void AddModelStateErrors<T>(ServiceResponse<T> response) where T : class
        {
            if (response.Successful()) return;
            foreach (var error in response.Errors)
                ModelState.AddModelError(error.Key, error.Error);
        }
        
        protected void SavePdf(HtmlToPdfConverter generator, string view, string path, object model = null)
        {
            var viewAsString = this.RenderPartialViewToString(view, model);
            var pdfBytes = generator.GeneratePdf(viewAsString);
            var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            fileStream.Write(pdfBytes, 0, pdfBytes.Length);
            fileStream.Close();
        }

        protected SelectList SelectableListToSelectList(List<Selectable> list, int? selected = null) =>
            new SelectList(list, nameof(Selectable.Value), nameof(Selectable.Text), selected);
    }
}