using System.Web;
using System.Web.Optimization;

namespace EscolaMunicipalWeb
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/bootbox.js",
                      "~/Scripts/Datatables/jquery.datatables.js",
                      "~/Scripts/Datatables/datatables.bootstrap.js",
                      "~/Scripts/Datatables/dataTables.responsive.js",
                      "~/Scripts/fileinput.js",
                      "~/Scripts/locales/pt-BR.js",
                      "~/Scripts/Util/Util.js",
                      "~/Scripts/App/Aluno.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/content/datatables/css/datatables.bootstrap.css",
                      "~/Content/datatables/css/responsive.dataTables.css",
                      "~/Content/bootstrap-fileinput/css/fileinput.css",
                      "~/Content/site.css"));
        }
    }
}
