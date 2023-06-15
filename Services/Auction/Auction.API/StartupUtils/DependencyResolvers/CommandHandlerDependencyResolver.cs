using JumpIn.Auction.BusinessLogicLayer.CommandHandlers;

namespace JumpIn.Auction.API.StartupUtils.DependencyResolvers
{
    public static class CommandHandlerDependencyResolver
    {
        public static IServiceCollection AddCommandHandlers(this IServiceCollection services)
        {
            services.
                AddUserCommandHandlers();

           return services;
        }

        private static IServiceCollection AddUserCommandHandlers(this IServiceCollection services)
        {
            services
                .AddScoped<CreateBidderCommandHandler>()
                .AddScoped<CreateBidCommandHandler>();

            return services;
        }
    }
}
