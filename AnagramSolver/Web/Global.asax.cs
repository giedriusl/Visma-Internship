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
            //var connectionString = DBReader.Constants.ConnectionString;
            dbReader = new DatabaseReader("Data Source=LT-LIT-SC-0015;Initial Catalog=AnagramsDB;Integrated Security=True");
            anagramGenerator = new AnagramGenerator(dbReader, minCount);
        }
    }
}
