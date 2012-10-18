using System.Web;
using System.Web.Optimization;

namespace tao_of_t
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryslideshow").Include(
                        "~/Scripts/jquery.easing.1.3.js",    //slide viewer 
                        "~/Scripts/jquery.eislideshow.js")); // slide viewer

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            // script for tao-of-t website
            bundles.Add(new ScriptBundle("~/bundles/taooft").Include(
                        "~/Scripts/taooft-*"));

            // frontier calendar
            bundles.Add(new ScriptBundle("~/bundles/frontierCalendar").Include(
                        "~/Scripts/frontierCalendar/colorpicker.js",
                        "~/Scripts/frontierCalendar/eye.js",
                        "~/Scripts/frontierCalendar/jquery.qtip-1.0.0-rc3.min.js",
                        "~/Scripts/frontierCalendar/jshashtable-2.1.js",
                        "~/Scripts/frontierCalendar/layout.js",
                        "~/Scripts/frontierCalendar/utils.js",
                        "~/Scripts/frontierCalendar/z-jquery-frontier-cal-1.3.2.js"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            // slideshow styles
            bundles.Add(new StyleBundle("~/Content/slideshow/css").Include(
                        "~/Content/slideshow/demo.css",
                        "~/Content/slideshow/noscript.css",
                        "~/Content/slideshow/reset.css",
                        "~/Content/slideshow/style.css"));

            // frontier calendar styles
            bundles.Add(new StyleBundle("~/Content/frontierCalendar/css").Include(
                        "~/Content/frontierCalendar/jquery-frontier-cal-1.3.2.css",
                        "~/Content/frontierCalendar/colorpicker.css",
                        "~/Content/frontierCalendar/jquery-ui-1.8.1.custom.css"));



        }
    }
}