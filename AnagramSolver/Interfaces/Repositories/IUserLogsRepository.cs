using AnagramSolver.Models;
using Interfaces.DTOs;
using Interfaces.Repositories;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IUserLogsRepository : IBaseRepository<UserLogs>
    {
        void SaveUserSearch(string ip, long time, string sortedWord, string originalWord);
        List<SearchHistoryDto> GetSearchHistory(string ip);
    }
}
