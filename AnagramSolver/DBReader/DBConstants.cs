using System.Configuration;

namespace DBReader
{
    public static class DBConstants
    {
        public static string ConnectionString
        {
            get
            {
                var Manager = ConfigurationManager.AppSettings["connectionString"];
                return Manager;
            }
        }
    }
}
