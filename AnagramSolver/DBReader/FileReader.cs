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
        public FileReader(IDisplay display, string path)
        {
            _display = display;
            _filePath = path;
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
                        setOfWords.Add(words[0]);
                        setOfWords.Add(words[2]);
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
