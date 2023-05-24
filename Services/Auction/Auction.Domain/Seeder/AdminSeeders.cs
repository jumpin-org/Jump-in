using JumpIn.Auction.Domain.Models.Admin;
using JumpIn.Common.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpIn.Auction.Domain.Seeders
{
    public static class AdminSeeders
    {
        public static void SeedUser(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }
        }

        public static void SeedAccount(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.Entity<Account>()
            .HasOne(x => x.User)
            .WithOne(x => x.Account)
            .HasForeignKey<Account>(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
        }

        public static void SeedAdministrator(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.Entity<Administrator>()
            .HasOne(x => x.User)
            .WithOne(x => x.Administrator)
            .HasForeignKey<Administrator>(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
        }

        public static void SeedFicaStatus(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.Entity<FicaStatus>()
            .HasMany(x => x.FicaDetails)
            .WithOne(x => x.FicaStatus)
            .HasForeignKey(x => x.FicaStatusId)
            .IsRequired();
        }

        public static void SeedFicaDetail(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.Entity<FicaDetail>()
            .HasOne(x => x.Account)
            .WithOne(x => x.FicaDetail)
            .HasForeignKey<FicaDetail>(x => x.AccountId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
        }
    }
}
