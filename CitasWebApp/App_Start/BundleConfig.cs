using System.Web;
using System.Web.Optimization;

namespace CitasWebApp
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/otros").Include(
                        "~/Scripts/popper.min.js",
                        "~/Scripts/custom.js"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/cssCalander").Include(
                      "~/Content/fullcalender/fullcalender.min.css",
                      "~/Content/fullcalender/fullcalender.print.min.css"));

            bundles.Add(new StyleBundle("~/Content/css2").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/quicksand.css",
                      "~/Content/style.css",
                      "~/Content/fontawesome-all.min.css",
                      "~/Content/fontawesome.css"));
        }
    }
}
