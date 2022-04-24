using Moq;
using System;
using Microsoft.Extensions.Logging;

namespace Tests
{
    public class TestBase<T>
    {
        protected Mock<ILogger<T>> _loggerMock;

        protected void checkLogs(string startMessage, string endMessage)
        {
            checkLogMessage(startMessage);
            checkLogMessage(endMessage);
        }

        protected Mock<ILoggerFactory> getLoggerMock()
        {
            var mockLoggerFactory = new Mock<ILoggerFactory>();
            mockLoggerFactory.Setup(x => x.CreateLogger(It.IsAny<string>()))
                .Returns(() => _loggerMock.Object);
            
            return mockLoggerFactory;
        }

        private void checkLogMessage(string message)
            => _loggerMock.Verify(x => x.Log(LogLevel.Information,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, t) => v.ToString().Contains(message)),
            It.IsAny<Exception>(),
            It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)), Times.Once);
    }
}
