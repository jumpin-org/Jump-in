using Common.Domain.Contexts;
using JumpIn.Common.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpIn.Auction.Domain.Contexts
{
    public class AdminWriteContext : IWriteContext<AdminContext>
    {
        private readonly IDesignTimeDbContextFactory<AdminContext> contextFactory;
        private readonly AdminContext adminContext;
        private readonly ILogger<AdminWriteContext> logger;


        public AdminWriteContext(IDesignTimeDbContextFactory<AdminContext> contextFactory, ILogger<AdminWriteContext> logger, string connectionString = null)
        {
            var contextArgs = !connectionString.IsNullOrEmpty() ? new string[] { connectionString } : null;
            this.contextFactory = contextFactory;
            adminContext = this.contextFactory.CreateDbContext(contextArgs);
            this.logger = logger;
        }

        public string GetId()
        {
            return adminContext.ContextId.InstanceId.ToString();
        }

        public DatabaseFacade AdminContextDatabase()
        {
            return adminContext.Database;
        }

        public IQueryable<TEntity> Set<TEntity>()
            where TEntity : class
        {
            return adminContext.Set<TEntity>();
        }

        public async Task<TEntity> SaveAsync<TEntity>(TEntity entity)
           where TEntity : BaseDataModel
        {
            var entry = adminContext.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                adminContext.Set<TEntity>().Add(entity);
            }
            else
            {
                entry.State = EntityState.Modified;
            }

            await adminContext.SaveChangesAsync();

            return entity;
        }

        public async Task<ICollection<TEntity>> SaveRangeAsync<TEntity>(ICollection<TEntity> entityList)
           where TEntity : BaseDataModel
        {
            var allEntriesDetached = entityList.All(x => adminContext.Entry(x).State == EntityState.Detached);
            var someEntriesDetached = entityList.Any(x => adminContext.Entry(x).State == EntityState.Detached) && !allEntriesDetached;

            if (allEntriesDetached)
            {
                adminContext.Set<TEntity>().AddRange(entityList);
            }
            else if (someEntriesDetached)
            {
                throw new NotImplementedException();
            }
            else
            {
                throw new NotImplementedException();
            }

            await adminContext.SaveChangesAsync();

            return entityList;
        }

        public async Task DeleteAsync<TEntity>(TEntity entity)
            where TEntity : BaseDataModel
        {
            adminContext.Remove(entity);
            await adminContext.SaveChangesAsync();
        }

        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : BaseDomainModel
        {
            return adminContext.Entry(entity);
        }

        public async Task<TEntity> GetEntityByIdAsync<TEntity>(int id)
            where TEntity : BaseDataModel
        {
            var existingEntity = await adminContext.Set<TEntity>().FindAsync(id);
            
            if (existingEntity is null)
            {
                logger.LogWarning($"No record with the ID [{id}] could be found.");
                throw new Exception();
            }

            return existingEntity;
        }

        public async Task SaveAllChanges()
        {
            await adminContext.SaveChangesAsync();
        }

        public async Task AddEntityAsync<TEntity>(TEntity entity)
            where TEntity : BaseDataModel
        {
            await adminContext.Set<TEntity>().AddAsync(entity);
        }

        public async Task<IDbContextTransaction> BeginTransaction()
        {
            return await adminContext.Database.BeginTransactionAsync();
        }

        public async Task CommitTransaction()
        {
            await adminContext.Database.CommitTransactionAsync();
        }

        public async Task AddEntityRangeAsync<TEntity>(IReadOnlyList<TEntity> entities)
            where TEntity : BaseDataModel
        {
            await adminContext.AddRangeAsync(entities);
        }

        public IQueryable<TEntity> FromSqlInterpolated<TEntity>(FormattableString sql)
            where TEntity : class
        {
            return adminContext.Set<TEntity>().FromSqlInterpolated(sql).AsNoTracking();
        }

        public async Task FromSqlInterpolated(FormattableString sql)
        {
            await adminContext.Database.ExecuteSqlInterpolatedAsync(sql);
        }

        public IEnumerable<EntityEntry> GetTrackedEntities()
        {
            return adminContext.ChangeTracker.Entries()
                .Where(t => t.State == EntityState.Modified);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                adminContext?.Dispose();
            }
        }
    }
}
