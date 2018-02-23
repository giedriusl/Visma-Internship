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
        private static string threadName = "ApartmentThread";
        private int _area;
        private int _threadId = Thread.CurrentThread.ManagedThreadId;
        public Apartment(int area)
        {
            _area = area;
            Thread.CurrentThread.Name = threadName;
        }

        public int Area {
            get { return _area; }
            set {
                if (Thread.CurrentThread.Name == threadName)
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
