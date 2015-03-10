using System.Web;
using System.Web.Optimization;

namespace Dylan.Demo.MVC
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

            bundles.Add(new StyleBundle("~/bundles/ace/css").Include(
                    "~/Scripts/assets/css/bootstrap.min.css",
                    "~/Scripts/assets/css/font-awesome.min.css" ,
                    "~/Scripts/assets/css/jquery-ui-1.10.3.custom.min.css" ,
                    "~/Scripts/assets/css/chosen.css" ,
                    "~/Scripts/assets/css/datepicker.css" ,
                    "~/Scripts/assets/css/bootstrap-timepicker.css" ,
                    "~/Scripts/assets/css/daterangepicker.css" ,
                    "~/Scripts/assets/css/colorpicker.css" ,
                    "~/Scripts/assets/css/ace.min.css" ,
                    "~/Scripts/assets/css/ace-rtl.min.css" ,
                    "~/Scripts/assets/css/ace-skins.min.css",
                    "~/Content/site.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/ace/js").Include(
                "~/Scripts/assets/js/ace-extra.min.js",
                "~/Scripts/assets/js/bootstrap.min.js",
                "~/Scripts/assets/js/typeahead-bs2.min.js",
                "~/Scripts/assets/js/jquery-ui-1.10.3.custom.min.js",
                "~/Scripts/assets/js/jquery.ui.touch-punch.min.js",
                "~/Scripts/assets/js/jquery.slimscroll.min.js",
                "~/Scripts/assets/js/jquery.easy-pie-chart.min.js",
                "~/Scripts/assets/js/jquery.sparkline.min.js",
                "~/Scripts/assets/js/flot/jquery.flot.min.js",
                "~/Scripts/assets/js/flot/jquery.flot.pie.min.js",
                "~/Scripts/assets/js/flot/jquery.flot.resize.min.js",
                "~/Scripts/assets/js/ace-elements.min.js",
                "~/Scripts/assets/js/ace.min.js",
                "~/Scripts/jquery.validate*",
                "~/Scripts/respond.js"
            ));
        }
    }
}
