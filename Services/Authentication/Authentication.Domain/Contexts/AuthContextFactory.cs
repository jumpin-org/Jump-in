using JumpIn.Common.Domain.Constant;
using JumpIn.Common.Utility.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace JumpIn.Authentication.Domain.Contexts
{
    public class AuthContextFactory : IDesignTimeDbContextFactory<AuthContext>
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IHostEnvironment env;

        public AuthContextFactory(IHostEnvironment env, IHttpContextAccessor httpContextAccessor = null)
        {
            this.env = env;
            this.httpContextAccessor = httpContextAccessor;
        }

        public AuthContextFactory()
        {
        }

        public AuthContext CreateDbContext(string[] args)
        {
            if (args is null || args.Length == 0)
            {
                return new AuthContext(new DbContextOptionsBuilder<AuthContext>().Options, null, env, httpContextAccessor);
            }

            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile($"appsettings.{env.EnvironmentName}.json").Build();

            var optionsBuilder = new DbContextOptionsBuilder<AuthContext>();
            optionsBuilder.UseSqlServer(DBConnectionHelper.GetConnectionString());

            return new AuthContext(optionsBuilder.Options, config, env);
        }
    }
}
