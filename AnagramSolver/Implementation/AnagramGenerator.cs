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
        public HashSet<string> AllWords = new HashSet<string>();
        private int _minCount;

        public AnagramGenerator(IWordRepository iWordRepository, int min)
        {
            _iWordsRepository = iWordRepository;
            _minCount = min;
            Init();
        }

        private void Init()
        {
            ReadWordsFromDictionary();
            SortAnagrams();
        }

        public List<string> GetAnagrams(string myWords)
        {
            if (!String.IsNullOrEmpty(myWords))
            {
                myWords = Regex.Replace(myWords, @"\s+", "");
                var anagrams = FindAnagram(myWords);
                anagrams.AddRange(FindTwoAnagrams(myWords));
                anagrams.Sort();
                return anagrams;
            } else
            {
                return null;
            }
        }

        public List<string> FindAnagram(string myWords)
        {
            myWords = myWords.ToLower();
            myWords = Alphabetize(myWords);
            if (_anagramSet.ContainsKey(myWords))
            {
                var results = _anagramSet[myWords].ToList();
                return results;
            } else
            {
                return new List<string>();
            }
        }

        private void ReadWordsFromDictionary()
        {
            var parsedText = _iWordsRepository.ParseText();
            if (parsedText != null)
            {
                AllWords = parsedText;
            }
        }

        private void SortAnagrams()
        {
            foreach(var word in AllWords)
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

        public IEnumerable<string> FindTwoAnagrams(string myWords)
        {
            myWords = Alphabetize(myWords);
            var min = ConstantsHelper.ParseIntegerParameter(Constants.MinCount);
            var maxWords = ConstantsHelper.ParseIntegerParameter(Constants.MaxResult);
            var result = new List<string>();
            for(int i = min; i < myWords.Length - min; i++)
            {
                var lengthDictionary = _anagramSet.Where(x => x.Key.Length == i);
                foreach (var valueWords in lengthDictionary)
                {
                    var originalCharArray = myWords.ToList<char>();
                    var partOfWord = RemovePart(originalCharArray, valueWords.Key);
                    if (partOfWord == null)
                    {
                        continue;
                    }
                    var leftoverAnagram = new string(partOfWord.ToArray<char>());
                    if (Contains(leftoverAnagram))
                    {
                        result.AddRange(JoinAnagrams(valueWords.Value, _anagramSet[leftoverAnagram]));
                        if (result.Count > maxWords)
                        {
                            return result.Take(maxWords);
                        }
                        else continue;
                    }
                }
            }
            return result;
        }

        public List<string> JoinAnagrams(HashSet<string> firstSet, HashSet<string> secondSet)
        {
            var result = new List<string>();
            foreach (var firstWord in firstSet)
            {
                foreach(var secondWord in secondSet)
                {
                    result.Add(firstWord + " " + secondWord);
                }
            }
            return result;
        }

        public List<char> RemovePart(List<char> word, string part)
        {
            foreach (var c in part)
            {
                if (word.Contains(c))
                {
                    word.Remove(c);
                }
                else
                {
                    return null;
                }
            }
            return word;
        }

        public List<string> SortByLength(List<string> list)
        {
            var result = list.OrderBy(x => x.Length).ToList();
            return result;
        }
    }
}
