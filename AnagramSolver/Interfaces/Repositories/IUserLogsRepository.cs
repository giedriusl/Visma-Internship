using AnagramSolver.EFCF.Core.Model;
using Interfaces.Repositories;

namespace Interfaces
{
    public interface IUserLogsRepository : IBaseRepository<UserLogs>
    {
        void SaveUserSearch(string ip, long time, string sortedWord, string originalWord);
    }
}
