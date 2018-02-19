using AnagramSolver.Models;
using AnagramSolver.Repositories.Common;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace AnagramSolver.Repositories
{
    public class CachedWordsRepositoryEF : BaseRepository<CachedWords>, ICachedWordsRepository
    {

        public CachedWordsRepositoryEF(DbContext context) : base(context)
        {

        }
        public List<string> GetCachedWords()
        {
            throw new NotImplementedException();
        }
    }
}
