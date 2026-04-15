using ApiTestingDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTestingDemo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        // 🔧 ADD THIS METHOD
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.Salary)
                .HasPrecision(18, 2); // ✅ Fix warning

            base.OnModelCreating(modelBuilder);
        }
    }
}