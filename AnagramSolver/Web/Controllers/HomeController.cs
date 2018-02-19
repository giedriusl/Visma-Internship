using Interfaces;
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
        IAnagramSolver<string> _anagramSolver;
        IWordRepository _repository;

        public HomeController(IWordRepository rep, IAnagramSolver<string> solver)
        {
            _anagramSolver = solver;
            _repository = rep;
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
            ViewBag.Model = CacheWords(input);
            timer.Stop();
            var timeResult = timer.ElapsedMilliseconds;
            string userIp = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList[1].ToString();
            var sortedInput = Alphabetize(input);
            _repository.SaveUserSearch(userIp, timeResult, sortedInput, input);
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
                 result = _repository.FilterByWord(filter).ToPagedList(pageNumber, pageSize);
            }
            else
            {
                 result = _anagramSolver.GetDictionary().ToPagedList(pageNumber, pageSize);
            }
            return View(result);
        }

        public JsonResult GetApiAnagrams(string word)
        {
            var result = _anagramSolver.GetAnagrams(word);
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
            var anagrams = _repository.GetCachedAnagrams(sortedWord);
            if (anagrams.Count == 0)
            {
                anagrams = _anagramSolver.GetAnagrams(input);
                _repository.WriteCachedWord(sortedWord, anagrams);
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
            ViewBag.Model = _repository.GetSearchHistory(userIP);
            return View();
        }
    }
}