using System.Collections.Generic;

namespace Interfaces.DTOs
{
    public class SearchHistoryDto
    {
        public string UserIp { get; set; }
        public int? SearchTime { get; set; }
        public string SearchedWord { get; set; }
        public List<string> Anagrams { get; set; }
    }
}
