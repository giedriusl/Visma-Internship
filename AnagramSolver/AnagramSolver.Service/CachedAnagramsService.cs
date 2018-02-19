using Interfaces;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramSolver.Service
{
    public class CachedAnagramsService : ICachedAnagramsService
    {
        IAnagramSolver<string> _anagramSolver;
        readonly ICachedAnagramsRepository _cachedAnagramsRep;
        readonly ICachedWordsRepository _cachedWordsRep;

        public CachedAnagramsService(IAnagramSolver<string> anagramSolver, ICachedAnagramsRepository anagramsRepository, ICachedWordsRepository wordsRepository)
        {
            _anagramSolver = anagramSolver;
            _cachedAnagramsRep = anagramsRepository;
            _cachedWordsRep = wordsRepository;
        }

        public List<string> CacheAnagrams(string input)
        {
            var sortedWord = Alphabetize(input);
            var anagrams = _cachedWordsRep.GetCachedAnagrams(sortedWord).ToList();
            if (anagrams.Count == 0)
            {
                anagrams = _anagramSolver.GetAnagrams(input);
                _cachedWordsRep.WriteCachedWord(sortedWord, anagrams);
            }
            return anagrams;
        }

        public string Alphabetize(string word)
        {
            char[] characters = word.ToArray();
            Array.Sort(characters);
            return new string(characters);
        }
    }
}
