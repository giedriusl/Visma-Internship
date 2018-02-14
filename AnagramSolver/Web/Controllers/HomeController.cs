using PagedList;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
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
            Cookies(anagram.Name);
            Stopwatch timer = new Stopwatch();
            timer.Start();
            ViewBag.Model = CacheWords(anagram.Name);
            timer.Stop();
            var timeResult = timer.ElapsedMilliseconds;
            string userIP = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList[1].ToString();
            var input = Alphabetize(anagram.Name);
            MvcApplication.dbWriter.SaveUserSearch(userIP, timeResult, input, anagram.Name);
            return View();
        }

        public ActionResult GetAnagramsFromDictionary(string input)
        {
            Cookies(input);
            ViewBag.Model = CacheWords(input);
            
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

        public List<string> CacheWords(string input)
        {
            var sortedWord = Alphabetize(input);
            var anagrams = MvcApplication.efRepository.GetCachedAnagrams(sortedWord);
            if (anagrams.Count == 0)
            {
                anagrams = MvcApplication.anagramGenerator.GetAnagrams(input);
                MvcApplication.dbWriter.WriteCachedWord(sortedWord, anagrams);
            }
            return anagrams;
        }
        
        public void Cookies(string input)
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
        }
         
        public ActionResult SearchHistory()
        {
            string userIP = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList[1].ToString();
            ViewBag.Model = MvcApplication.efRepository.GetSearchHistory(userIP);
            return View();
        }
    }
}