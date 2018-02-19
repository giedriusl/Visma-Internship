using Interfaces.DTOs;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IWordRepository
    {
        HashSet<string> ParseText();
        void SaveUserSearch(string ip, long time, string sortedWord, string originalWord);
        List<string> GetCachedAnagrams(string word);
        void WriteCachedWord(string word, List<string> anagrams);
        List<SearchHistoryDto> GetSearchHistory(string ip);
        HashSet<string> FilterByWord(string filter);
    }
}
