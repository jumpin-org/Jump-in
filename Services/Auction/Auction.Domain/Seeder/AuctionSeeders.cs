using JumpIn.Auction.Domain.Contexts;
using JumpIn.Auction.Domain.Models.Admin;
using JumpIn.Auction.Domain.Models.Auction;
using JumpIn.Common.Domain.Constant;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpIn.Auction.Domain.Seeders
{
    public static class AuctionSeeders
    {
        public static void SeedSeller(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            var acccountTableName = nameof(AuctionContext.Accounts);
            modelBuilder.Entity<Account>().ToTable(acccountTableName, DB.ADMIN_SCHEMA);

            modelBuilder.Entity<Seller>()
            .HasOne(x => x.Account)
            .WithOne(x => x.Seller)
            .IsRequired();
        }

        public static void SeedAuctionStatus(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }
        }

        public static void SeedDutchAuction(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.Entity<DutchAuction>()
            .HasOne(x => x.AuctionStatus)
            .WithMany(x => x.DutchAuctions)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .IsRequired();

            var administratorTableName = nameof(AdminContext.Administrators);
            modelBuilder.Entity<Administrator>().ToTable(administratorTableName, DB.ADMIN_SCHEMA);

            modelBuilder.Entity<Administrator>()
            .HasMany(x => x.DutchAuctions)
            .WithOne(x => x.Administrator)
            .IsRequired();

            modelBuilder.Entity<DutchAuction>()
            .Property(p => p.StartPrice)
            .HasColumnType("decimal(18,4)");

            modelBuilder.Entity<DutchAuction>()
            .Property(p => p.CurrentPrice)
            .HasColumnType("decimal(18,4)");

            modelBuilder.Entity<DutchAuction>()
            .Property(p => p.Decrement)
            .HasColumnType("decimal(18,4)");
        }

        public static void SeedProduct(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.Entity<Product>()
            .HasOne(x => x.DutchAuction)
            .WithOne(x => x.Product)
            .HasForeignKey<Product>(e => e.DutchAuctionId)
            .IsRequired();

            modelBuilder.Entity<Product>()
            .Property(p => p.CurrentPrice)
            .HasColumnType("decimal(18,4)");

            modelBuilder.Entity<Product>()
            .Property(p => p.Weight)
            .HasColumnType("decimal(18,4)");
        }

        public static void SeedBidder(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            var acccountTableName = nameof(AuctionContext.Accounts);
            modelBuilder.Entity<Account>().ToTable(acccountTableName, DB.ADMIN_SCHEMA);

            modelBuilder.Entity<Bidder>()
            .HasOne(x => x.Account)
            .WithOne(x => x.Bidder)
            .IsRequired();
        }

        public static void SeedBidStatus(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }
        }

        public static void SeedBid(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.Entity<Bid>()
            .HasOne(x => x.BidStatus)
            .WithMany(x => x.Bids)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .IsRequired();

            modelBuilder.Entity<Bid>()
             .HasOne(x => x.DutchAuction)
             .WithMany(x => x.Bids)
             .IsRequired();

            modelBuilder.Entity<Bid>()
            .HasOne(x => x.Bidder)
            .WithMany(x => x.Bids)
            .IsRequired();

            modelBuilder.Entity<Bid>()
            .Property(p => p.Amount)
            .HasColumnType("decimal(18,4)");
        }

        public static void SeedPayment(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.Entity<Payment>()
            .HasOne(x => x.Bid)
            .WithMany(x => x.Payments)
            .IsRequired();

            modelBuilder.Entity<Payment>()
            .Property(p => p.Amount)
            .HasColumnType("decimal(18,4)");
        }
    }
}