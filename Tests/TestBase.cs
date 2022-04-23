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
