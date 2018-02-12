using System.Collections.Generic;

namespace Interfaces
{
    public interface IDatabaseWriter
    {
        void DatabaseInit(HashSet<string> words);
    }
}
