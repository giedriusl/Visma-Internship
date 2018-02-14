using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnagramSolver.EFCF.Core.Model
{
    public class CachedWords
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CachedWords()
        {
            this.CachedAnagrams = new HashSet<CachedAnagrams>();
            this.UserLogs = new HashSet<UserLogs>();
        }

        public int Id { get; set; }
        public string Word { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CachedAnagrams> CachedAnagrams { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserLogs> UserLogs { get; set; }
    }
}
