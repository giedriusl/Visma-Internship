using AnagramSolver.Models;
using AnagramSolver.Repositories.Common;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DBReader.EFRepositories
{
    public class CachedAnagramsRepository : ICachedAnagramsRepository
    {

        public IEnumerable<string> GetCachedAnagrams(string word)
        {
            throw new NotImplementedException();
        }

        public void WriteCachedAnagram(CachedAnagrams anagram)
        {
            throw new NotImplementedException();
        }
    }
}
