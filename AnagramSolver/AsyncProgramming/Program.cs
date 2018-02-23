using System;
using System.Collections.Generic;
using System.IO;
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
           // CatalogFilesCreation();
            CopyFiles();
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
            var sourcePath = @"C:\Users\giedrius.lukocius\source\repos\TestFolder\";

            for (var i = 0; i < 50000; i++)
            {
                File.Create(sourcePath + i);
            }
        }

        public static void CopyFiles()
        {
            var sourcePath = @"C:\Users\giedrius.lukocius\source\repos\TestFolder\";
            var targetPath = @"C:\Users\giedrius.lukocius\source\repos\TestFolder\Copies";
            var filesPaths = Directory.GetFiles(sourcePath);
            List<string> fileNames = new List<string>();
            foreach (var filePath in filesPaths)
            {
                fileNames.Add(Path.GetFileName(filePath));

            }
            Parallel.ForEach(fileNames, new ParallelOptions { MaxDegreeOfParallelism = 10 }, fileName =>
                File.Copy(sourcePath + @"\" + fileName, targetPath + @"\" + fileName)
            );
        }
    }
}
