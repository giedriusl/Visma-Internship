namespace DBReader
{
    public class SearchHistory
    {
        public string UserIp { get; set; }
        public int? SearchTime { get; set; }
        public string SearchedWord { get; set; }
        public string Anagram { get; set; }

        public SearchHistory()
        {

        }

        public SearchHistory(string userip, int searchtime, string searchedword, string anagram)
        {
            UserIp = userip;
            SearchTime = searchtime;
            SearchedWord = searchedword;
            Anagram = anagram;
        }
    }
}
