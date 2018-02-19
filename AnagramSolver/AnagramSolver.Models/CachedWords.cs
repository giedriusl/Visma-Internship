using System.Collections.Generic;

namespace AnagramSolver.Models
{
    public class CachedWords
    {
        public CachedWords()
        {
            this.CachedAnagrams = new HashSet<CachedAnagrams>();
            this.UserLogs = new HashSet<UserLogs>();
        }

        public int Id { get; set; }
        public string Word { get; set; }

        public virtual ICollection<CachedAnagrams> CachedAnagrams { get; set; }
        public virtual ICollection<UserLogs> UserLogs { get; set; }
    }
}
