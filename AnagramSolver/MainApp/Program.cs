using DBReader;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace MainApp
{
    public class Program
    {
        static HttpClient client = new HttpClient();
        private static DisplayConsole _display = new DisplayConsole();
        private static DBUploader _dbUploader;
        private static int minCount;
        private static int maxResult;
        private static string path;
        private static string connectionString;

        static void Main(string[] args)
        {
            var input = "krabas";

            /*
            Display display = new Display(ConsolePrint);
            display.Print(input);
            */

            /*
            Display display = new Display(ConsolePrint);
            display.FormattedPrint(FirstLetterToUpper, input);
            */
            DisplayEventArgs arguments = new DisplayEventArgs(input);
            DisplayWithEvents displayEvents = new DisplayWithEvents();
            displayEvents.OutputDisplay += ConsolePrint;
            displayEvents.OutputDisplay += DebugPrint;
            displayEvents.OnOutputDisplay(arguments);


            SettingsConfig();
            Menu();
            Console.ReadLine();
        }

        public static string FirstLetterToUpper(string input)
        {
            var upperString =  char.ToUpper(input[0]) + input.Substring(1);
            return upperString;
        }

        public static void ConsolePrint(object sender, DisplayEventArgs e)
        {
            Console.WriteLine($"Hello {e.Input}!");
        }

        public static void DebugPrint(object sender, DisplayEventArgs e)
        {
            Debug.WriteLine($"Hello {e.Input}!");
        }

        private static void GetApi()
        {
            _display.Print("Enter word to find anagrams");
            string inputWord = Console.ReadLine();
            GetAnagramsFromApi(inputWord).Wait();
            Console.ReadLine();
        }

        public static void SettingsConfig()
        {
            minCount = AppConstants.MinCount;
            maxResult = AppConstants.MaxResult;
            path = AppConstants.Path;
            connectionString = AppConstants.ConnectionString;
            _dbUploader = new DBUploader(_display, minCount, path, connectionString);
        }

        public static void Menu()
        {
            _display.Print("Enter choice: ");
            _display.Print("**1 - api**");
            _display.Print("**123 - databaseinit**");
            _display.Print("**555 - deletedatafromtable**");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    GetApi();
                    break;

                case "123":
                    _dbUploader.DbInit();
                    break;
                case "555":
                    _dbUploader.DeleteTableByName();
                    break;
                default:
                    _display.Print("Unknown number");
                    break;

            }
        }

        static async Task GetAnagramsFromApi(string inputWord)
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
