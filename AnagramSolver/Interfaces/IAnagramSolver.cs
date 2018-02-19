using System.Collections.Generic;

namespace Interfaces
{
    public interface IAnagramSolver<T>
    {
        HashSet<string> GetDictionary();
        List<T> GetAnagrams(string myWords);
    }
}
