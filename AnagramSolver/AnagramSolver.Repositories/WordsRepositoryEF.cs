using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AnagramSolver.Models;
using AnagramSolver.Repositories.Common;
using Interfaces;

namespace AnagramSolver.Repositories
{
    public class WordsRepositoryEF : BaseRepository<Words>, IWordsRepository
    {

        public WordsRepositoryEF(DbContext context) : base(context)
        {

        }

        public HashSet<string> FilterByWord(string filter)
        {
            var words = dbSet.Where(x => x.Word.Contains(filter)).Select(x => x.Word);
            var filteredWords = new HashSet<string>(words);
            return filteredWords;
        }

        public HashSet<string> ParseText()
        {
            var words = dbSet.Select(x => x.Word);
            var wordsSet = new HashSet<string>(words);
            return wordsSet;
        }
    }
}
