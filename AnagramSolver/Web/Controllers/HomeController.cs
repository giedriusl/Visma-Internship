using PagedList;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAnagrams()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetAnagrams(Anagram anagram)
        {
            ViewBag.Model = MvcApplication.anagramGenerator.GetAnagrams(anagram.Name);
            return View();
        }

        public ActionResult GetAnagramsFromDictionary(string input)
        {
            ViewBag.Model = MvcApplication.anagramGenerator.GetAnagrams(input);
            return View();
        }

        public ActionResult ShowDictionary(int? page, string currentFilter)
        {
            int pageSize = 100;
            int pageNumber = (page ?? 1);
            pageNumber = pageNumber > 0 ? pageNumber : 1;
            return View(MvcApplication.anagramGenerator.AllWords.ToPagedList(pageNumber, pageSize));
        }
    }
}