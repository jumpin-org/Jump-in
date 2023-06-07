using JumpIn.Admin.BusinessLogicLayer.QueryHandlers;

namespace JumpIn.Admin.API.StartupUtils.DependencyResolvers
{
    public static class QueryHandlerDependencyResolver
    {
        public static IServiceCollection AddQueryHandlers(this IServiceCollection services)
        {
            services.
                AddUserQueryHandlers();

            return services;
        }

        private static IServiceCollection AddUserQueryHandlers(this IServiceCollection services)
        {
            services
                .AddScoped<GetAllUsersHandler>();

            return services;
        }
    }
}