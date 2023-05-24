using JumpIn.Common.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Contexts
{
    public class BaseDbContext : DbContext
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public BaseDbContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor = null)
            : base(options)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ApplyAuditing();
            return await base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            ApplyAuditing();
            return base.SaveChanges();
        }

        private void ApplyAuditing()
        {
            var entries = ChangeTracker
                         .Entries()
                         .Where(e => e.Entity is BaseAuditableEntity && (
                          e.State == EntityState.Added ||
                          e.State == EntityState.Modified ||
                          e.State == EntityState.Deleted));

            foreach (var entityEntry in entries)
            {

                switch (entityEntry.State)
                {
                    case EntityState.Modified:
                        ((BaseAuditableEntity)entityEntry.Entity).DateLastModified = DateTime.UtcNow;
                        ((BaseAuditableEntity)entityEntry.Entity).LastModifiedBy = GetCurrentUser();
                        break;
                    case EntityState.Added:
                        ((BaseAuditableEntity)entityEntry.Entity).DateCreated = DateTime.UtcNow;
                        ((BaseAuditableEntity)entityEntry.Entity).DateDeleted = null;
                        ((BaseAuditableEntity)entityEntry.Entity).CreatedBy = GetCurrentUser();
                        break;
                    case EntityState.Deleted:
                        entityEntry.State = EntityState.Modified;
                        ((BaseAuditableEntity)entityEntry.Entity).DateLastModified = DateTime.UtcNow;
                        ((BaseAuditableEntity)entityEntry.Entity).DateDeleted = DateTime.UtcNow;
                        ((BaseAuditableEntity)entityEntry.Entity).LastModifiedBy = GetCurrentUser();
                        break;
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    default:
                        break;
                }
            }
        }

        private string? GetCurrentUser()
        {
            return httpContextAccessor?.HttpContext is not null
                   && httpContextAccessor.HttpContext.User is not null
                   && httpContextAccessor.HttpContext.User.Identity is not null
                   ? null
                   : httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
