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
    public class CachedAnagramsRepositoryEF : BaseRepository<CachedAnagrams>, ICachedAnagramsRepository
    {
        DbContext _dbContext;

        public CachedAnagramsRepositoryEF(DbContext context) : base(context)
        {

        }

        public void WriteCachedAnagram(CachedAnagrams anagram)
        {
            dbSet.Add(anagram);
        }
    }
}
