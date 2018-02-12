using DBReader;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MainApp
{
    public class Program
    {
        static HttpClient client = new HttpClient();
        private static DisplayConsole _display = new DisplayConsole();
        static void Main(string[] args)
        {
            Menu();
        }

        private static void GetApi()
        {
            _display.Print("Enter word to find anagrams");
            string inputWord = Console.ReadLine();
            GetAnagrams(inputWord).Wait();
            Console.ReadLine();
        }

        private static void DbInit()
        {
            var min = Implementation.ConstantsHelper.ParseIntegerParameter(Implementation.Constants.MinCount);
            var path = Implementation.Constants.Path;
            DatabaseWriter dbWriter = new DatabaseWriter();
            var fileReader = new FileReader(_display, path, min);
            var words = fileReader.ParseText();
            dbWriter.DatabaseInit(words);
        }

        public static void Menu()
        {
            _display.Print("Enter choice: ");
            _display.Print("**1 - api**");
            _display.Print("**123 - databaseinit");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    GetApi();
                    break;
                case "123":
                    DbInit();

                    break;
                    
            }
        }

        static async Task GetAnagrams(string inputWord)
        {
            try
            {
                string resultanagrams = await client.GetStringAsync($"http://localhost:54566/Home/GetApiAnagrams/?word={inputWord}").ConfigureAwait(false);
                _display.Print(resultanagrams);
            }
            catch (Exception e)
            {
                _display.Print(e.Message);
            }
        }
    }
}
