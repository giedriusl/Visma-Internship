using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Interfaces.Delegates;

namespace Interfaces
{
    public interface IDisplay
    {
        void Print(string input);
        void FormattedPrint(Func<string,string>/*FormattedDelegate*/ someDelegate, string input);
    }

    public class Delegates
    {
        public delegate void PrintDelegate(string input);
        public delegate string FormattedDelegate(string input);
    }
}
