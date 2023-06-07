using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Ocelot.Configuration.File;

namespace JumpIn.Gateway.Utilities
{
    public static class OcelotFileConfigurationExtensions
    {
        public static IServiceCollection ConfigureDownstreamHostForOcelot(this IServiceCollection services, IConfiguration configuration)
        {
            services.PostConfigure<FileConfiguration>(fileConfiguration =>
            {
                foreach (var route in fileConfiguration.Routes)
                {
                    route.DownstreamScheme = "https";

                    if (route.Key == "Admin")
                    {
                        foreach (var downStreamHost in route.DownstreamHostAndPorts)
                        {
                            downStreamHost.Host = configuration.GetValue<string>("OcelotDownStreamHost:adminApiUrl");
                        }
                    }

                    if (route.Key == "Auction")
                    {
                        foreach (var downStreamHost in route.DownstreamHostAndPorts)
                        {
                            downStreamHost.Host = configuration.GetValue<string>("OcelotDownStreamHost:auctionApiUrl");
                        }
                    }
                }
            });

            return services;
        }

        public static string AlterUpstreamSwaggerJson(HttpContext context, string swaggerJson)
        {
            var swagger = JObject.Parse(swaggerJson);
            return swagger.ToString(Formatting.Indented);
        }
    }
}
