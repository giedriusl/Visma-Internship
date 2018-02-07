using DBReader;
using Implementation;
using System;
using System.Configuration;

namespace MainApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter words: ");
            var myWords = Console.ReadLine();
            Start(myWords);
        }

        public static void Start(string myWords)
        {
            var minCount = ReadParameter();
            var maxResult = ReadParameter(false);
            var path = ReadPath();
            AnagramGenerator anagramGenerator = new AnagramGenerator(new FileReader(path), minCount);
            var anagrams = anagramGenerator.GetAnagrams(myWords);
            string anagramsToPrint = "";
            //var resultCount = maxResult < anagrams.Count ? maxResult : anagrams.Count; 
            anagramsToPrint = String.Join(", ", anagrams);
            if (String.IsNullOrEmpty(anagramsToPrint))
                Console.WriteLine("No anagrams found!");
            else
                Console.WriteLine("Anagrams found: " + anagramsToPrint);
            Console.ReadLine();
        }

        public static string ReadPath()
        {            
            return ConfigurationManager.AppSettings["filePath"];
        }

        public static int ReadParameter(bool min = true)
        {
            string parameter;
            if (min)
            {
                parameter = ConfigurationManager.AppSettings["min"];
            } else
            {
                parameter = ConfigurationManager.AppSettings["maxResult"];
            }

            int resultParameter;
            if (!Int32.TryParse(parameter, out resultParameter))
            {
                resultParameter = 0;
            }
            return resultParameter;
        }
    }
}
