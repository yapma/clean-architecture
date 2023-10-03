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
        public DbSet<RestApiRequestResponse> RestApiRequestResponse { get; set; }

        public LogDbContext(DbContextOptions<LogDbContext> options) : base(options)
        {

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries<BaseEntity<dynamic>>())
            {
                if (item.State == EntityState.Added)
                    item.Entity.CreateDate = DateTime.Now;
                else if (item.State == EntityState.Modified)
                    item.Entity.ModifyDate = DateTime.Now;
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
