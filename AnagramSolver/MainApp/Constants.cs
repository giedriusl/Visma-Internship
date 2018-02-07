using System;
using System.Configuration;

namespace MainApp
{
    public static class Constants
    {
        public static string Path = ConfigurationManager.AppSettings["filePath"];
        public static string MinCount = ConfigurationManager.AppSettings["min"];
        public static string MaxResult = ConfigurationManager.AppSettings["maxResult"];

        public static int ParseIntegerParameter(string parameter)
        {
            int resultParameter;
            if (!Int32.TryParse(parameter, out resultParameter))
            {
                resultParameter = 0;
            }
            return resultParameter;
        }
    }
}
