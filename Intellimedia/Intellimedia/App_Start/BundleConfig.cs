using System.Web;
using System.Web.Optimization;

namespace Intellimedia
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/Sass/preloader.css",
                      "~/Content/icon-fonts.css",
                      "~/Content/Sass/standart-style.css",
                      "~/Content/Sass/style.css",
                      "~/Content/Sass/media-style.css"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/angular-components").Include(
                       "~/Scripts/angular.min.js",
                       "~/Scripts/angular-ui-router.min.js",
                       "~/Scripts/ui-bootstrap-tpls-2.5.0.min.js",
                       "~/Scripts/highstock.src.js",
                       "~/Scripts/highcharts-ng.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                      "~/app/app.js",
                      "~/app/modules/employees/employees.module.js",
                      "~/app/modules/employees/components/employees/employees.js",
                      "~/app/modules/employees/components/change-employee-modal/modal.js",
                      "~/app/modules/employees/components/chart/chart.js",
                      "~/app/services/employees.js"
                      ));
            BundleTable.EnableOptimizations = false;
        }
    }
}
