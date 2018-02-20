using Interfaces;
using System;

namespace MainApp
{
    public class DisplayConsole : IDisplay
    {
        //public void FormattedPrint(Delegates.FormattedDelegate someDelegate, string input)
        //{
        //    throw new NotImplementedException();
        //}

        public void FormattedPrint(Func<string, string> someDelegate, string input)
        {
            throw new NotImplementedException();
        }

        public void Print(string input)
        {
            Console.WriteLine(input);
        }
    }
}
