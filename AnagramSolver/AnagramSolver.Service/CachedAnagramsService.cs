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
            var anagrams = _cachedWordsRep.GetCachedAnagrams(sortedWord);
            if(anagrams == null)
            {
                anagrams = _anagramSolver.GetAnagrams(input);
                _cachedWordsRep.WriteCachedWord(sortedWord, anagrams.ToList());
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
