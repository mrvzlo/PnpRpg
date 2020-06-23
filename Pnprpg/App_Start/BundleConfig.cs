using System.Web.Optimization;

namespace Boot
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js/core").Include(
                        "~/Scripts/jquery-{version}.js", 
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/umd/popper.js",
                        "~/Scripts/jquery.validate.unobtrusive.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js",
                        "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/vue/core").Include(
                "~/Scripts/axios.js",
                "~/Scripts/vue.js"));

            bundles.Add(new ScriptBundle("~/vue/herogen").Include(
                "~/Scripts/herogen/stats.js",
                "~/Scripts/herogen/herogen.js"));

            bundles.Add(new ScriptBundle("~/js/main").Include(
                "~/Scripts/main.js"));
            
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/main.css"));
        }
    }
}
