using JumpIn.Common.Domain.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;

namespace JumpIn.Common.Domain.Contexts
{
    public interface IWriteContext<TContext> : IDisposable
        where TContext : class
    {
        Task<TEntity> SaveAsync<TEntity>(TEntity entity)
            where TEntity : BaseDataModel;

        Task DeleteAsync<TEntity>(TEntity entity)
            where TEntity : BaseDataModel;

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : BaseDomainModel;

        IQueryable<TEntity> Set<TEntity>()
            where TEntity : class;

        Task<TEntity> GetEntityByIdAsync<TEntity>(int id)
          where TEntity : BaseDataModel;

        Task SaveAllChanges();

        Task AddEntityAsync<TEntity>(TEntity entity)
          where TEntity : BaseDataModel;

        Task AddEntityRangeAsync<TEntity>(IReadOnlyList<TEntity> entities)
          where TEntity : BaseDataModel;

        Task<IDbContextTransaction> BeginTransaction();

        Task CommitTransaction();

        IQueryable<TEntity> FromSqlInterpolated<TEntity>(FormattableString sql)
            where TEntity : class;

        Task FromSqlInterpolated(FormattableString sql);
    }
}