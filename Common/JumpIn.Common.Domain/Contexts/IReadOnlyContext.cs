namespace Common.Domain.Contexts
{
    public interface IReadOnlyContext<TContext>
        where TContext : class
    {
        IQueryable<TEntity> Set<TEntity>()
            where TEntity : class;

        IQueryable<TEntity> FromSqlInterpolated<TEntity>(FormattableString sql)
            where TEntity : class;
    }
}