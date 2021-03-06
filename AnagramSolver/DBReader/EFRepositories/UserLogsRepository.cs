﻿using AnagramSolver.EFCF.Core.Context;
using AnagramSolver.Models;
//using AnagramSolver.EFCF.Core.Model;
using Interfaces;
using Interfaces.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DBReader.EFRepositories
{
    public class UserLogsRepository : IUserLogsRepository
    {
        AnagramsContext anagramEntities = new AnagramsContext();

        public List<SearchHistoryDto> GetSearchHistory(string ip)
        {
            throw new System.NotImplementedException();
        }

        public void SaveUserSearch(string ip, long time, string sortedWord, string originalWord)
        {
            var sortedWordID = anagramEntities.CachedWords.Where(x => x.Word == sortedWord).Select(x => x.Id).FirstOrDefault();
            var recordToSave = new UserLogs { UserIp = ip, CachedWordId = sortedWordID, Word = originalWord, SearchTime = (int)time };
            anagramEntities.UserLogs.Add(recordToSave);
            anagramEntities.SaveChanges();
        }
    }
}
