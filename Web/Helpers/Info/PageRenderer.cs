using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;

namespace Pnprpg.WebCore.Helpers
{
    public class PageRenderer : IPageRenderer
    {
        private readonly IRazorViewEngine _viewEngine;
        private readonly ITempDataProvider _tempDataProvider;
        private readonly IServiceProvider _serviceProvider;
        private readonly IRazorPageActivator _activator; 

        public PageRenderer(IRazorViewEngine viewEngine, ITempDataProvider tempDataProvider, IServiceProvider serviceProvider, IRazorPageActivator activator, IHostingEnvironment hostingEnvironment)
        {
            _viewEngine = viewEngine;
            _tempDataProvider = tempDataProvider;
            _serviceProvider = serviceProvider;
            _activator = activator;
        }

        public async Task<string> RenderPartialToStringAsync<TModel>(string partialName, TModel model)
        {
            var actionContext = GetActionContext();
            var page = FindPage(actionContext, partialName);
            await using var output = new StringWriter();

            var view = GetView(page);
            var viewData = GetViewData(model);
            var tempData = new TempDataDictionary(actionContext.HttpContext, _tempDataProvider);
            var viewContext = new ViewContext(actionContext, view, viewData, tempData, output, new HtmlHelperOptions())
            { ViewData = { ["Model"] = model } };

            await view.RenderAsync(viewContext);
            return output.ToString();
        }

        private IRazorPage FindPage(ActionContext actionContext, string partialName)
        {
            var getPartialResult = _viewEngine.GetPage(null, partialName);
            if (getPartialResult.Page != null)
            {
                return getPartialResult.Page;
            }
            var findPartialResult = _viewEngine.FindPage(actionContext, partialName);
            if (findPartialResult.Page != null)
            {
                return findPartialResult.Page;
            }
            var searchedLocations = getPartialResult.SearchedLocations.Concat(findPartialResult.SearchedLocations);
            var errorMessage = string.Join(
                Environment.NewLine,
                new[] { $"Unable to find partial '{partialName}'. The following locations were searched:" }.Concat(searchedLocations)); ;
            throw new InvalidOperationException(errorMessage);
        }

        private ActionContext GetActionContext()
        {
            var httpContext = new DefaultHttpContext { RequestServices = _serviceProvider };
            return new ActionContext(httpContext, new RouteData(), new ActionDescriptor());
        }

        private RazorView GetView(IRazorPage page)
        {
            var startPages = new List<IRazorPage>();
            var diagnostic = new DiagnosticListener(nameof(PageRenderer));
            return new RazorView(_viewEngine, _activator, startPages, page, HtmlEncoder.Default, diagnostic);
        }

        private ViewDataDictionary GetViewData<TModel>(TModel model)
        {
            var provider = new EmptyModelMetadataProvider();
            var state = new ModelStateDictionary();
            return new ViewDataDictionary<TModel>(provider, state) { Model = model };
        }
    }
}