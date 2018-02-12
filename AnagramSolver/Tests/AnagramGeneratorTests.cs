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
        public void Should_ReturnTrue_When_WordIsAlphabetized()
        {
            //Arrange
            var anagramGenerator = DefaultInit();
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
            var anagramGenerator = DefaultInit();
            var word = "alus";
            var anagrams = new List<string> { "alus", "sula" };


            //Act
            var result = anagramGenerator.GetAnagrams(word);

            //Assert
            //Assert.AreEqual(anagrams.Count, result.Count);
            //for (int i = 0; i < anagrams.Count; i++)
            //{
            //    Assert.AreEqual(anagrams[i], result[i]);
            //}
            CollectionAssert.AreEqual(anagrams, result);

        }

        [TestMethod]
        public void Should_ReturnFalse_When_WordHasWrongAnagrams()
        {
            var anagramGenerator = DefaultInit();
            var word = "alus";
            var anagrams = new List<string> { "alusa", "sula" };
            var result = anagramGenerator.GetAnagrams(word);
            CollectionAssert.AreNotEqual(anagrams, result);
        }


        public AnagramGenerator DefaultInit()
        {
            List<string> list = new List<string> { "alus", "sula", "medis", "namas", "obuolys" };
            AnagramGenerator anagramGenerator = new AnagramGenerator(new FakeReader(list), 2);
            return anagramGenerator;
        }
        
    }

    public class FakeReader : IWordRepository
    {
        HashSet<string> set;

        public FakeReader(List<string> parameters)
        {
            set = new HashSet<string>(parameters);
        }

        public HashSet<string> ParseText()
        {
            return set;
        }
    }
}
