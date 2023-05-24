using Common.Domain.Contexts;
using JumpIn.Auction.Domain.Contexts.MigrationExclusions;
using JumpIn.Auction.Domain.Models.Admin;
using JumpIn.Auction.Domain.Models.Auction;
using JumpIn.Common.Domain.Constant;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpIn.Auction.Domain.Contexts
{
    public class AuctionContext : BaseDbContext
    {
        public AuctionContext(DbContextOptions<AuctionContext> options)
            : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<FicaStatus> FicaStatuses { get; set; }
        public DbSet<FicaDetail> FicaDetails { get; set; }

        public DbSet<Seller> Sellers { get; set; }
        public DbSet<AuctionStatus> AuctionStatuses { get; set; }
        public DbSet<DutchAuction> Auctions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Bidder> Bidders { get; set; }
        public DbSet<BidStatus> BidStatuses { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Payment> Payments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AuctionContextExclusions.ExcludeFromMigrations(modelBuilder);

            modelBuilder.HasDefaultSchema(DB.AUCTION_SCHEMA);
            modelBuilder.UseCollation(DB.CASE_INSENSITIVE_COLLATION);
        }
    }
}
