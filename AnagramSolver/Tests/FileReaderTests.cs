using System.Collections.Generic;
using DBReader;
using Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Tests.AnagramGeneratorTests;

namespace Tests
{
    [TestClass]
    public class FileReaderTests
    {

        [TestMethod]
        public void Should_ReturnTrue_When_FileIsNotNull ()
        {
            //Arrange
            IDisplay dt = new DisplayTest();
            var path = @"C:\Users\giedrius.lukocius\Desktop\AnagramSolver\MainApp\bin\Debug\zodynas.txt";
            IWordRepository fileReader = new FileReader(dt, path);
            HashSet<string> words;
            //Act
            words = fileReader.ParseText();
            //Assert
            Assert.IsNotNull(words);
        }
    }
}
