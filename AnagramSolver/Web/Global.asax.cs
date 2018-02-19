using DBReader;
using Implementation;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;

namespace Web
{
    public class MvcApplication : HttpApplication
    {
        //public static AnagramGenerator anagramGenerator;
        //public static DatabaseReader dbReader;
        //public static DatabaseWriter dbWriter;
        //public static EFRepository efRepository;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            IUnityContainer container = new UnityContainer();
            UnityConfig.RegisterTypes(container);
            //CustomInit();
        }

        //private void CustomInit()
        //{
        //    var path = Constants.Path;
            
        //    var connectionString = Constants.ConnectionString;
        //    dbReader = new DatabaseReader(connectionString);
        //    dbWriter = new DatabaseWriter(connectionString);
        //}

    }
}
