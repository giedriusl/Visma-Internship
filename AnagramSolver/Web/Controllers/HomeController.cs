using Interfaces;
using Interfaces.Services;
using PagedList;
using System.Diagnostics;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        IHomeControllerService _homeControllerService;
        readonly IUserLogService _userLogService;
        readonly ICachedAnagramsService _anagramsService;
        readonly IWordsService _wordsService;
        readonly IConfigSettings _configSettings;

        public HomeController(IHomeControllerService controllerService, ICachedAnagramsService anagramsService, IUserLogService userService, IWordsService wordsService, IConfigSettings configSettings)
        {
            _userLogService = userService;
            _homeControllerService = controllerService;
            _anagramsService = anagramsService;
            _wordsService = wordsService;
            _configSettings = configSettings;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAnagrams()
        {
            return View();
        }

        public ActionResult GetAnagramsFromDictionary(string input)
        {
            Cookies(input);

            Stopwatch timer = new Stopwatch();
            timer.Start();

            ViewBag.Model = _anagramsService.CacheAnagrams(input);

            timer.Stop();
            var timeResult = timer.ElapsedMilliseconds;
            string userIp = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList[1].ToString();
            
            _userLogService.SaveUserSearch(userIp, timeResult, input);
            return View();
        }

        public ActionResult ShowDictionary(int? page, string currentFilter, string filter)
        {
            int pageSize = 100;
            int pageNumber = (page ?? 1);
            pageNumber = pageNumber > 0 ? pageNumber : 1;
            IPagedList<string> result;
            if(filter != null)
            {
                 result = _wordsService.FilterByWord(filter).ToPagedList(pageNumber, pageSize);
            }
            else
            {
                 result = _homeControllerService.GetDictionary().ToPagedList(pageNumber, pageSize);
            }
            return View(result);
        }

        public ActionResult Downloads()
        {
            return View();
        }

        public FileResult DownloadDictionary()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(_configSettings.Path);
            string fileName = "dictionary.txt";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        public void Cookies(string input)
        {
            HttpCookie httpCookie = Request.Cookies["LastSearch"];
            httpCookie = _homeControllerService.ManageCookies(input, httpCookie);
            Response.Cookies.Add(httpCookie);
        }
         
        public ActionResult SearchHistory()
        {
            string userIP = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList[1].ToString();
            ViewBag.Model = _userLogService.GetSearchHistory(userIP);
            return View();
        }
    }
}