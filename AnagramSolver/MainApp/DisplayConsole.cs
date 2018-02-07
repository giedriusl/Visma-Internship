using Interfaces;
using System;

namespace MainApp
{
    public class DisplayConsole : IDisplay
    {
        public void Print(string input)
        {
            Console.WriteLine(input);
        }
    }
}
