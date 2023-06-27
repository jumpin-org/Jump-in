using JumpIn.Common.Domain.Contexts;
using JumpIn.Common.Domain.Models;
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

namespace JumpIn.Authentication.Domain.Contexts
{
    public class AuthWriteContext : IWriteContext<AuthContext>
    {
        private readonly IDesignTimeDbContextFactory<AuthContext> contextFactory;
        private readonly AuthContext AuthContext;
        private readonly ILogger<AuthWriteContext> logger;


        public AuthWriteContext(IDesignTimeDbContextFactory<AuthContext> contextFactory, ILogger<AuthWriteContext> logger, string connectionString = null)
        {
            var contextArgs = !connectionString.IsNullOrEmpty() ? new string[] { connectionString } : null;
            this.contextFactory = contextFactory;
            AuthContext = this.contextFactory.CreateDbContext(contextArgs);
            this.logger = logger;
        }

        public string GetId()
        {
            return AuthContext.ContextId.InstanceId.ToString();
        }

        public DatabaseFacade AuthContextDatabase()
        {
            return AuthContext.Database;
        }

        public IQueryable<TEntity> Set<TEntity>()
            where TEntity : class
        {
            return AuthContext.Set<TEntity>();
        }

        public async Task<TEntity> SaveAsync<TEntity>(TEntity entity)
           where TEntity : BaseDataModel
        {
            var entry = AuthContext.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                AuthContext.Set<TEntity>().Add(entity);
            }
            else
            {
                entry.State = EntityState.Modified;
            }

            await AuthContext.SaveChangesAsync();

            return entity;
        }

        public async Task<ICollection<TEntity>> SaveRangeAsync<TEntity>(ICollection<TEntity> entityList)
           where TEntity : BaseDataModel
        {
            var allEntriesDetached = entityList.All(x => AuthContext.Entry(x).State == EntityState.Detached);
            var someEntriesDetached = entityList.Any(x => AuthContext.Entry(x).State == EntityState.Detached) && !allEntriesDetached;

            if (allEntriesDetached)
            {
                AuthContext.Set<TEntity>().AddRange(entityList);
            }
            else if (someEntriesDetached)
            {
                throw new NotImplementedException();
            }
            else
            {
                throw new NotImplementedException();
            }

            await AuthContext.SaveChangesAsync();

            return entityList;
        }

        public async Task DeleteAsync<TEntity>(TEntity entity)
            where TEntity : BaseDataModel
        {
            AuthContext.Remove(entity);
            await AuthContext.SaveChangesAsync();
        }

        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : BaseDomainModel
        {
            return AuthContext.Entry(entity);
        }

        public async Task<TEntity> GetEntityByIdAsync<TEntity>(int id)
            where TEntity : BaseDataModel
        {
            var existingEntity = await AuthContext.Set<TEntity>().FindAsync(id);
            
            if (existingEntity is null)
            {
                throw new Exception(); ;
            }

            return existingEntity;
        }

        public async Task SaveAllChanges()
        {
            await AuthContext.SaveChangesAsync();
        }

        public async Task AddEntityAsync<TEntity>(TEntity entity)
            where TEntity : BaseDataModel
        {
            await AuthContext.Set<TEntity>().AddAsync(entity);
        }

        public async Task<IDbContextTransaction> BeginTransaction()
        {
            return await AuthContext.Database.BeginTransactionAsync();
        }

        public async Task CommitTransaction()
        {
            await AuthContext.Database.CommitTransactionAsync();
        }

        public async Task AddEntityRangeAsync<TEntity>(IReadOnlyList<TEntity> entities)
            where TEntity : BaseDataModel
        {
            await AuthContext.AddRangeAsync(entities);
        }

        public IQueryable<TEntity> FromSqlInterpolated<TEntity>(FormattableString sql)
            where TEntity : class
        {
            return AuthContext.Set<TEntity>().FromSqlInterpolated(sql).AsNoTracking();
        }

        public async Task FromSqlInterpolated(FormattableString sql)
        {
            await AuthContext.Database.ExecuteSqlInterpolatedAsync(sql);
        }

        public IEnumerable<EntityEntry> GetTrackedEntities()
        {
            return AuthContext.ChangeTracker.Entries()
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
                AuthContext?.Dispose();
            }
        }
    }
}
