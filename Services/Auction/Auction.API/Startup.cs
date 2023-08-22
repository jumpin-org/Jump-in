using JumpIn.Auction.API.Hubs;
using JumpIn.Auction.API.StartupUtils;
using JumpIn.Auction.API.StartupUtils.DependencyResolvers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;

namespace JumpIn.Auction.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                var webPortalOrigin = Configuration.GetValue<string>("AllowedOrigins:WebPortal") ?? "";
                options.AddPolicy(name: "CorsPolicy",
                                  policy =>
                                  {
                                      policy.WithOrigins(webPortalOrigin);
                                      policy.AllowAnyHeader();
                                      policy.AllowAnyMethod();
                                      policy.AllowCredentials();
                                  });
            });

            services.AddDBContexts(Environment.GetEnvironmentVariable("DB_CONNECTION"));

            services
                .AddCommandHandlers()
                .AddQueryHandlers();

            services.AddControllers();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddMicrosoftIdentityWebApi(Configuration.GetSection("AzureAd"));

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Auction", Version = "v1" });
            });

            services.AddSignalR();

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("CorsPolicy");

            if (env.IsDevelopment())
            {
                app.UseExceptionHandler(
                  new ExceptionHandlerOptions()
                  {
                      AllowStatusCode404Response = true,
                      ExceptionHandlingPath = "/error"
                  });
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            SeedDatabase.PrePopulation(app);

            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapHub<AuctionHub>("auction-hub");
            });
        }
    }
}
