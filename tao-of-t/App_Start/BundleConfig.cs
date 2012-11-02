using System.Web;
using System.Web.Optimization;

namespace tao_of_t
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryslideshow").Include(
                        "~/Scripts/jquery.easing.1.3.js", 
                        "~/Scripts/jquery.eislideshow.js")); 

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryresize").Include(
                        "~/Scripts/jquery-resize.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.simplemodal.js",
                        "~/Scripts/jquery-datepair.js"
                        ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));


 //           bundles.Add(new ScriptBundle("~/bundles/fullcalendar").Include(
 //                       "~/Scripts/fullcalendar/fullcalendar.js",
 //                       "~/Scripts/fullcalendar/gcal.js"));

 //           bundles.Add(new StyleBundle("~/Content/dialog/css").Include(
 //               "~/Content/dialog/basic.css"));

 //           bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
 //                       "~/Content/themes/base/jquery.ui.core.css",
//                        "~/Content/themes/base/jquery.ui.datepicker.css",
//                        "~/Content/themes/base/jquery.ui.theme.css"));

            bundles.Add(new StyleBundle("~/Content/slideshow/css").Include(
                        "~/Content/slideshow/demo.css",
                        "~/Content/slideshow/noscript.css",
                        "~/Content/slideshow/reset.css",
                        "~/Content/slideshow/style.css"));

//            bundles.Add(new StyleBundle("~/Content/fullcalendar/css").Include(
//                        "~/Content/fullcalendar/fullcalendar.css",
//                        "~/Content/fullcalendar/fullcalendar.print.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/mobiscroll-2.1.custom.min.css"));
        }
    }
}