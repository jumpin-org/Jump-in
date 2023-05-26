using Common.Domain.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpIn.Auction.Domain.Contexts
{
    public class AuctionReadOnlyContext : IReadOnlyContext<AuctionContext>
    {
        private readonly AuctionContext AuctionContext;

        public AuctionReadOnlyContext(AuctionContext AuctionContext)
        {
            this.AuctionContext = AuctionContext;
        }

        public IQueryable<TEntity> Set<TEntity>()
            where TEntity : class
        {
            return AuctionContext.Set<TEntity>().AsNoTracking();
        }

        public virtual IQueryable<TEntity> FromSqlInterpolated<TEntity>(FormattableString sql)
            where TEntity : class
        {
            return AuctionContext.Set<TEntity>().FromSqlInterpolated(sql).AsNoTracking();
        }

    }
}
