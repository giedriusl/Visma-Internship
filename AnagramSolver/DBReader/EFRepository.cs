using System.Collections.Generic;
using System.Linq;
using AnagramSolver.EFCF.Core.Context;
using AnagramSolver.Models;
//using AnagramSolver.EFCF.Core.Model;
using Interfaces;
using Interfaces.DTOs;

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

        //Neaisku!!!!!!!!!!!!!!!!!!!!!
        public List<SearchHistoryDto> GetSearchHistory(string ip)
        {
            var words = _anagramEntities.UserLogs
                    .Where(x => x.UserIp == ip)
                    .Select(x => new SearchHistoryDto
                    {
                        UserIp = x.UserIp,
                        SearchTime = x.SearchTime,
                        SearchedWord = x.Word,
                        Anagrams = x.CachedWord.CachedAnagrams.Select(i => i.Anagram).ToList()
                    }).ToList();
            return words;
        }


        //Neaisku!!!!!!!!!!!!!
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
            var recordToSave = new UserLogs { UserIp = ip, CachedWordId = sortedWordID, Word = originalWord, SearchTime = (int)time };
            _anagramEntities.UserLogs.Add(recordToSave);
            _anagramEntities.SaveChanges();
        }
    }
}
