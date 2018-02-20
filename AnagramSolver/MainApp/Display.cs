using Interfaces;
using System;
using static Interfaces.Delegates;

namespace MainApp
{

    public class Display : IDisplay
    {
        //PrintDelegate _printDelegate;
        Action<string> _printDelegate;
        public Display() { }

        public Display(Action<string> printDelegate/*PrintDelegate printDelegate*/)
        {
            _printDelegate = printDelegate;
        }

        public void FormattedPrint(Func<string,string> someDelegate, string input)
        {
            var upperedInput = someDelegate(input); 
            Print(upperedInput);
        }

        public void Print(string input)
        {
            _printDelegate(input); 
        }
    }
}
