using System.Collections.Generic;

namespace AnagramSolver.EFCF.Core.Model
{
    public class Words
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Words()
        {
            this.UserLogs = new HashSet<UserLogs>();
        }

        public int Id { get; set; }
        public string Word { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserLogs> UserLogs { get; set; }
    }
}
