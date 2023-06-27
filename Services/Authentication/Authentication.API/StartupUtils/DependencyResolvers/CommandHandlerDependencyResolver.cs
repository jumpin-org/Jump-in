using JumpIn.Authentication.Domain.CommandHandlers;

namespace JumpIn.Authentication.API.StartupUtils.DependencyResolvers
{
    public static class CommandHandlerDependencyResolver
    {
        public static IServiceCollection AddCommandHandlers(this IServiceCollection services)
        {
            services
               .AddScoped<LoginCommandHandler>();

           return services;
        }
    }
}
