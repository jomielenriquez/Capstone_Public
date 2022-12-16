using System.Web;
using System.Web.Optimization;

namespace CAPSTONE
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/SystemStyle.css",
            //          "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/Bootstrap").Include(
                      "~/Scripts/bootstrap/css/bootstrap.min.css",
                      "~/Scripts/font-awesome/css/font-awesome.css",
                      "~/Content/style.css",
                      "~/Content/style-responsive.css",
                      "~/Content/table-responsive.css",
                      "~/Content/jquery.gritter.css",
                      "~/Content/CustomStyle.css"
            ));
            bundles.Add(new StyleBundle("~/Content/DataTable").Include(
                "~/Content/DataTable.css",
                "~/Content/buttonsDataTable.css"
            ));
            bundles.Add(new ScriptBundle("~/Script/Bootstrap").Include(
                      "~/Scripts/jquery/jquery.min.js",
                      "~/Scripts/bootstrap/js/bootstrap.min.js",
                      "~/Scripts/jquery.dcjqaccordion.2.7.js",
                      "~/Scripts/jquery.scrollTo.min.js",
                      "~/Scripts/jquery.nicescroll.js",
                      "~/Scripts/common-scripts.js",
                      "~/Scripts/jquery.gritter.js",
                      "~/Scripts/grittercustom.js"
            ));
            bundles.Add(new ScriptBundle("~/Script/jquery").Include(
                      "~/Scripts/jquery/jquery.min.js"
            ));
            bundles.Add(new ScriptBundle("~/Script/DataTables").Include(
                "~/Scripts/JQueryDataTable.js",
                "~/Scripts/DataTable.js",
                "~/Scripts/buttonsDataTable.js",
                "~/Scripts/buttonPrint.js",
                "~/Scripts/bootstrapTable.js",
                "~/Scripts/bootstrapTableExport.js",
                "~/Scripts/tableExport.js"
            ));
        }
    }
}
