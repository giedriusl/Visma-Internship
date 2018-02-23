using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Interfaces.Delegates;

namespace MainApp
{

    public class DisplayWithEvents
    {
        public event PrintHandler OutputDisplay;
        public delegate void PrintHandler(object sender, DisplayEventArgs e);
        public EventArgs e = null;

        public void OnOutputDisplay(DisplayEventArgs e)
        {
            if(OutputDisplay != null)
            {
                OutputDisplay(this, e);
            }
        }

    }
}
