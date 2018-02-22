using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    public class Apartment
    {
        private int _area;
        private int _threadId = Thread.CurrentThread.ManagedThreadId;
        public Apartment(int area)
        {
            _area = area;
        }

        public int Area {
            get { return _area; }
            set {
                if (_threadId == Thread.CurrentThread.ManagedThreadId)
                {
                    _area = value;
                }
                else
                {
                    throw new ModificationNotAllowedException("Can't change the area.");
                }
            }
        }
    }
}
