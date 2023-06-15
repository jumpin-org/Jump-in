using JumpIn.Auction.Domain.Contexts;
using JumpIn.Auction.Domain.Models.Admin;
using JumpIn.Auction.Domain.Models.Auction;
using JumpIn.Common.Domain.Constant;
using JumpIn.Common.Domain.Enums;
using JumpIn.Common.Domain.Helpers;
using JumpIn.Common.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JumpIn.Auction.Domain.Seeders
{
    public static class AdminSeeders
    {
        public const string DEFAULT_DATE_VALUE = "NOW()";

        public static void SeedBaseAuditableEntity(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.Entity<BaseAuditableEntity>()
            .Property(b => b.CreatedBy)
            .HasDefaultValueSql(DEFAULT_DATE_VALUE);
        }

        public static void SeedUser(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.Entity<User>()
            .HasOne(x => x.Account)
            .WithOne(x => x.User)
            .HasForeignKey<Account>(e => e.UserId)
            .IsRequired();

            modelBuilder.Entity<User>()
            .HasOne(x => x.Administrator)
            .WithOne(x => x.User)
            .HasForeignKey<Administrator>(e => e.UserId)
            .IsRequired();

        }

        public static void SeedAccount(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.Entity<Account>()
            .HasOne(x => x.FicaDetail)
            .WithOne(x => x.Account)
            .HasForeignKey<FicaDetail>(e => e.AccountId)
            .IsRequired();
        }

        public static void SeedAdministrator(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }
        }

        public static void SeedFicaStatus(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.Entity<FicaStatus>()
            .HasData(
                new { Id = FicaStatusEnum.NotStarted, Name = FicaStatusEnum.NotStarted.GetEnumName(), Description = FicaStatusEnum.NotStarted.GetEnumFullDescription() },
                new { Id = FicaStatusEnum.InProgress, Name = FicaStatusEnum.InProgress.GetEnumName(), Description = FicaStatusEnum.InProgress.GetEnumFullDescription() },
                new { Id = FicaStatusEnum.Pending, Name = FicaStatusEnum.Pending.GetEnumName(), Description = FicaStatusEnum.Pending.GetEnumFullDescription() },
                new { Id = FicaStatusEnum.Verified, Name = FicaStatusEnum.Verified.GetEnumName(), Description = FicaStatusEnum.Verified.GetEnumFullDescription() },
                new { Id = FicaStatusEnum.Rejected, Name = FicaStatusEnum.Rejected.GetEnumName(), Description = FicaStatusEnum.Rejected.GetEnumFullDescription() },
                new { Id = FicaStatusEnum.Expired, Name = FicaStatusEnum.Expired.GetEnumName(), Description = FicaStatusEnum.Expired.GetEnumFullDescription() },
                new { Id = FicaStatusEnum.Suspended, Name = FicaStatusEnum.Suspended.GetEnumName(), Description = FicaStatusEnum.Suspended.GetEnumFullDescription() },
                new { Id = FicaStatusEnum.Closed, Name = FicaStatusEnum.Closed.GetEnumName(), Description = FicaStatusEnum.Closed.GetEnumFullDescription() }
                );
        }

        public static void SeedFicaDetail(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.Entity<FicaDetail>()
            .HasOne(x => x.FicaStatus)
            .WithMany(x => x.FicaDetails)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .IsRequired();
        }
    }
}
