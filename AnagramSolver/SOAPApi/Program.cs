using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAPApi
{
    class Program
    {
        static void Main(string[] args)
        {
            string ip = "88.119.143.44";
            var geo = new GeoService.GeoIPServiceSoapClient();
            Console.WriteLine(geo.GetGeoIP(ip).CountryCode);
        }
    }
}
