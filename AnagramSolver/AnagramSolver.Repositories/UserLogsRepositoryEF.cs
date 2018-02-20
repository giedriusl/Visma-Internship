using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AnagramSolver.Models;
using AnagramSolver.Repositories.Common;
using Interfaces;
using Interfaces.DTOs;

namespace AnagramSolver.Repositories
{
    public class UserLogsRepositoryEF : BaseRepository<UserLogs>, IUserLogsRepository
    {
        ICachedWordsRepository _wordsRep;

        public UserLogsRepositoryEF(DbContext context, ICachedWordsRepository rep) : base(context)
        {
            _wordsRep = rep;
        }

        public void SaveUserSearch(string ip, long time, string sortedWord, string originalWord)
        {
            var sortedWordID = _wordsRep.GetId(sortedWord);
            var recordToSave = new UserLogs { UserIp = ip, CachedWordId = sortedWordID, Word = originalWord, SearchTime = (int)time };
            dbSet.Add(recordToSave);
            _dbContext.SaveChanges();
        }

        public List<SearchHistoryDto> GetSearchHistory(string ip)
        {
            var words = dbSet
                    .Where(x => x.UserIp == ip)
                    .Select(x => new SearchHistoryDto
                    {
                        UserIp = x.UserIp,
                        SearchTime = x.SearchTime,
                        SearchedWord = x.Word,
                        Anagrams = x.CachedWord.CachedAnagrams.Select(i => i.Anagram).ToList()
                    }).ToList();
            return words;
        }

    }
}
