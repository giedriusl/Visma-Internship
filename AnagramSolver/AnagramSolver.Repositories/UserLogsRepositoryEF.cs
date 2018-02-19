using System.Data.Entity;
using System.Linq;
using AnagramSolver.EFCF.Core.Context;
using AnagramSolver.Models;
using AnagramSolver.Repositories.Common;
using Interfaces;

namespace AnagramSolver.Repositories
{
    public class UserLogsRepositoryEF : BaseRepository<UserLogs>,IUserLogsRepository
    {

        public UserLogsRepositoryEF(DbContext context) : base(context)
        {

        }

        public void SaveUserSearch(string ip, long time, string sortedWord, string originalWord)
        {
            var sortedWordID = dbSet.Where(x => x.Word == sortedWord).Select(x => x.Id).FirstOrDefault();
            var recordToSave = new UserLogs { UserIp = ip, CachedWordId = sortedWordID, Word = originalWord, SearchTime = (int)time };
            dbSet.Add(recordToSave);
            _dbContext.SaveChanges();
        }
    }
}
