using Core.Domain.Entities;
using Infrastructure.Persistence.Contexts;
using MockQueryable.Moq;
using Moq;

namespace UnitTests.Infrastructure.Persistence.Mocks
{
    internal static class LogDbContextMock
    {
        public static Mock<LogDbContext> Context;
        static LogDbContextMock()
        {
            var restApiRequestResponses = new List<RestApiRequestResponse>();
            var restApiRequestResponsesDbSetMock = restApiRequestResponses.BuildMock().BuildMockDbSet();

            var exceptionLogs = new List<ExceptionLog>();
            var exceptionLogsDbSetMock = exceptionLogs.BuildMock().BuildMockDbSet();

            var logDbContextMock = new Mock<LogDbContext>();
            logDbContextMock.Setup(x => x.RestApiRequestResponse).Returns(restApiRequestResponsesDbSetMock.Object);
            //logDbContextMock.Setup(x => x.ExceptionsLog).Returns(exceptionLogsDbSetMock.Object);

            logDbContextMock.Setup(x => x.RestApiRequestResponse.Add(It.IsAny<RestApiRequestResponse>()))
                .Callback((RestApiRequestResponse model) => { restApiRequestResponses.Add(model); });

            //logDbContextMock.Setup(x => x.ExceptionsLog.Add(It.IsAny<ExceptionLog>()))
            //    .Callback((ExceptionLog model) => { exceptionLogsDbSetMock.Object.Add(model); });

            Context = logDbContextMock;
        }
    }
}
