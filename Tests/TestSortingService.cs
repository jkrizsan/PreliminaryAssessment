using Moq;
using System;
using NUnit.Framework;
using BusinessLogic.Sorting;
using Microsoft.Extensions.Logging;

namespace Tests
{

    [TestFixture]
    public class TestSortingService
    {
        private double[] array;

        private static ISortingService _sortingService;

        private Mock<ILogger<SortingService>> _loggerMock;

        [SetUp]
        public void SetUp()
        {
            array = new double[5] { 2.0, 1.0, 5.0, 4.0, 3.0 };

            _loggerMock = new Mock<ILogger<SortingService>>();
            _loggerMock.Setup(
                m => m.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.IsAny<object>(),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<object, Exception, string>>()));

            var mockLoggerFactory = new Mock<ILoggerFactory>();
            mockLoggerFactory.Setup(x => x.CreateLogger(It.IsAny<string>())).Returns(() => _loggerMock.Object);

            _sortingService = new SortingService(mockLoggerFactory.Object);
        }

        [Test]
        public void Test_BubbleSort_ACS_is_OK()
        {
            _sortingService.BubbleSort(array, true);

            Assert.AreEqual(1.0, array[0]);
            Assert.AreEqual(5.0, array[4]);

            checkLogs();
        }

        [Test]
        public void Test_BubbleSort_DES_is_OK()
        {
            _sortingService.BubbleSort(array, false);

            Assert.AreEqual(5.0, array[0]);
            Assert.AreEqual(1.0, array[4]);

            checkLogs();
        }

        private void checkLogs()
        {
            _loggerMock.Verify(x => x.Log(LogLevel.Information,
               It.IsAny<EventId>(),
               It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Sorting is started!")),
               It.IsAny<Exception>(),
               It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)), Times.Once);

            _loggerMock.Verify(x => x.Log(LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Sorting is ended!")),
                It.IsAny<Exception>(),
                It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)), Times.Once);
        }
    }
}
