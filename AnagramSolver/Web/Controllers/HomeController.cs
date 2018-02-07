using DBReader;
using Implementation;
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
            var minCount = 2;
            var path = @"C:\Users\giedrius.lukocius\source\repos\AnagramSolver\Visma-Internship\AnagramSolver\MainApp\bin\Debug\zodynas.txt";
            AnagramGenerator anagramGenerator = new AnagramGenerator(new FileReader(path), minCount);
            ViewBag.Model = anagramGenerator.GetAnagrams(anagram.Name);
            return View();
        }
    }
}