using Interfaces;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnagramSolver.Service
{
    public class CachedAnagramsService : ICachedAnagramsService
    {
        IAnagramSolver<string> _anagramSolver;
        readonly ICachedWordsRepository _cachedWordsRepository;

        public CachedAnagramsService(IAnagramSolver<string> anagramSolver, ICachedWordsRepository wordsRepository)
        {
            _anagramSolver = anagramSolver;
            _cachedWordsRepository = wordsRepository;
        }

        public List<string> CacheAnagrams(string input)
        {
            var sortedWord = Alphabetize(input);
            var anagrams = _cachedWordsRepository.GetCachedAnagrams(sortedWord);
            if(anagrams.Count() == 0)
            {
                anagrams = _anagramSolver.GetAnagrams(input);
                _cachedWordsRepository.WriteCachedWord(sortedWord, anagrams.ToList());
            }
            return anagrams.ToList();
        }

        public string Alphabetize(string word)
        {
            char[] characters = word.ToArray();
            Array.Sort(characters);
            return new string(characters);
        }
    }
}
