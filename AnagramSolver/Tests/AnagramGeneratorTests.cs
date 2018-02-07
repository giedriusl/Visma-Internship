using DBReader;
using Implementation;
using Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class AnagramGeneratorTests
    {
        [TestMethod]
        public void Should_Check_If_Alphabetize_Method_Sorts_The_Word()
        {
            //Arrange
            var path = @"C:\Users\giedrius.lukocius\Desktop\AnagramSolver\MainApp\bin\Debug\zodynas.txt";
            AnagramGenerator anagramGenerator = new AnagramGenerator(new FileReader(path), 2);
            var word = "alus";
            var alphabetized = "alsu";
            
            //Act

            var result = anagramGenerator.Alphabetize(word);
            
            //Assert

            Assert.AreEqual(alphabetized, result);
        }
    }
}
