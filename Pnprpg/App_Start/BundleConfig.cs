using System.Web.Optimization;

namespace Pnprpg.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js/core").Include(
                        "~/Scripts/jquery-{version}.js", 
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/MvcGrid/mvc-grid.js",
                        "~/Scripts/umd/popper.js",
                        "~/Scripts/jquery.validate.unobtrusive.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js",
                        "~/Scripts/trumbowyg.js",
                        "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/js/main").Include(
                "~/Scripts/custom/main.js", "~/Scripts/custom/ajax.js"));
            
            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/MvcGrid/mvc-grid.css",
                        "~/Content/trumbowyg.css",
                        "~/Content/main.css"));
        }
    }
}
