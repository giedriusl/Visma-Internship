﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ICachedWordsRepository
    {
        List<string> GetCachedWords();
        IEnumerable<string> GetCachedAnagrams(string word);
        void WriteCachedWord(string word, List<string> anagrams);
    }
}
