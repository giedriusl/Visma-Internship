﻿using PagedList;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
    }
}