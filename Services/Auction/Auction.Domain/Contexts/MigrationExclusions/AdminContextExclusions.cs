using JumpIn.Auction.Domain.Models.Admin;
using JumpIn.Auction.Domain.Models.Auction;
using Microsoft.EntityFrameworkCore;

namespace JumpIn.Auction.Domain.Contexts.MigrationExclusions
{
    public static class AdminContextExclusions
    {
        public static void ExcludeFromMigrations(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.Entity<Seller>().ToTable(nameof(Seller), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<AuctionStatus>().ToTable(nameof(AuctionStatus), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<DutchAuction>().ToTable(nameof(DutchAuction), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<Bidder>().ToTable(nameof(Bidder), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<BidStatus>().ToTable(nameof(BidStatus), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<Bid>().ToTable(nameof(Bid), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<Payment>().ToTable(nameof(Payment), t => t.ExcludeFromMigrations());
        }
    }
}
