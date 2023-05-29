using Common.Domain.Contexts;
using JumpIn.Admin.Domain.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Internal;

namespace JumpIn.Admin.API.StartupUtils.DependencyResolvers
{
    public static class DBContextDependencyResolver
    {
        public static void AddDBContexts(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AdminContext>(options => options.UseSqlServer(connectionString))
                    .AddAdminContext(connectionString); ;
        }

        private static IServiceCollection AddAdminContext(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<IDesignTimeDbContextFactory<AdminContext>, AdminContextFactory>()
                    .AddTransient<IWriteContext<AdminContext>>(x => new AdminWriteContext(
                        x.GetRequiredService<IDesignTimeDbContextFactory<AdminContext>>(),
                    connectionString))
                    .AddTransient(x => new AdminWriteContext(
                        x.GetRequiredService<IDesignTimeDbContextFactory<AdminContext>>(),
                    connectionString));

            return services;
        }
    }
}
