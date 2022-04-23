using Moq;
using System;
using System.Linq;
using NUnit.Framework;
using Microsoft.Extensions.Logging;
using BusinessLogic.Square;

namespace Tests
{

    [TestFixture]
    public class TestSquareService: TestBase<SquareService>
    {
        private ISquareService _squareService;

        [SetUp]
        public void SetUp()
        {
            _loggerMock = new Mock<ILogger<SquareService>>();

            _loggerMock.Setup(
                m => m.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.IsAny<object>(),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<object, Exception, string>>()));

            var mockLoggerFactory = new Mock<ILoggerFactory>();
            mockLoggerFactory.Setup(x => x.CreateLogger(It.IsAny<string>())).Returns(() => _loggerMock.Object);

            _squareService = new SquareService(mockLoggerFactory.Object);
        }

        [Test]
        public void Test_FindLargestSquare_3x3_OK()
        {
            byte[,] bytes = new byte[3, 3]
            {
                { 0, 1, 1},
                { 1, 1, 1},
                { 1, 1, 1}
            };

            int maxSize = _squareService.FindLargestSquare(bytes);

            Assert.AreEqual(2, maxSize);

            checkLogs($"The {nameof(_squareService.FindLargestSquare)} process is started!",
                $"The {nameof(_squareService.FindLargestSquare)} process is ended");
        }

        [Test]
        public void Test_FindLargestSquare_5x5_OK()
        {
            byte[,] bytes = new byte[5, 5]
            {
                { 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1},
                { 0, 1, 1, 1, 1},
                { 0, 0, 1, 1, 0}
            };

            int maxSize = _squareService.FindLargestSquare(bytes);

            Assert.AreEqual(4, maxSize);

            checkLogs($"The {nameof(_squareService.FindLargestSquare)} process is started!",
                $"The {nameof(_squareService.FindLargestSquare)} process is ended");
        }

        [Test]
        public void Test_FindLargestSquare_5x3_OK()
        {
            byte[,] bytes = new byte[5, 3]
            {
                { 0, 1, 1},
                { 1, 1, 1},
                { 1, 1, 1},
                { 1, 1, 1},
                { 1, 0, 1}
            };

            int maxSize = _squareService.FindLargestSquare(bytes);

            Assert.AreEqual(3, maxSize);

            checkLogs($"The {nameof(_squareService.FindLargestSquare)} process is started!",
                $"The {nameof(_squareService.FindLargestSquare)} process is ended");
        }
    }
}
