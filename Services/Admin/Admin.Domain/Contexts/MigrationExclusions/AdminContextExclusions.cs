using Admin.Domain.Modles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JumpIn.Admin.Domain.Contexts.MigrationExclusions
{
    public class AdminContextExclusions
    {
        public static void ExcludeFromMigrations(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.Entity<Seller>().ToTable(nameof(Seller), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<AuctionStatus>().ToTable(nameof(AuctionStatus), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<Auction>().ToTable(nameof(Auction), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<Product>().ToTable(nameof(Product), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<Bidder>().ToTable(nameof(Bidder), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<BidStatus>().ToTable(nameof(BidStatus), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<Bid>().ToTable(nameof(Bid), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<Payment>().ToTable(nameof(Payment), t => t.ExcludeFromMigrations());
        }
    }
}
