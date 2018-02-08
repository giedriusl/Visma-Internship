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
            var alphabetized = new List<string> { "alus", "sula" };

            //Act
            var result = anagramGenerator.GetAnagrams(word);

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
