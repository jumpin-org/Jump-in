using JumpIn.Common.Domain.Constant;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace JumpIn.Auction.Domain.Contexts
{
    public class AdminContextFactory : IDesignTimeDbContextFactory<AdminContext>
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IHostEnvironment env;

        public AdminContextFactory(IHostEnvironment env, IHttpContextAccessor httpContextAccessor = null)
        {
            this.env = env;
            this.httpContextAccessor = httpContextAccessor;
        }

        public AdminContextFactory()
        {
        }

        public AdminContext CreateDbContext(string[] args)
        {
            if (args is null || args.Length == 0)
            {
                return new AdminContext(new DbContextOptionsBuilder<AdminContext>().Options, null, env, httpContextAccessor);
            }

            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile($"appsettings.{env.EnvironmentName}.json").Build();

            var optionsBuilder = new DbContextOptionsBuilder<AdminContext>();
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionStrings__Default"));

            return new AdminContext(optionsBuilder.Options, config, env);
        }
    }
}
