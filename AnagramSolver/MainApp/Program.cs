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
            Console.ReadLine();
        }

        public static void Start(string myWords)
        {
            var minCount = Constants.ParseIntegerParameter(Constants.MinCount);
            var maxResult = Constants.ParseIntegerParameter(Constants.MaxResult);
            var path = Constants.Path;
            DisplayConsole dc = new DisplayConsole();
            AnagramGenerator anagramGenerator = new AnagramGenerator(new FileReader(dc,path), minCount);
            var anagrams = anagramGenerator.GetAnagrams(myWords);
            string anagramsToPrint = "";
            anagramsToPrint = String.Join(", ", anagrams);
            if (String.IsNullOrEmpty(anagramsToPrint))
                Console.WriteLine("No anagrams found!");
            else
                Console.WriteLine("Anagrams found: " + anagramsToPrint);
        }
    }
}
