using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ICachedWordsRepository
    {
        List<string> GetCachedWords();
        List<string> GetCachedAnagrams(string word);
        void WriteCachedWord(string word, List<string> anagrams);
        int GetId(string sortedWord);
    }
}
