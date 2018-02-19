using System.Web;

namespace Interfaces.Services
{
    public interface IHomeControllerService
    {
        void ManageCookies(string input, HttpCookie httpCookie);
    }
}
