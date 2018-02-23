using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IConfigSettings
    {
        string Path { get; }
        int MinCount { get; }
        int MaxResult { get; }
        string ConnectionString { get; }
    }
}
