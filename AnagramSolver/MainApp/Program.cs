using DBReader;
using Implementation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MainApp
{
    public class Program
    {
        static HttpClient client = new HttpClient();
        private DisplayConsole _display = new DisplayConsole();
        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            DisplayConsole _display = new DisplayConsole();
            //client.BaseAddress = new Uri("http://localhost:54566/");
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(
            //    new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                var input = "alus";
                var anagrams = await GetAsync($"http://localhost:54566/Home/GetAnagramsFromDictionary?input={input}");
                Console.WriteLine(anagrams);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }

        static async Task<string> GetAsync(string path)
        {
            string product = null;
            string response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsStringAsync();

            }
            return product;
        }

        
    }
}
