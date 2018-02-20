using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBReader.EFRepositories
{
    public class CachedWordsRepository : ICachedWordsRepository
    {
        public IEnumerable<string> GetCachedAnagrams(string word)
        {
            throw new NotImplementedException();
        }

        public List<string> GetCachedWords()
        {
            throw new NotImplementedException();
        }

        public int GetId(string sortedWord)
        {
            throw new NotImplementedException();
        }

        public void WriteCachedWord(string word, List<string> anagrams)
        {
            throw new NotImplementedException();
        }
    }
}
