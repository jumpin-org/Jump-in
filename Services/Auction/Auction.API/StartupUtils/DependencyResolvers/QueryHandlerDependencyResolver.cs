using JumpIn.Auction.BusinessLogicLayer.QueryHandlers;

namespace JumpIn.Auction.API.StartupUtils.DependencyResolvers
{
    public static class QueryHandlerDependencyResolver
    {
        public static IServiceCollection AddQueryHandlers(this IServiceCollection services)
        {
            services
                .AddBidderQueryHandlers()
                .AddBidQueryHandlers()
                .AddDutchAuctionQueryHandlers();

            return services;
        }

        private static IServiceCollection AddBidderQueryHandlers(this IServiceCollection services)
        {
            services
                .AddScoped<GetAllBiddersHandler>();

            return services;
        }

        private static IServiceCollection AddDutchAuctionQueryHandlers(this IServiceCollection services)
        {
            services
                .AddScoped<GetDutchAuctionsHandler>();

            return services;
        }

        private static IServiceCollection AddBidQueryHandlers(this IServiceCollection services)
        {
            services
                .AddScoped<GetBidsHandler>();

            return services;
        }
    }
}