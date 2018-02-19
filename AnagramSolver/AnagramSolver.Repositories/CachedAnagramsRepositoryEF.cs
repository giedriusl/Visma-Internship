using AnagramSolver.Models;
using AnagramSolver.Repositories.Common;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramSolver.Repositories
{
    public class CachedAnagramsRepositoryEF : BaseRepository<CachedAnagrams>, ICachedAnagramsRepository
    {
        public CachedAnagramsRepositoryEF(DbContext context) : base(context)
        {

        }

        public List<string> GetCachedAnagrams()
        {
            throw new NotImplementedException();
        }
    }
}
