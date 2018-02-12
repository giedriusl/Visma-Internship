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
            _display.Print("Press enter to continue..");
            string inputWord = Console.ReadLine();
            Console.WriteLine("A");
            GetAnagrams(inputWord).Wait();
            Console.WriteLine("B");
            Console.ReadLine();
        }

        static async Task GetAnagrams(string inputWord)
        {
            try
            {
                string resultanagrams = await client.GetStringAsync($"http://localhost:54566/Home/GetApiAnagrams/?word={inputWord}").ConfigureAwait(false);
                _display.Print(resultanagrams);
                Console.WriteLine("C");
            }
            catch (Exception e)
            {
                _display.Print(e.Message);
            }
        }
    }
}
