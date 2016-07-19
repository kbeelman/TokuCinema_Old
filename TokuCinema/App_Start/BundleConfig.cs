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

            // Original Custom Theme
            #region Grayscale
            bundles.Add(new StyleBundle("~/vendor/css").Include(
                "~/vendor/bootstrap/css/bootstrap.css",
                "~/vendor/font-awesome/css/font-awesome.min.css"));


            bundles.Add(new StyleBundle("~/css/css").Include(
                "~/css/grayscale.css"));


            bundles.Add(new ScriptBundle("~/bundles/GrayscaleScripts").Include(
                "~/vendor/jquery/jquery.js",
                "~/vendor/bootstrap/js/bootstrap.min.js",
                "~/js/grayscale.min.js"));
            #endregion

            // Second Custom Theme
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
                "~/light-switch/assets/js/jquery-1.11.1.js",
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

        }
    }
}
