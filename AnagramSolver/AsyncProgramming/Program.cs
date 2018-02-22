using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        public static void StartApartmentThread()
        {
            Apartment ap = new Apartment(1);
            Thread thread = new Thread(() => { ap.Area = 2; });
            thread.Start();
            Console.WriteLine(ap.Area);
            Console.ReadLine();
        }

        public static void CatalogFilesCreation()
        {
            var sourcePath = @"C:\Users\giedrius.lukocius\source\repos\TestFolder";
            var targetPath = @"C:\Users\giedrius.lukocius\source\repos\TestFolder\Copies";


        }
    }
}
