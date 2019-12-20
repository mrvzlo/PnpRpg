using System.Web.Optimization;

namespace Boot
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js/core").Include(
                        "~/Scripts/jquery-{version}.js", "~/Scripts/jquery.validate*", "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/js/main").Include(
                "~/Scripts/main.js"));
            
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/main.css"));
        }
    }
}
