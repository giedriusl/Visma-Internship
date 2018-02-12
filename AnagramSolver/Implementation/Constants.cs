using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation
{
    public class Constants
    {
        public static string MinCount = ConfigurationManager.AppSettings["min"];
        public static string MaxResult = ConfigurationManager.AppSettings["maxResult"];
    }
}
