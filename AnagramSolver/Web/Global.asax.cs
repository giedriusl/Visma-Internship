using DBReader;
using Implementation;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Web
{
    public class MvcApplication : HttpApplication
    {
        public static AnagramGenerator anagramGenerator;
        public static DisplayWeb display;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            CustomInit();
        }

        private void CustomInit()
        {
            var path = Constants.Path;
            var minCount = ConstantsHelper.ParseIntegerParameter(Constants.MinCount);
            display = new DisplayWeb();
            var fileReader = new FileReader(display, path);
            anagramGenerator = new AnagramGenerator(fileReader, minCount);
        }
    }
}
