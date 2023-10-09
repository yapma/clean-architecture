using Core.Domain.Contracts.Repositories;
using Core.Domain.Entities;
using Infrastructure.Persistence.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.Infrastructure.Persistence.Mocks;

namespace UnitTests.Infrastructure.Persistence
{
    public class LogsRepositoryUnitTests
    {
        private readonly ILogsRepository _logsRepository;

        public LogsRepositoryUnitTests()
        {
            _logsRepository = new LogsRepository(LogDbContextMock.Context.Object);
        }

        [Fact]
        public async Task Register_WithValidModel_AddsRestApiRequestResponseToContext()
        {
            // Arrange
            long id = 10L;
            var model = new RestApiRequestResponse() { DateTime = DateTime.Now, Id = id };

            // Act

            await _logsRepository.AddRestApiRequestResponseLog(model);
            var result = await _logsRepository.GetAllRestApiRequestResponseLog();

            // Assert
            Assert.NotNull(result.Single(x => x.Id == id));
        }

        [Fact]
        public async Task Register_WithValidModel_AddsExceptionLogToContext()
        {
            // Arrange
            long id = 10L;
            var model = new ExceptionLog() { DateTime = DateTime.Now, Id = id };

            // Act
            await _logsRepository.AddExceptionLog(model);
            var result = await _logsRepository.GetAllExceptionLog();

            // Assert
            Assert.NotNull(result.Single(x => x.Id == id));
        }
    }
}
