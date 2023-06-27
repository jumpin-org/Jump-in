using JumpIn.Common.Domain.Contexts;
using JumpIn.Auction.Domain.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace JumpIn.Auction.API.StartupUtils.DependencyResolvers
{
    public static class DBContextDependencyResolver
    {
        public static void AddDBContexts(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AuctionContext>(options => options.UseSqlServer(connectionString))
                    .AddDbContext<AdminContext>(options => options.UseSqlServer(connectionString))
                    .AddAuctionContext(connectionString);
        }

        private static IServiceCollection AddAuctionContext(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<AuctionReadOnlyContext>()
                    .AddTransient<IDesignTimeDbContextFactory<AuctionContext>, AuctionContextFactory>()
                    .AddTransient<IWriteContext<AuctionContext>>(x => new AuctionWriteContext(
                        x.GetRequiredService<IDesignTimeDbContextFactory<AuctionContext>>(),
                    connectionString))
                    .AddTransient(x => new AuctionWriteContext(
                        x.GetRequiredService<IDesignTimeDbContextFactory<AuctionContext>>(),
                    connectionString));

            return services;
        }
    }
}
