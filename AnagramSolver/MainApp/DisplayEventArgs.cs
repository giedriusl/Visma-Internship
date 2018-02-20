using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    public class DisplayEventArgs : EventArgs
    {
        public string Input;

        public DisplayEventArgs(string input)
        {
            Input = input;
        }
    }
}
