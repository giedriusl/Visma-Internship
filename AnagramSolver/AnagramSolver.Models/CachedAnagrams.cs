using System.ComponentModel.DataAnnotations.Schema;

namespace AnagramSolver.Models
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
