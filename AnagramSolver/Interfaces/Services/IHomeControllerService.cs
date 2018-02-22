using System.Collections.Generic;
using System.Web;

namespace Interfaces.Services
{
    public interface IHomeControllerService
    {
        HttpCookie ManageCookies(string input, HttpCookie httpCookie);
        HashSet<string> GetDictionary();
    }
}
