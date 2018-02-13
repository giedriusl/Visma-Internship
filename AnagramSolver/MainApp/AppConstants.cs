﻿using System.Configuration;

namespace MainApp
{
    public class AppConstants
    {
        public static string ConnectionString => ConfigurationManager.AppSettings["connectionString"];
        public static int MinCount => ConstantsHelper.ParseIntegerParameter(ConfigurationManager.AppSettings["min"]);
        public static int MaxResult => ConstantsHelper.ParseIntegerParameter(ConfigurationManager.AppSettings["maxResult"]);
        public static string Path => ConfigurationManager.AppSettings["filePath"];
    }
}
