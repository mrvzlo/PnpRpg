using System.IO;
using System.Web.Mvc;

namespace Boot.Helpers
{
    public static class Extensions
    {
        public static string RenderPartialViewToString(this Controller controller, string viewName = null, object model = null)
        {
            if (string.IsNullOrWhiteSpace(viewName))
            {
                viewName = controller.ControllerContext.RouteData.GetRequiredString("action");
            }

            controller.ViewData.Model = model;

            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);
                var viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, sw);
                viewResult.View.Render(viewContext, sw);
                return sw.GetStringBuilder().ToString();
            }
        }

    }
}