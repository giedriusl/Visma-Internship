using System.Collections.Generic;
using System.Diagnostics;
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
            IWordRepository fileReader = DefaultInit();
            HashSet<string> words;
            //Act
            words = fileReader.ParseText();
            //Assert
            Assert.IsNotNull(words);
        }

        [TestMethod]
        public void Should_ReturnTrue_When_WordIsLongEnough()
        {
            //Arrange
            IWordRepository fileReader = DefaultInit();
            HashSet<string> words;
            int count = 2;
            //Act
            words = fileReader.ParseText();

            //Assert
            foreach(var word in words)
            {
                Assert.IsTrue(count <= word.Length);
            }
        }

        public IWordRepository DefaultInit()
        {
            int minCount = 2;
            IDisplay display= new DisplayTest();
            string filePath = @"C:\Users\giedrius.lukocius\Desktop\AnagramSolver\MainApp\bin\Debug\zodynas.txt";

            IWordRepository fileReader = new FileReader(display, filePath, minCount);
            return fileReader;
        }

    }

    public class DisplayTest : IDisplay
    {
        public void Print(string str)
        {
            Debug.WriteLine(str);
        }
    }
}
