using AnagramSolver.Models;
using System.Collections.Generic;

namespace Interfaces
{
    public interface ICachedAnagramsRepository
    {
        void WriteCachedAnagram(CachedAnagrams anagram);
    }
}
