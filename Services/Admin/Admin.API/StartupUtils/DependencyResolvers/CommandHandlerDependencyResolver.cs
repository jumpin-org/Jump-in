using JumpIn.Admin.BusinessLogicLayer.CommandHandlers;

namespace JumpIn.Admin.API.StartupUtils.DependencyResolvers
{
    public static class CommandHandlerDependencyResolver
    {
        public static IServiceCollection AddCommandHandlers(this IServiceCollection services)
        {
            services
               .AddUserCommandHandlers()
               .AddAdministratorCommandHandlers()
               .AddAccountCommandHandlers();

           return services;
        }

        private static IServiceCollection AddUserCommandHandlers(this IServiceCollection services)
        {
            services
                .AddScoped<CreateUserCommandHandler>()
                .AddScoped<UpdateUserCommandHandler>();

            return services;
        }

        private static IServiceCollection AddAdministratorCommandHandlers(this IServiceCollection services)
        {
            services
                .AddScoped<CreateAdministratorCommandHandler>();

            return services;
        }

        private static IServiceCollection AddAccountCommandHandlers(this IServiceCollection services)
        {
            services
                .AddScoped<CreateAccountCommandHandler>();

            return services;
        }
    }
}
