using JumpIn.Auction.BusinessLogicLayer.QueryHandlers;

namespace JumpIn.Auction.API.StartupUtils.DependencyResolvers
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
                .AddScoped<GetAllBiddersHandler>()
                .AddScoped<GetBidsHandler>();

            return services;
        }
    }
}