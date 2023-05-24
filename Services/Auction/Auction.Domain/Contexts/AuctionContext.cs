using Common.Domain.Contexts;
using JumpIn.Auction.Domain.Contexts.MigrationExclusions;
using JumpIn.Auction.Domain.Models.Admin;
using JumpIn.Auction.Domain.Models.Auction;
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
        public DbSet<DutchAuction> Auctions { get; set; }
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
               optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionStrings__Default"), options => options.MigrationsAssembly(DB.MIGRATION_PROJECT_ASSEMBLY));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AuctionContextExclusions.ExcludeFromMigrations(modelBuilder);

            modelBuilder.HasDefaultSchema(DB.AUCTION_SCHEMA);
            modelBuilder.UseCollation(DB.CASE_INSENSITIVE_COLLATION);
        }
    }
}
