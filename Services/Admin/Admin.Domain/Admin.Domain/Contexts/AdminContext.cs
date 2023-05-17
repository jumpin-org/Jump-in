using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Domain.Contexts
{
    public class AdminContext : BaseDbContext
    {
        public AdminContext(DbContextOptions<AdminContext> options)
           : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
        
        }

     }
}
