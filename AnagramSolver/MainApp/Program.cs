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
            RunAsync(inputWord).GetAwaiter().GetResult();
        }

        static async Task RunAsync(string inputWord)
        {
            try
            {
                string resultanagrams = client.GetStringAsync($"http://localhost:54566/Home/GetApiAnagrams/?word={inputWord}").Result;
                _display.Print(resultanagrams);
            }
            catch (Exception e)
            {
                _display.Print(e.Message);
            }
            Console.ReadLine();
        }

        //static async Task<string> GetAsync(string path)
        //{
        //    string product = null;
        //    HttpResponseMessage response = await client.GetAsync(path);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        product = await response.Content.ReadAsStringAsync();

        //    }
        //    return product;
        //}

        
    }
}
