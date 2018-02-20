using Interfaces;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ApiAnagramsController : Controller
    {
        IAnagramSolver<string> _anagramSolver;

        public ApiAnagramsController(IAnagramSolver<string> solver)
        {
            _anagramSolver = solver;
        }
        // GET: ApiAnagrams
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetApiAnagrams(string word)
        {
            var result = _anagramSolver.GetAnagrams(word);
            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }

    }
}