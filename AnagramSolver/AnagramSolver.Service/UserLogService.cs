using Interfaces;
using Interfaces.DTOs;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramSolver.Service
{
    public class UserLogService : IUserLogService
    {
        readonly IUserLogsRepository _userLogRepository;

        public UserLogService(IUserLogsRepository userLogRep)
        {
            _userLogRepository = userLogRep;
        }

        public List<SearchHistoryDto> GetSearchHistory(string ip)
        {
            return _userLogRepository.GetSearchHistory(ip);
        }

        public void SaveUserSearch(string ip, long time, string input)
        {
            var sortedInput = input.Alphabetize();
            _userLogRepository.SaveUserSearch(ip, time, sortedInput, input);
        }
    }
}
