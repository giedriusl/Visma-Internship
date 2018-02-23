//using AnagramSolver.EFCF.Core.Model;
using AnagramSolver.Models;
using AnagramSolver.Repositories.Common;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AnagramSolver.Repositories
{
    public class CachedWordsRepositoryEF : BaseRepository<CachedWords>, ICachedWordsRepository
    {

        readonly ICachedAnagramsRepository _repository;

        public CachedWordsRepositoryEF(DbContext context, ICachedAnagramsRepository repository) : base(context)
        {
            _repository = repository;
        }
        public List<string> GetCachedWords()
        {
            throw new NotImplementedException();
        }

        public List<string> GetCachedAnagrams(string word)
        {
            var words = dbSet.Where(x => x.Word == word).Select(y => y.CachedAnagrams.Select(z => z.Anagram)).FirstOrDefault();

            var cachedAnagrams = words;
            return cachedAnagrams.ToList();
        }

        public void WriteCachedWord(string word, List<string> anagrams)
        {
            var wordToSave = new CachedWords { Word = word };
            dbSet.Add(wordToSave);
            _dbContext.SaveChanges();
            var wordId = wordToSave.Id;
            foreach (var anagram in anagrams)
            {
                var anagramToSave = new CachedAnagrams { WordId = wordId, Anagram = anagram };
                _repository.WriteCachedAnagram(anagramToSave);
            }
            _dbContext.SaveChanges();
        }

        public int GetId(string sortedWord)
        {
            return dbSet.Where(x => x.Word == sortedWord).Select(x => x.Id).FirstOrDefault();
        }
    }
}
