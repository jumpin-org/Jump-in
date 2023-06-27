using JumpIn.Common.Domain.Contexts;
using JumpIn.Auction.Domain.Contexts.MigrationExclusions;
using JumpIn.Auction.Domain.Models.Admin;
using JumpIn.Auction.Domain.Models.Auction;
using JumpIn.Auction.Domain.Seeders;
using JumpIn.Common.Domain.Constant;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Logging;

namespace JumpIn.Auction.Domain.Contexts
{
    public class AuctionContext : BaseDbContext
    {
        private readonly IConfiguration config;
        private readonly IHostEnvironment env;

        public AuctionContext(DbContextOptions<AuctionContext> options, IConfiguration config, IHostEnvironment env, IHttpContextAccessor httpContextAccessor = null)
            : base(options, httpContextAccessor)
        {
            this.config = config;
            this.env = env is null ? new HostingEnvironment() { ContentRootPath = Directory.GetCurrentDirectory() } : env;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<FicaStatus> FicaStatuses { get; set; }
        public DbSet<FicaDetail> FicaDetails { get; set; }

        public DbSet<Seller> Sellers { get; set; }
        public DbSet<AuctionStatus> AuctionStatuses { get; set; }
        public DbSet<DutchAuction> DutchAuctions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Bidder> Bidders { get; set; }
        public DbSet<BidStatus> BidStatuses { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Payment> Payments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder is null)
            {
                throw new ArgumentNullException(nameof(optionsBuilder));
            }

            if (!optionsBuilder.IsConfigured)
            {
               optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AuctionContextExclusions.ExcludeFromMigrations(modelBuilder);

            modelBuilder.HasDefaultSchema(DB.AUCTION_SCHEMA);
            modelBuilder.UseCollation(DB.CASE_INSENSITIVE_COLLATION);

            var userTableName = nameof(AuctionContext.Users);
            modelBuilder.Entity<User>().ToTable(userTableName, DB.ADMIN_SCHEMA);

            var administratorTableName = nameof(AdminContext.Administrators);
            modelBuilder.Entity<Administrator>().ToTable(administratorTableName, DB.ADMIN_SCHEMA);

            var accountTableName = nameof(AuctionContext.Accounts);
            modelBuilder.Entity<Account>().ToTable(accountTableName, DB.ADMIN_SCHEMA);

            AuctionSeeders.SeedSeller(modelBuilder);
            AuctionSeeders.SeedAuctionStatus(modelBuilder);
            AuctionSeeders.SeedDutchAuction(modelBuilder);
            AuctionSeeders.SeedProduct(modelBuilder);
            AuctionSeeders.SeedBidder(modelBuilder);
            AuctionSeeders.SeedBidStatus(modelBuilder);
            AuctionSeeders.SeedBid(modelBuilder);
            AuctionSeeders.SeedPayment(modelBuilder);
        }
    }
}
