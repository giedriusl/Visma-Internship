namespace DBReader
{
    public class SearchHistoryDto
    {
        public string UserIp { get; set; }
        public int? SearchTime { get; set; }
        public string SearchedWord { get; set; }
        public string Anagram { get; set; }

        public SearchHistoryDto()
        {

        }

        public SearchHistoryDto(string userip, int searchtime, string searchedword, string anagram)
        {
            UserIp = userip;
            SearchTime = searchtime;
            SearchedWord = searchedword;
            Anagram = anagram;
        }
    }
}
