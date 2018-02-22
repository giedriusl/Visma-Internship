using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    public class ModificationNotAllowedException : Exception
    {
        public ModificationNotAllowedException()
        {

        }

        public ModificationNotAllowedException(string message)
            : base(message)
        {

        }
    }
}
