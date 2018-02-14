using System.Collections.Generic;
using System.Linq;
using Interfaces;

namespace DBReader
{
    public class EFRepository : IWordRepository
    {
        AnagramsDBEntities anagramEntities = new AnagramsDBEntities();

        public HashSet<string> ParseText()
        {
            var words = anagramEntities.Words.Select(x => x.Word1);
            var wordsSet = new HashSet<string>(words);
            return wordsSet;
        }

        public HashSet<string> FilterByWord(string filter)
        {
            var words = anagramEntities.Words.Where(x => x.Word1.Contains(filter)).Select(x => x.Word1);
            var filteredWords = new HashSet<string>(words);
            return filteredWords;
        }

        public List<string> GetCachedAnagrams(string word)
        {
            var words = (from ca in anagramEntities.CachedAnagrams
                         join cw in anagramEntities.CachedWords on ca.WordId equals cw.Id
                         where cw.Word == word
                         select ca.Anagram).ToList();
                        
            var cachedAnagrams = words;
            return cachedAnagrams;
        }

        public List<SearchHistory> GetSearchHistory(string ip)
        {
            var words = (from u in anagramEntities.UserLogs
                         join cw in anagramEntities.CachedWords on u.CachedWordId equals cw.Id
                         join ca in anagramEntities.CachedAnagrams on cw.Id equals ca.WordId
                         join w in anagramEntities.Words on u.WordId equals w.Id
                         where u.UserIp == ip
                         select new SearchHistory
                         {
                             UserIp = u.UserIp,
                             SearchTime = u.SearchTime,
                             SearchedWord = w.Word1,
                             Anagram = ca.Anagram
                         }).ToList();
            return words;
        }

        public void WriteCachedWord(string word, List<string> anagrams)
        {
            var wordToSave = new CachedWord { Word = word };
            anagramEntities.CachedWords.Add(wordToSave);
            anagramEntities.SaveChanges();
            var wordId = wordToSave.Id;
            foreach (var anagram in anagrams)
            {
                var anagramToSave = new CachedAnagram { WordId = wordId, Anagram = anagram };
                anagramEntities.CachedAnagrams.Add(anagramToSave);
            }
            anagramEntities.SaveChanges();
        }

        public void SaveUserSearch(string ip, long time, string sortedWord, string originalWord)
        {
            var sortedWordID = anagramEntities.CachedWords.Where(x => x.Word == sortedWord).Select(x => x.Id).FirstOrDefault();
            var originalWordID = anagramEntities.Words.Where(x => x.Word1 == originalWord).Select(x => x.Id).FirstOrDefault();
            var recordToSave = new UserLog { UserIp = ip, CachedWordId = sortedWordID, WordId = originalWordID, SearchTime = (int)time };
            anagramEntities.UserLogs.Add(recordToSave);
            anagramEntities.SaveChanges();
        }
    }
}
