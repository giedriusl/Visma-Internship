using Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace Implementation
{
    public class AnagramGenerator : IAnagramSolver
    {
        private readonly IWordRepository _iWordsRepository;
        private Dictionary<string, HashSet<string>> _anagramSet = new Dictionary<string, HashSet<string>>();
        private HashSet<string> _allWords = new HashSet<string>();
        private int _minCount;
        private int _maxResults;

        public AnagramGenerator(IWordRepository iWordRepository, int max)
        {
            _iWordsRepository = iWordRepository;
            _maxResults = max;
        }
        public List<string> GetAnagrams(string myWords)
        {
            myWords = Regex.Replace(myWords, @"\s+", "");
            ReadWordsFromDictionary();
            SortAnagrams();
            var anagrams = FindAnagram(myWords);
            return anagrams;
        }

        public List<string> FindAnagram(string myWords)
        {
            myWords = Alphabetize(myWords);
            if (_anagramSet.ContainsKey(myWords))
            {
                var results = _anagramSet[myWords].ToList();
                return results;
            } else
            {
                return null;
            }
        }

        public void ReadWordsFromDictionary()
        {
            var parsedText = _iWordsRepository.ParseText();
            if (parsedText != null)
            {
                _allWords = parsedText;
            }
        }

        public void SortAnagrams()
        {
            foreach(var word in _allWords)
            {
                var sortedWord = Alphabetize(word);
                if (!Contains(sortedWord))
                {
                    _anagramSet.Add(sortedWord, new HashSet<string> { word });
                } else
                {
                    _anagramSet[sortedWord].Add(word);
                }
            }
        }

        public bool Contains(string word)
        {
            return _anagramSet.Keys.Contains(word);
        }

        public string Alphabetize(string word)
        {
            char[] characters = word.ToArray();
            Array.Sort(characters);
            return new string(characters);
        }
    }
}
