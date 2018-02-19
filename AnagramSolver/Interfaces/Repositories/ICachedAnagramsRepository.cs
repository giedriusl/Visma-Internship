using System.Collections.Generic;

namespace Interfaces
{
    public interface ICachedAnagramsRepository
    {
        List<string> GetCachedAnagrams();
    }
}
