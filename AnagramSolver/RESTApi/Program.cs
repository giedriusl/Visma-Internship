using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTApi
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "https://jsonplaceholder.typicode.com";
            var client = new RestClient(url);
            var request = new RestRequest("/posts/1", Method.GET);
            var queryResult = client.Execute<List<Post>>(request).Data;
            foreach (var post in queryResult)
            {
                Console.WriteLine(post.Id);
                Console.WriteLine(post.UserId);
                Console.WriteLine(post.Title);
                Console.WriteLine(post.Body);
            }
        }
    }
}
