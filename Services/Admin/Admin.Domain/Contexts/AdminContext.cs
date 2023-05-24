using Admin.Domain.Modles;
using Common.Domain.Contexts;
using JumpIn.Common.Domain.Constant;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace Admin.Domain.Contexts
{
    public class AdminContext : BaseDbContext
    {
        private static readonly ILoggerFactory AdminContextLoggerFactory = LoggerFactory.Create(builder => { builder.AddLog4Net(); });

        public AdminContext(DbContextOptions<AdminContext> options)
           : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<FicaStatus> FicaStatuses { get; set; }
        public DbSet<FicaDetail> FicaDetails { get; set; }

        public DbSet<Seller> Sellers { get; set; }
        public DbSet<AuctionStatus> AuctionStatuses { get; set; }
        public DbSet<Auction> Auctions { get; set; }
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
                optionsBuilder.UseSqlServer("Server=jumpin;Database=admin;User=sa;Password=S3cur3P@ssW0rd!;S3cur3P@ssW0rd!;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(DB.ADMIN_SCHEMA);
            modelBuilder.UseCollation(DB.CASE_INSENSITIVE_COLLATION);
        }

    }
}
