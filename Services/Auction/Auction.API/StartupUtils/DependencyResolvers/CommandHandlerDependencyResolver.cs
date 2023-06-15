using JumpIn.Auction.BusinessLogicLayer.CommandHandlers;

namespace JumpIn.Auction.API.StartupUtils.DependencyResolvers
{
    public static class CommandHandlerDependencyResolver
    {
        public static IServiceCollection AddCommandHandlers(this IServiceCollection services)
        {
            services.
                AddAuctionCommandHandlers();

           return services;
        }

        private static IServiceCollection AddAuctionCommandHandlers(this IServiceCollection services)
        {
            services
                .AddScoped<CreateBidderCommandHandler>()
                .AddScoped<CreateBidCommandHandler>()
                .AddScoped < CreateDutchAuctionCommandHandler>();
            return services;
        }
    }
}
