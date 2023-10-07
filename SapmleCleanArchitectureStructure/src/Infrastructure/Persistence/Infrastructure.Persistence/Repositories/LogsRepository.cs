using Core.Domain.Contracts.Repositories;
using Core.Domain.Entities;
using Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class LogsRepository : ILogRepository
    {
        private readonly LogDbContext _context;

        public LogsRepository(LogDbContext context)
        {
            this._context = context;
        }

        public async Task AddRestApiRequestResponseLog(RestApiRequestResponse logModel)
        {
            _context.RestApiRequestResponse.Add(logModel);
            await _context.SaveChangesAsync();
        }

        public async Task AddExceptionLog(ExceptionLog logModel)
        {
            _context.ExceptionsLog.Add(logModel);
            await _context.SaveChangesAsync();
        }
    }
}
