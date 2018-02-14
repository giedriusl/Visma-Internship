using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramSolver.EFCF.Core.Model
{
    public class TaskModel
    {
        public int TaskId { get; set; }
        public DateTime StartDate { get; set; }
        public virtual ContentModel Content { get; set; }
    }
}
