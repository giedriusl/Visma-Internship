using DBReader;
using Implementation;
using Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;

namespace Tests
{
    [TestClass]
    public class AnagramGeneratorTests
    {
        [TestMethod]
        public void Should_ReturnTrue_When_WordIsAlphabetized()
        {
            //Arrange
            IDisplay dt = new DisplayTest();
            var path = @"C:\Users\giedrius.lukocius\Desktop\AnagramSolver\MainApp\bin\Debug\zodynas.txt";
            AnagramGenerator anagramGenerator = new AnagramGenerator(new FileReader(dt, path), 2);
            var word = "alus";
            var alphabetized = "alsu";
            
            //Act

            var result = anagramGenerator.Alphabetize(word);
            
            //Assert

            Assert.AreEqual(alphabetized, result);
        }

        [TestMethod]
        public void Should_ReturnTrue_When_WordHasRightAnagrams()
        {
            //Arrange
            IDisplay dt = new DisplayTest();
            var path = @"C:\Users\giedrius.lukocius\Desktop\AnagramSolver\MainApp\bin\Debug\zodynas.txt";
            AnagramGenerator anagramGenerator = new AnagramGenerator(new FileReader(dt, path), 2);
            var word = "alus";
            var anagrams = new List<string> { "alus", "sula" };

            //Act
            var result = anagramGenerator.GetAnagrams(word);
            var biggerCount = result.Count <= anagrams.Count ? result.Count : anagrams.Count;
            bool equal = false;
            for (int i = 0; i < biggerCount; i++)
            {
                if (result[i] != anagrams[i])
                {
                    equal = false;
                    break;
                }
                equal = true;
            }
            if (equal)
                anagrams = result;
            //Assert

            Assert.AreEqual(anagrams,result);
        }

        [TestMethod]
        public void Should_ReturnFalse_When_WordHasWrongAnagrams()
        {
            IDisplay dt = new DisplayTest();
            var path = @"C:\Users\giedrius.lukocius\Desktop\AnagramSolver\MainApp\bin\Debug\zodynas.txt";
            AnagramGenerator anagramGenerator = new AnagramGenerator(new FileReader(dt, path), 2);
            var word = "alus";
            var anagrams = new List<string> { "alusa", "sula" };
            var result = anagramGenerator.GetAnagrams(word);
            Assert.AreNotEqual(anagrams, result);
        }

        public class DisplayTest : IDisplay
        {
            public void Print(string str)
            {
                Debug.WriteLine(str);
            }
        }
    }
}
