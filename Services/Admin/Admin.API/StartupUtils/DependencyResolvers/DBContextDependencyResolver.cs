using Admin.Domain.Contexts;
using Microsoft.EntityFrameworkCore;

namespace JumpIn.Admin.API.StartupUtils.DependencyResolvers
{
    public static class DBContextDependencyResolver
    {
        public static void AddDBContexts(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AdminContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
