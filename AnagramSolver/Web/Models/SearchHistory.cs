using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class SearchHistory
    {
        public string UserIp { get; set; }
        public int TimeElapsed { get; set; }
        public string Word { get; set; }
        public string Anagram { get; set; }
    }
}