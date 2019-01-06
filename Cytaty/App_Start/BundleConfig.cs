using System.Web;
using System.Web.Optimization;

namespace Cytaty
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            //bibliotekaJS
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            //odpowiada za responsywnosc strony
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));
            //JS i CSS. Content - moje.
            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/WyszukiwarkaStyle.css",
                      "~/Content/bootstrap.css", //pliki dostarczone przez twittera, szablon, nie do modyfikacji raczej
                      "~/Content/site.css")); //formatowanie stricte - moje style
        }
    }
}
