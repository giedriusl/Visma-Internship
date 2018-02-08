using System;
using System.Configuration;

namespace Web
{
    public class Constants
    {
        public static string Path = ConfigurationManager.AppSettings["filePath"];
        public static string MinCount = ConfigurationManager.AppSettings["min"];
        public static string MaxResult = ConfigurationManager.AppSettings["maxResult"];
    }
}