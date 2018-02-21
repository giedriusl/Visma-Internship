using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Interfaces;
using AnagramSolver.Service;
using NSubstitute;
using Shouldly;
using System.Linq;

namespace Tests.Services
{
    /// <summary>
    /// Summary description for CachedAnagramsServiceTests
    /// </summary>
    [TestFixture]
    public class CachedAnagramsServiceTests
    {
        private ICachedWordsRepository _cachedWordsRepository;
        private IAnagramSolver<string> _anagramSolver;
        private CachedAnagramsService _cachedAnagramsService;

        [SetUp]
        public void Setup()
        {
            _cachedWordsRepository = Substitute.For<ICachedWordsRepository>();
            _anagramSolver = Substitute.For<IAnagramSolver<string>>();
            _cachedAnagramsService = new CachedAnagramsService(_anagramSolver, _cachedWordsRepository);
        }
        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [Test]
        public void GetAnagrams_ShouldReturnAnagramsFromSolverAndCacheThem()
        {
            var word = "alus";
            var sortedWord = "alsu";
            var list = new List<string>
            {
                "alus",
                "sula"
            };

            _cachedWordsRepository.GetCachedAnagrams(sortedWord).Returns(new List<string> { });

            _anagramSolver.GetAnagrams(word).Returns(list);
            var result = _cachedAnagramsService.CacheAnagrams(word);
            result.ShouldNotBeNull();
            result.First().ShouldBe(list[0]);
            _cachedWordsRepository.Received().WriteCachedWord(sortedWord, Arg.Is<List<string>>(x => x.SequenceEqual(list)));
        }
    }
}
