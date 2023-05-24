﻿using JumpIn.Auction.Domain.Contexts;
using JumpIn.Common.Domain.Constant;
using Microsoft.EntityFrameworkCore;

namespace JumpIn.Auction.API.StartupUtils.DependencyResolvers
{
    public static class DBContextDependencyResolver
    {
        public static void AddDBContexts(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AuctionContext>(options => options.UseSqlServer(connectionString))
                    .AddDbContext<AdminContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
