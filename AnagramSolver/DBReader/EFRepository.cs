using System.Collections.Generic;
using System.Linq;
using AnagramSolver.EFCF.Core.Context;
using AnagramSolver.EFCF.Core.Model;
using Interfaces;

namespace DBReader
{
    public class EFRepository : IWordRepository
    {
        private AnagramsContext _anagramEntities; 

        public EFRepository()
        {
            _anagramEntities = new AnagramsContext();
        }

        public HashSet<string> ParseText()
        {
            var words = _anagramEntities.Words.Select(x => x.Word);
            var wordsSet = new HashSet<string>(words);
            return wordsSet;
        }

        public HashSet<string> FilterByWord(string filter)
        {
            var words = _anagramEntities.Words.Where(x => x.Word.Contains(filter)).Select(x => x.Word);
            var filteredWords = new HashSet<string>(words);
            return filteredWords;
        }

        public List<string> GetCachedAnagrams(string word)
        {
            var words = (from ca in _anagramEntities.CachedAnagrams
                         join cw in _anagramEntities.CachedWords on ca.WordId equals cw.Id
                         where cw.Word == word
                         select ca.Anagram).ToList();
                        
            var cachedAnagrams = words;
            return cachedAnagrams;
        }

        public List<SearchHistory> GetSearchHistory(string ip)
        {
            var words = (from u in _anagramEntities.UserLogs
                         join cw in _anagramEntities.CachedWords on u.CachedWordId equals cw.Id
                         join ca in _anagramEntities.CachedAnagrams on cw.Id equals ca.WordId
                         join w in _anagramEntities.Words on u.WordId equals w.Id
                         where u.UserIp == ip
                         select new SearchHistory
                         {
                             UserIp = u.UserIp,
                             SearchTime = u.SearchTime,
                             SearchedWord = w.Word,
                             Anagram = ca.Anagram
                         }).ToList();
            return words;
        }

        public void WriteCachedWord(string word, List<string> anagrams)
        {
            var wordToSave = new CachedWords { Word = word };
            _anagramEntities.CachedWords.Add(wordToSave);
            _anagramEntities.SaveChanges();
            var wordId = wordToSave.Id;
            foreach (var anagram in anagrams)
            {
                var anagramToSave = new CachedAnagrams { WordId = wordId, Anagram = anagram };
                _anagramEntities.CachedAnagrams.Add(anagramToSave);
            }
            _anagramEntities.SaveChanges();
        }

        public void SaveUserSearch(string ip, long time, string sortedWord, string originalWord)
        {
            var sortedWordID = _anagramEntities.CachedWords.Where(x => x.Word == sortedWord).Select(x => x.Id).FirstOrDefault();
            var originalWordID = _anagramEntities.Words.Where(x => x.Word == originalWord).Select(x => x.Id).FirstOrDefault();
            var recordToSave = new UserLogs { UserIp = ip, CachedWordId = sortedWordID, WordId = originalWordID, SearchTime = (int)time };
            _anagramEntities.UserLogs.Add(recordToSave);
            _anagramEntities.SaveChanges();
        }
    }
}
