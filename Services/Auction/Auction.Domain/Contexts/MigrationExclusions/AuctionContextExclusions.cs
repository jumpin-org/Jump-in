using JumpIn.Auction.Domain.Models.Admin;
using Microsoft.EntityFrameworkCore;

namespace JumpIn.Auction.Domain.Contexts.MigrationExclusions
{
    public static class AuctionContextExclusions
    {
        public static void ExcludeFromMigrations(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.Entity<User>().ToTable(nameof(User), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<Account>().ToTable(nameof(Account), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<Administrator>().ToTable(nameof(Administrator), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<FicaStatus>().ToTable(nameof(FicaStatus), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<FicaDetail>().ToTable(nameof(FicaDetail), t => t.ExcludeFromMigrations());
  }
    }
}
