using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SearchHistory
    {
        public string UserIp { get; set; }
        public int? TimeElapsed { get; set; }
        public string Word { get; set; }
        public List<string> Anagrams { get; set; }
    }
}
