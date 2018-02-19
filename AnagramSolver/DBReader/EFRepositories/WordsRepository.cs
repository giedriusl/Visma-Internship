using AnagramSolver.EFCF.Core.Context;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBReader.EFRepositories
{
    public class WordsRepository : IWordsRepository
    {
        AnagramsContext anagramEntities = new AnagramsContext();

        public HashSet<string> FilterByWord(string filter)
        {
            var words = anagramEntities.Words.Where(x => x.Word.Contains(filter)).Select(x => x.Word);
            var filteredWords = new HashSet<string>(words);
            return filteredWords;
        }

        public HashSet<string> ParseText()
        {
            var words = anagramEntities.Words.Select(x => x.Word);
            var wordsSet = new HashSet<string>(words);
            return wordsSet;
        }
    }
}
