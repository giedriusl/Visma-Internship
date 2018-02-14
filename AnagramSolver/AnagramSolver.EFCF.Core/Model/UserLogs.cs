using System;

namespace AnagramSolver.EFCF.Core.Model
{
    public class UserLogs
    {
        public int Id { get; set; }
        public string UserIp { get; set; }
        public Nullable<int> CachedWordId { get; set; }
        public Nullable<int> WordId { get; set; }
        public Nullable<int> SearchTime { get; set; }

        public virtual CachedWords CachedWord { get; set; }
        public virtual Words Word { get; set; }
    }
}
