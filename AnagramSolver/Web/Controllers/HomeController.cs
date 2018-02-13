using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Caching;
using System.Text;
using System.Web;
using System.Web.Http;
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

        [System.Web.Mvc.HttpPost]
        public ActionResult GetAnagrams(Anagram anagram)
        {
            ViewBag.Model = MvcApplication.anagramGenerator.GetAnagrams(anagram.Name);
            return View();
        }

        public ActionResult GetAnagramsFromDictionary(string input)
        {
            HttpCookie httpCookie = Request.Cookies["LastSearch"];
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
            Response.Cookies.Add(httpCookie);

            var sortedWord = Alphabetize(input);
            var anagrams = MvcApplication.dbReader.GetCachedAnagrams(sortedWord);
            if(anagrams.Count == 0)
            {
                anagrams =  MvcApplication.anagramGenerator.GetAnagrams(input);
                MvcApplication.dbWriter.WriteCachedWord(sortedWord, anagrams);
            }
            ViewBag.Model = anagrams;
            
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
                 result = MvcApplication.dbReader.FilterByWord(filter).ToPagedList(pageNumber, pageSize);
            }
            else
            {
                 result = MvcApplication.anagramGenerator.AllWords.ToPagedList(pageNumber, pageSize);
            }
            return View(result);
        }

        public JsonResult GetApiAnagrams(string word)
        {
            var result = MvcApplication.anagramGenerator.GetAnagrams(word);
            return Json(new {result = result}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Downloads()
        {
            return View();
        }

        public FileResult DownloadDictionary()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(Constants.Path);
            string fileName = "dictionary.txt";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        public string Alphabetize(string word)
        {
            char[] characters = word.ToArray();
            Array.Sort(characters);
            return new string(characters);
        }
    }
}