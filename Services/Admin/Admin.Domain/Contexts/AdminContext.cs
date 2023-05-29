using Common.Domain.Contexts;
using JumpIn.Admin.Domain.Models.Admin;
using JumpIn.Common.Domain.Constant;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace JumpIn.Admin.Domain.Contexts
{
    public class AdminContext : BaseDbContext
    {
        private readonly IConfiguration config;
        private readonly IHostEnvironment env;

        public AdminContext(DbContextOptions<AdminContext> options, IConfiguration config, IHostEnvironment env, IHttpContextAccessor httpContextAccessor = null)
            : base(options, httpContextAccessor)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<FicaStatus> FicaStatuses { get; set; }
        public DbSet<FicaDetail> FicaDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder is null)
            {
                throw new ArgumentNullException(nameof(optionsBuilder));
            }

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionStrings__Default"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(DB.ADMIN_SCHEMA);
            modelBuilder.UseCollation(DB.CASE_INSENSITIVE_COLLATION);
        }
    }
}
