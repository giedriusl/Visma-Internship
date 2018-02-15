using DBReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models;

namespace Web
{
    public class Mapper
    {
        public static List<SearchHistory> Map(List<SearchHistoryDto> searchHistoryDto)
        {
            var ip = searchHistoryDto[0].UserIp;
            Dictionary<Tuple<string,int?>, List<string>> dict = new Dictionary<Tuple<string,int?>, List<string>>();
            foreach (var record in searchHistoryDto)
            {
                var key = new Tuple<string, int?>(record.SearchedWord, record.SearchTime);
                if (!dict.ContainsKey(key))
                {
                    dict.Add(key, new List<string> { record.Anagram });
                }
                else
                {
                    dict[key].Add(record.Anagram);
                }
            }
            List<SearchHistory> list = new List<SearchHistory>();
            foreach (var item in searchHistoryDto)
            {
                var key = new Tuple<string, int?>(item.SearchedWord, item.SearchTime);

                if (!dict.ContainsKey(key))
                {
                    list.Add(new SearchHistory {
                        UserIp = item.UserIp,
                        TimeElapsed = item.SearchTime,
                        Word = item.SearchedWord,
                        Anagrams = dict[key] });
                }
            }
            return list;
        }

    }
}