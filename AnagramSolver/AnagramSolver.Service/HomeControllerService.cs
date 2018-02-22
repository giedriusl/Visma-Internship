using Interfaces;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AnagramSolver.Service
{
    public class HomeControllerService : IHomeControllerService
    {
        IAnagramSolver<string> _anagramSolver;

        public HomeControllerService(IAnagramSolver<string> solver)
        {
            _anagramSolver = solver;
        }

        public HttpCookie ManageCookies(string input, HttpCookie httpCookie)
        {
            if (httpCookie == null)
            {
                httpCookie = new HttpCookie("LastSearch");
                httpCookie.Value = "Labas";
            }
            else
            {
                httpCookie.Value = input;
            }
            httpCookie.Expires = DateTime.Now.AddDays(1);
            return httpCookie;
        }

        public HashSet<string> GetDictionary()
        {
            return _anagramSolver.GetDictionary();
        }
    }
}
