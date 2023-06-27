using JumpIn.Common.Domain.Contexts;
using JumpIn.Auction.Domain.Contexts;
using JumpIn.Auction.Domain.Models.Admin;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace JumpIn.Auction.API.StartupUtils
{
    public static class SeedDatabase
    {
        public static void PrePopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetRequiredService<AdminContext>());
                SeedData(serviceScope.ServiceProvider.GetRequiredService<AuctionContext>());
            }
        }

        public static void SeedData(BaseDbContext context)
        {
            Console.WriteLine($"Applying Migrations {context.Database.ToString()}");
            context.Database.Migrate();
            Console.WriteLine($"Migrations Applied {context.Database.ToString()}");
        }
    }
}
