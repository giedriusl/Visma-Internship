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
        private static int _minCount;
        private static int _maxResult;
        private static string _path;
        private static string _connectionId;

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

        public void SettingsConfig()
        {

        }

        private static void DeleteTableByName()
        {
            var connectionString = DBConstants.ConnectionString;
            DatabaseWriter dbWriter = new DatabaseWriter(connectionString);
            _display.Print("Enter table name: ");
            var tableName = Console.ReadLine();
            dbWriter.DeleteTableData(tableName);
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
                    DBUploader dbUploader = new DBUploader();
                    dbUploader.DbInit();
                    break;
                case "555":
                    DeleteTableByName();
                    break;
                default:
                    _display.Print("Unknown number");
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
