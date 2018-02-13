using System;
using System.Configuration;

namespace Web
{
    public class Constants
    {
        public static string ConnectionString => ConfigurationManager.AppSettings["connectionString"];
        public static int MinCount => ConstantsHelper.ParseIntegerParameter(ConfigurationManager.AppSettings["min"]);
        public static int MaxResult => ConstantsHelper.ParseIntegerParameter(ConfigurationManager.AppSettings["maxResult"]);
        public static string Path => ConfigurationManager.AppSettings["filePath"];
    }
}