using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnagramSolver.EFCF.Core.Model
{
    public class UserLogs
    {
        [Column(Order = 0)]
        public int Id { get; set; }
        [Column(Order = 1)]
        public string UserIp { get; set; }
        [Column(Order = 2)]
        public Nullable<int> CachedWordId { get; set; }
        [Column(Order = 3)]
        public string Word { get; set; }
        [Column(Order = 4)]
        public Nullable<int> SearchTime { get; set; }

        public virtual CachedWords CachedWord { get; set; }
    }
}
