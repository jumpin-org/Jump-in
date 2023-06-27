using JumpIn.Common.Domain.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpIn.Auction.Domain.Contexts
{
    public class AdminReadOnlyContext : IReadOnlyContext<AdminContext>
    {
        private readonly AdminContext AdminContext;

        public AdminReadOnlyContext(AdminContext AdminContext)
        {
            this.AdminContext = AdminContext;
        }

        public IQueryable<TEntity> Set<TEntity>()
            where TEntity : class
        {
            return AdminContext.Set<TEntity>().AsNoTracking();
        }

        public virtual IQueryable<TEntity> FromSqlInterpolated<TEntity>(FormattableString sql)
            where TEntity : class
        {
            return AdminContext.Set<TEntity>().FromSqlInterpolated(sql).AsNoTracking();
        }

    }
}
