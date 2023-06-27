using JumpIn.Common.Domain.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpIn.Authentication.Domain.Contexts
{
    public class AuthReadOnlyContext : IReadOnlyContext<AuthContext>
    {
        private readonly AuthContext AuthContext;

        public AuthReadOnlyContext(AuthContext AuthContext)
        {
            this.AuthContext = AuthContext;
        }

        public IQueryable<TEntity> Set<TEntity>()
            where TEntity : class
        {
            return AuthContext.Set<TEntity>().AsNoTracking();
        }

        public virtual IQueryable<TEntity> FromSqlInterpolated<TEntity>(FormattableString sql)
            where TEntity : class
        {
            return AuthContext.Set<TEntity>().FromSqlInterpolated(sql).AsNoTracking();
        }

    }
}
