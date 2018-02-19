using Interfaces.Repositories;
using System.Data.Entity;

namespace AnagramSolver.Repositories.Common
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public DbContext _dbContext { get; set; }
        public IDbSet<T> dbSet { get; set; }

        public BaseRepository(DbContext context)
        {
            _dbContext = context;
            dbSet = _dbContext.Set<T>();
        }
    }
}
