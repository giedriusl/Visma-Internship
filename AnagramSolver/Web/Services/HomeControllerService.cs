using System;
using System.Collections.Generic;
using System.Web;
using Interfaces;
using Interfaces.Services;

namespace Web.Services
{
    public class HomeControllerService : IHomeControllerService
    {
        IAnagramSolver<string> _anagramSolver;

        public HomeControllerService(IAnagramSolver<string> solver)
        {
            _anagramSolver = solver;
        }

        public void ManageCookies(string input, HttpCookie httpCookie)
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
        }

        public HashSet<string> GetDictionary()
        {
            return _anagramSolver.GetDictionary();
        }
    }
}