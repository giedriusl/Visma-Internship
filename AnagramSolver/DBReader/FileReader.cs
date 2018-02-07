using Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace DBReader
{
    public class FileReader : IWordRepository
    {
        private HashSet<string> setOfWords = new HashSet<string>();
        private string _filePath;
        public FileReader(string path)
        {
            _filePath = path;
        }
        public HashSet<string> ParseText()
        {
            try { 
                using(StreamReader streamReader = new StreamReader(_filePath))
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
            } catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("File couldn't be found");
                Console.ReadLine();
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Something happened while reading dictionary!");
                Console.ReadLine();
                return null;
            }
        }
    }
}
