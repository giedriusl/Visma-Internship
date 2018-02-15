using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnagramSolver.EFCF.Core.Model
{
    public class CachedAnagrams
    {
        public int Id { get; set; }
        [ForeignKey("CachedWords")]
        public int WordId { get; set; }
        public string Anagram { get; set; }

        public virtual CachedWords CachedWords { get; set; }
    }
}
