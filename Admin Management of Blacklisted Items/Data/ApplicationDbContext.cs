using Admin_Management_of_Blacklisted_Items.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Admin_Management_of_Blacklisted_Items.Data
{
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {
            }

            public DbSet<User> Users { get; set; }
            public DbSet<BlacklistedItem> BlacklistedItems { get; set; }
    }
    
}
