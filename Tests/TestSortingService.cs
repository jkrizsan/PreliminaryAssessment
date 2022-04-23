using Moq;
using System.Linq;
using NUnit.Framework;
using System.Diagnostics;
using BusinessLogic.Sorting;
using Microsoft.Extensions.Logging;

namespace Tests
{

    [TestFixture]
    public class TestSortingService : TestBase<SortingService>
    {
        private double[] _array;

        private ISortingService _sortingService;

        private const int _size = 500;

        [SetUp]
        public void SetUp()
        {
            _loggerMock = new Mock<ILogger<SortingService>>();

            _sortingService = new SortingService(getLoggerMock().Object);

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
            int size = 5000;
            var bubbleArray = _sortingService.CreateArrayWithRandomNumbers(size);
            var mergeArray = _sortingService.CreateArrayWithRandomNumbers(size);

            Stopwatch bubbleWatch = new Stopwatch();
            Stopwatch mergeWatch = new Stopwatch();

            bubbleWatch.Start();
            _sortingService.BubbleSort(bubbleArray, true);
            bubbleWatch.Stop();

            mergeWatch.Start();
            _sortingService.MergeSort(mergeArray, true);
            mergeWatch.Stop();

            Assert.Greater(bubbleWatch.ElapsedMilliseconds, mergeWatch.ElapsedMilliseconds);
        }
    }
}
