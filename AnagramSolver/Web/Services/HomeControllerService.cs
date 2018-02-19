using System;
using System.Web;
using Interfaces.Services;

namespace Web.Services
{
    public class HomeControllerService : IHomeControllerService
    {
        public HomeControllerService()
        {

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
    }
}