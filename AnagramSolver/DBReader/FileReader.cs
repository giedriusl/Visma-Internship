using Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace DBReader
{
    public class FileReader : IWordRepository
    {
        private readonly IDisplay _display;
        private string _filePath;
        private int _minCount;
        public FileReader(IDisplay display, string path, int minCount)
        {
            _display = display;
            _filePath = path;
            _minCount = minCount;
        }
        public HashSet<string> ParseText()
        {
            try
            {
                HashSet<string> setOfWords = new HashSet<string>();
                using (StreamReader streamReader = new StreamReader(_filePath))
                {
                    while(!streamReader.EndOfStream)
                    {
                        var line = streamReader.ReadLine();
                        line = Regex.Replace(line, @"\s+", " ").ToLower();
                        var words = line.Split(' ');
                        if(words[0].Length >= _minCount)
                        {
                            setOfWords.Add(words[0]);

                        }
                        if (words[2].Length >= _minCount)
                        {
                            setOfWords.Add(words[2]);
                        }
                    }
                }
                return setOfWords;
            }
            catch (DirectoryNotFoundException)
            {
                _display.Print("File couldn't be found");
                return null;
            }
            catch (Exception e)
            {
                _display.Print($"Something happened while reading dictionary: {e.Message}");
                return null;
            }
        }
    }
}
