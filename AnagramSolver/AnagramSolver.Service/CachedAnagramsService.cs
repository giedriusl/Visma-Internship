﻿using Interfaces;
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
            List<string> anagrams = _cachedWordsRepository.GetCachedAnagrams(sortedWord);
            if(!anagrams.Any())
            {
                anagrams = _anagramSolver.GetAnagrams(input);
                _cachedWordsRepository.WriteCachedWord(sortedWord, anagrams);
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
