using System.ComponentModel.DataAnnotations;

namespace AnagramSolver.EFCF.Core.Model
{
    public class CachedAnagrams
    {
        public int Id { get; set; }
        public int WordId { get; set; }
        public string Anagram { get; set; }

        public virtual CachedWords CachedWords { get; set; }
    }
}
