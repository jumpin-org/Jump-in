using JumpIn.Auction.Domain.Contexts;
using JumpIn.Auction.Domain.Models.Admin;
using JumpIn.Auction.Domain.Models.Auction;
using JumpIn.Common.Domain.Constant;
using JumpIn.Common.Domain.Enums;
using JumpIn.Common.Domain.Helpers;
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

            modelBuilder.Entity<AuctionStatus>()
            .HasData(
                new { Id = AuctionStatusEnum.New, Name = AuctionStatusEnum.New.GetEnumDescription(), Description = AuctionStatusEnum.New.GetEnumDescription() },
                new { Id = AuctionStatusEnum.Active, Name = AuctionStatusEnum.Active.GetEnumDescription(), Description = AuctionStatusEnum.Active.GetEnumDescription() },
                new { Id = AuctionStatusEnum.Started, Name = AuctionStatusEnum.Started.GetEnumDescription(), Description = AuctionStatusEnum.Started.GetEnumDescription() },
                new { Id = AuctionStatusEnum.InProgress, Name = AuctionStatusEnum.InProgress.GetEnumDescription(), Description = AuctionStatusEnum.InProgress.GetEnumDescription() },
                new { Id = AuctionStatusEnum.Ended, Name = AuctionStatusEnum.Ended.GetEnumDescription(), Description = AuctionStatusEnum.Ended.GetEnumDescription() },
                new { Id = AuctionStatusEnum.Closed, Name = AuctionStatusEnum.Closed.GetEnumDescription(), Description = AuctionStatusEnum.Closed.GetEnumDescription() },
                new { Id = AuctionStatusEnum.Deactivated, Name = AuctionStatusEnum.Deactivated.GetEnumDescription(), Description = AuctionStatusEnum.Deactivated.GetEnumDescription() }
                );
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

            modelBuilder.Entity<DutchAuction>()
            .HasOne(x => x.Seller)
            .WithMany(x => x.DutchAuctions)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .IsRequired();

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

            modelBuilder.Entity<BidStatus>()
            .HasData(
                new { Id = BidStatusEnum.New, Name = BidStatusEnum.New.GetEnumDescription(), Description = BidStatusEnum.New.GetEnumDescription() },
                new { Id = BidStatusEnum.Placed, Name = BidStatusEnum.Placed.GetEnumDescription(), Description = BidStatusEnum.Placed.GetEnumDescription() },
                new { Id = BidStatusEnum.Active, Name = BidStatusEnum.Active.GetEnumDescription(), Description = BidStatusEnum.Active.GetEnumDescription() },
                new { Id = BidStatusEnum.Highest, Name = BidStatusEnum.Highest.GetEnumDescription(), Description = BidStatusEnum.Highest.GetEnumDescription() },
                new { Id = BidStatusEnum.Lowest, Name = BidStatusEnum.Lowest.GetEnumDescription(), Description = BidStatusEnum.Lowest.GetEnumDescription() },
                new { Id = BidStatusEnum.Revoked, Name = BidStatusEnum.Revoked.GetEnumDescription(), Description = BidStatusEnum.Revoked.GetEnumDescription() },
                new { Id = BidStatusEnum.Invalid, Name = BidStatusEnum.Invalid.GetEnumDescription(), Description = BidStatusEnum.Invalid.GetEnumDescription() }
                );
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
             .OnDelete(DeleteBehavior.ClientSetNull)
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