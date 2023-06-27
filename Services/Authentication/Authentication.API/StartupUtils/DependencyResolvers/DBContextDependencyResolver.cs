using JumpIn.Common.Domain.Contexts;
using JumpIn.Authentication.Domain.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace JumpIn.Authentication.API.StartupUtils.DependencyResolvers
{
    public static class DBContextDependencyResolver
    {
        public static void AddDBContexts(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AuthContext>(options => options.UseSqlServer(connectionString))
                    .AddAuthContext(connectionString);
        }

        private static IServiceCollection AddAuthContext(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<AuthReadOnlyContext>()
                    .AddTransient<IDesignTimeDbContextFactory<AuthContext>, AuthContextFactory>()
                    .AddTransient<IWriteContext<AuthContext>>(x => new AuthWriteContext(
                        x.GetRequiredService<IDesignTimeDbContextFactory<AuthContext>>(),
                        x.GetRequiredService<ILogger<AuthWriteContext>>(),
                    connectionString))
                    .AddTransient(x => new AuthWriteContext(
                        x.GetRequiredService<IDesignTimeDbContextFactory<AuthContext>>(),
                                            x.GetRequiredService<ILogger<AuthWriteContext>>(),
                    connectionString));

            return services;
        }
    }
}
