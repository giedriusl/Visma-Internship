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
        public static DatabaseReader dbReader;
        public static DatabaseWriter dbWriter;
        public static EFRepository efRepository;
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
            var minCount = Constants.MinCount;
            var maxResult = Constants.MaxResult;
            var connectionString = Constants.ConnectionString;
            display = new DisplayWeb();
            dbReader = new DatabaseReader(connectionString);
            dbWriter = new DatabaseWriter(connectionString);
            efRepository = new EFRepository();
            anagramGenerator = new AnagramGenerator(dbReader, minCount, maxResult);
        }
    }
}
