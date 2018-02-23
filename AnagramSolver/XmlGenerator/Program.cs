using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderFactory factory = new OrderFactory();
            var order = factory.GetOrders();
            var xmlstring = order.Serialize();
            Console.WriteLine(xmlstring);
            Console.ReadLine();
        }
    }
}
