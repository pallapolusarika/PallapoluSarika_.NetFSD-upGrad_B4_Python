using Microsoft.EntityFrameworkCore;
using ContactManagement.DAL.Models;

namespace ContactManagement.DAL.DbContext
{
    public class ContactDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options)
            : base(options)
        {
        }

        public DbSet<ContactInfo> Contacts { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
    }
}
