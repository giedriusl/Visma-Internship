using Interfaces;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramSolver.Service
{
    public class WordsService : IWordsService
    {
        IWordsRepository _wordsRepository;

        public WordsService(IWordsRepository rep)
        {
            _wordsRepository = rep;
        }

        public HashSet<string> FilterByWord(string filter)
        {
            return _wordsRepository.FilterByWord(filter);
        }

        public HashSet<string> ParseText()
        {
            return _wordsRepository.ParseText();
        }
    }
}
