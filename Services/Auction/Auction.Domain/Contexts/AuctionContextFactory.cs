using JumpIn.Common.Domain.Constant;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace JumpIn.Auction.Domain.Contexts
{
    public class AuctionContextFactory : IDesignTimeDbContextFactory<AuctionContext>
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IHostEnvironment env;

        public AuctionContextFactory(IHostEnvironment env, IHttpContextAccessor httpContextAccessor = null)
        {
            this.env = env;
            this.httpContextAccessor = httpContextAccessor;
        }

        public AuctionContextFactory()
        {
        }

        public AuctionContext CreateDbContext(string[] args)
        {
            if (args is null || args.Length == 0)
            {
                return new AuctionContext(new DbContextOptionsBuilder<AuctionContext>().Options, null, env, httpContextAccessor);
            }

            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile($"appsettings.{env.EnvironmentName}.json").Build();

            var optionsBuilder = new DbContextOptionsBuilder<AuctionContext>();
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionStrings__Default"));

            return new AuctionContext(optionsBuilder.Options, config, env);
        }
    }
}
    