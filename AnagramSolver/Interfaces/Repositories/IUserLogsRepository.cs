using AnagramSolver.Models;
using Interfaces.Repositories;

namespace Interfaces
{
    public interface IUserLogsRepository : IBaseRepository<UserLogs>
    {
        void SaveUserSearch(string ip, long time, string sortedWord, string originalWord);
    }
}
