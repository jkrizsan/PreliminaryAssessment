﻿using Moq;
using System;
using System.Linq;
using NUnit.Framework;
using System.Diagnostics;
using BusinessLogic.Sorting;
using Microsoft.Extensions.Logging;

namespace Tests
{

    [TestFixture]
    public class TestSortingService
    {
        private double[] _array;

        private ISortingService _sortingService;

        private const int _size = 500;

        private Mock<ILogger<SortingService>> _loggerMock;

        [SetUp]
        public void SetUp()
        {
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

            _array = _sortingService.CreateArrayWithRandomNumbers(_size);
        }

        [Test]
        public void Test_BubbleSort_ACS_OK()
        {
            _sortingService.BubbleSort(_array, true);

            Assert.AreEqual(_array.Min(), _array[0]);
            Assert.AreEqual(_array.Max(), _array[_size - 1]);

            checkLogs("Bubble sorting is started!", "Bubble sorting is ended!");
        }

        [Test]
        public void Test_BubbleSort_DES_OK()
        {
            _sortingService.BubbleSort(_array, false);

            Assert.AreEqual(_array.Max(), _array[0]);
            Assert.AreEqual(_array.Min(), _array[_size - 1]);

            checkLogs("Bubble sorting is started!", "Bubble sorting is ended!");
        }

        [Test]
        public void Test_MergeSort_ACS_OK()
        {
            _sortingService.MergeSort(_array, true);

            Assert.AreEqual(_array.Min(), _array[0]);
            Assert.AreEqual(_array.Max(), _array[_size - 1]);

            checkLogs("Merge sorting is started!", "Merge sorting is ended!");
        }

        [Test]
        public void Test_MergeSort_DES_OK()
        {
            _sortingService.MergeSort(_array, false);

            Assert.AreEqual(_array.Max(), _array[0]);
            Assert.AreEqual(_array.Min(), _array[_size - 1]);

            checkLogs("Merge sorting is started!", "Merge sorting is ended!");
        }

        [Test]
        public void Test_ComparePerformance_OK()
        {
            var bubbleArray = _sortingService.CreateArrayWithRandomNumbers(1000);
            var mergeArray = _sortingService.CreateArrayWithRandomNumbers(1000);

            Stopwatch bubbleWatch = new Stopwatch();
            Stopwatch mergeWatch = new Stopwatch();

            mergeWatch.Start();
            _sortingService.MergeSort(_array, false);
            mergeWatch.Stop();

            bubbleWatch.Start();
            _sortingService.BubbleSort(_array, false);
            bubbleWatch.Stop();

            Assert.Greater(mergeWatch.Elapsed.TotalMilliseconds, bubbleWatch.Elapsed.TotalMilliseconds);
        }

        private void checkLogs(string startMessage, string endMessage)
        {
            _loggerMock.Verify(x => x.Log(LogLevel.Information,
               It.IsAny<EventId>(),
               It.Is<It.IsAnyType>((v, t) => v.ToString().Contains(startMessage)),
               It.IsAny<Exception>(),
               It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)), Times.Once);

            _loggerMock.Verify(x => x.Log(LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString().Contains(endMessage)),
                It.IsAny<Exception>(),
                It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)), Times.Once);
        }
    }
}
