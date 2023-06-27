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

namespace JumpIn.Auction.Domain.Contexts
{
    public class AuctionWriteContext : IWriteContext<AuctionContext>
    {
        private readonly IDesignTimeDbContextFactory<AuctionContext> contextFactory;
        private readonly AuctionContext AuctionContext;


        public AuctionWriteContext(IDesignTimeDbContextFactory<AuctionContext> contextFactory, string connectionString = null)
        {
            var contextArgs = !connectionString.IsNullOrEmpty() ? new string[] { connectionString } : null;
            this.contextFactory = contextFactory;
            AuctionContext = this.contextFactory.CreateDbContext(contextArgs);
        }

        public string GetId()
        {
            return AuctionContext.ContextId.InstanceId.ToString();
        }

        public DatabaseFacade AuctionContextDatabase()
        {
            return AuctionContext.Database;
        }

        public IQueryable<TEntity> Set<TEntity>()
            where TEntity : class
        {
            return AuctionContext.Set<TEntity>();
        }

        public async Task<TEntity> SaveAsync<TEntity>(TEntity entity)
           where TEntity : BaseDataModel
        {
            var entry = AuctionContext.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                AuctionContext.Set<TEntity>().Add(entity);
            }
            else
            {
                entry.State = EntityState.Modified;
            }

            await AuctionContext.SaveChangesAsync();

            return entity;
        }

        public async Task<ICollection<TEntity>> SaveRangeAsync<TEntity>(ICollection<TEntity> entityList)
           where TEntity : BaseDataModel
        {
            var allEntriesDetached = entityList.All(x => AuctionContext.Entry(x).State == EntityState.Detached);
            var someEntriesDetached = entityList.Any(x => AuctionContext.Entry(x).State == EntityState.Detached) && !allEntriesDetached;

            if (allEntriesDetached)
            {
                AuctionContext.Set<TEntity>().AddRange(entityList);
            }
            else if (someEntriesDetached)
            {
                throw new NotImplementedException();
            }
            else
            {
                throw new NotImplementedException();
            }

            await AuctionContext.SaveChangesAsync();

            return entityList;
        }

        public async Task DeleteAsync<TEntity>(TEntity entity)
            where TEntity : BaseDataModel
        {
            AuctionContext.Remove(entity);
            await AuctionContext.SaveChangesAsync();
        }

        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : BaseDomainModel
        {
            return AuctionContext.Entry(entity);
        }

        public async Task<TEntity> GetEntityByIdAsync<TEntity>(int id)
            where TEntity : BaseDataModel
        {
            var existingEntity = await AuctionContext.Set<TEntity>().FindAsync(id);
            
            if (existingEntity is null)
            {
                throw new Exception(); ;
            }

            return existingEntity;
        }

        public async Task SaveAllChanges()
        {
            await AuctionContext.SaveChangesAsync();
        }

        public async Task AddEntityAsync<TEntity>(TEntity entity)
            where TEntity : BaseDataModel
        {
            await AuctionContext.Set<TEntity>().AddAsync(entity);
        }

        public async Task<IDbContextTransaction> BeginTransaction()
        {
            return await AuctionContext.Database.BeginTransactionAsync();
        }

        public async Task CommitTransaction()
        {
            await AuctionContext.Database.CommitTransactionAsync();
        }

        public async Task AddEntityRangeAsync<TEntity>(IReadOnlyList<TEntity> entities)
            where TEntity : BaseDataModel
        {
            await AuctionContext.AddRangeAsync(entities);
        }

        public IQueryable<TEntity> FromSqlInterpolated<TEntity>(FormattableString sql)
            where TEntity : class
        {
            return AuctionContext.Set<TEntity>().FromSqlInterpolated(sql).AsNoTracking();
        }

        public async Task FromSqlInterpolated(FormattableString sql)
        {
            await AuctionContext.Database.ExecuteSqlInterpolatedAsync(sql);
        }

        public IEnumerable<EntityEntry> GetTrackedEntities()
        {
            return AuctionContext.ChangeTracker.Entries()
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
                AuctionContext?.Dispose();
            }
        }
    }
}
