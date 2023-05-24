using JumpIn.Auction.API;
using JumpIn.Auction.Domain.Contexts;
using JumpIn.Common.Domain.Constant;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Web;
using System.Configuration;
using System.Reflection;

public class Program
{
    public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();
    public static IHostBuilder CreateHostBuilder(string[] args) 
    {
        var assemblyName = typeof(Startup).GetTypeInfo().Assembly.FullName;

        return Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup(assemblyName);
            })
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                var env = hostingContext.HostingEnvironment;

                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                      .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                      .AddEnvironmentVariables();
            });
    }
}