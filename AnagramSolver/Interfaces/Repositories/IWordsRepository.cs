using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IWordsRepository
    {
        HashSet<string> ParseText();
        HashSet<string> FilterByWord(string filter);
    }
}
