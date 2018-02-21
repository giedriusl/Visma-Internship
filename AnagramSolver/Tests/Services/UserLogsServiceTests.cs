using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Interfaces;
using NSubstitute;
using AnagramSolver.Service;
using Interfaces.DTOs;
using Shouldly;
using System.Linq;

namespace Tests.Services
{
    /// <summary>
    /// Summary description for UserLogsServiceTests
    /// </summary>
    [TestFixture]
    public class UserLogsServiceTests
    {
        private IUserLogsRepository _userLogRepository;
        private UserLogService _userLogService;

        [SetUp]
        public void Setup()
        {
            _userLogRepository = Substitute.For<IUserLogsRepository>();
            _userLogService = new UserLogService(_userLogRepository);
        }

        private NUnit.Framework.TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>

        public NUnit.Framework.TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
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
        public void GetSearchHistory_ShouldGetAllUserSearchHistory()
        {
            var ip = "10.11.19.188";
            var list = new List<SearchHistoryDto>
            {
                new SearchHistoryDto{
                    UserIp = "10.11.19.188",
                    SearchTime = 5,
                    SearchedWord = "alus",
                    Anagrams = new List<string>
                    {
                        "alus", "sula"
                    }
                },
                new SearchHistoryDto{
                    UserIp = "10.11.19.188",
                    SearchTime = 10,
                    SearchedWord = "alus",
                    Anagrams = new List<string>
                    {
                        "alus", "sula"
                    }
                },
                new SearchHistoryDto{
                    UserIp = "10.11.19.188",
                    SearchTime = 15,
                    SearchedWord = "alus",
                    Anagrams = new List<string>
                    {
                        "alus", "sula"
                    }
                },
                new SearchHistoryDto{
                    UserIp = "10.11.19.188",
                    SearchTime = 11,
                    SearchedWord = "abipus",
                    Anagrams = new List<string>
                    {
                        "api", "bus"
                    }
                },
            };

            _userLogRepository.GetSearchHistory(ip).Returns(list);

            var result = _userLogService.GetSearchHistory(ip);
            result.ShouldNotBeNull();
            result.First().ShouldBe(list[0]);

            _userLogRepository.Received().GetSearchHistory(ip);
        }
    }
}
