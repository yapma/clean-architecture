using Core.Domain.Common;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Contexts
{
    public class LogDbContext : DbContext
    {
        public virtual DbSet<RestApiRequestResponse> RestApiRequestResponse { get; set; }
        public virtual DbSet<ExceptionLog> ExceptionsLog { get; set; }

        public LogDbContext(DbContextOptions<LogDbContext> options) : base(options)
        {

        }

        public LogDbContext()
        {

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
