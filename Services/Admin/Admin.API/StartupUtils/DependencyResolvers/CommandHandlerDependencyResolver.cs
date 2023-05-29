using JumpIn.Admin.BusinessLogicLayer.CommandHandlers;

namespace JumpIn.Admin.API.StartupUtils.DependencyResolvers
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
                .AddScoped<CreateUserCommandHandler>()
                .AddScoped<UpdateUserCommandHandler>();

            return services;
        }
    }
}
