using System.Web;
using System.Web.Optimization;

namespace TokuCinema
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            // Searching Scripts
            bundles.Add(new ScriptBundle("~/bundles/search").Include(
                "~/Scripts/jquery-3.1.0.js",
                "~/Scripts/javaScript-helpers.js",
                "~/Scripts/jquery-ui.js"));

            // jQuery UI
            //bundles.Add(new ScriptBundle("~/bundles/jQueryUi").Include(
            //    "~/Scripts/jquery-ui.js"));
            bundles.Add(new StyleBundle("~/Content/jQueryUi").Include(
                "~/Content/jquery-ui.css"));

            // Landing Page Theme
            #region light-wave

            bundles.Add(new StyleBundle("~/light-switch/assets/css").Include(
                "~/light-switch/assets/css/bootstrap.css",
                "~/light-switch/assets/css/ionicons.css",
                "~/light-switch/assets/css/font-awesome.css",
                "~/light-switch/assets/css/animations.min.css",
                "~/light-switch/assets/css/style-green.css"));

            bundles.Add(new StyleBundle("~/light-switch/assets/js").Include(
                "~/light-switch/assets/js/source/jquery.fancybox.css"));

            bundles.Add(new ScriptBundle("~/bundles/lightWaveScripts").Include(
                //"~/light-switch/assets/js/jquery-1.11.1.js",
                "~/light-switch/assets/js/bootstrap.js",
                "~/light-switch/assets/js/vegas/jquery.vegas.min.js",
                "~/light-switch/assets/js/jquery.easing.min.js",
                "~/light-switch/assets/js/source/jquery.fancybox.js",
                "~/light-switch/assets/js/jquery.isotope.js",
                "~/light-switch/assets/js/appear.min.js",
                "~/light-switch/assets/js/animations.min.js",
                "~/light-switch/assets/js/custom.js"
                ));

            #endregion

            // Dashboard Theme
            #region Dashboard

            bundles.Add(new StyleBundle("~/dashboard-theme/css").Include(
                "~/dashboard-theme/bootstrap.min.css",
                "~/dashboard-theme/dashboard.css",
                "~/dashboard-theme/ie10-viewport-bug-workaround.css"));

            bundles.Add(new ScriptBundle("~/bundles/dashboardScripts").Include(
                "~/dashboard-theme/bootstrap.min.js",
                "~/dashboard-theme/holder.min.js",
                "~/dashboard-theme/ie-emulation-modes-warning.js",
                "~/dashboard-theme/ie10-viewport-bug-workaround.js",
                "~/dashboard-theme/jquery.min.js"));

            #endregion

        }
    }
}
