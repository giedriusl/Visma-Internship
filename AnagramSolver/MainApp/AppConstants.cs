using System.Configuration;

namespace MainApp
{
    public class AppConstants
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.AppSettings["connectionString"];
            }
        }
        public static string MinCount
        {
            get
            {
                return ConfigurationManager.AppSettings["min"];
            }
        }
        public static string MaxResult
        {
            get
            {
                return ConfigurationManager.AppSettings["maxResult"];
            }
        }
        public static string Path
        {
            get
            {
               return ConfigurationManager.AppSettings["filePath"];
            }
        }

    }
}
