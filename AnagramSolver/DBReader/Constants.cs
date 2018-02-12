using System.Configuration;

namespace DBReader
{
    public class Constants
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["anagramdb"].ConnectionString;
    }
}
