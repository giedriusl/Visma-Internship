using System.Collections.Generic;

namespace Interfaces.Services
{
    public interface IWordsService
    {
        HashSet<string> FilterByWord(string filter);
        HashSet<string> ParseText();
    }
}
