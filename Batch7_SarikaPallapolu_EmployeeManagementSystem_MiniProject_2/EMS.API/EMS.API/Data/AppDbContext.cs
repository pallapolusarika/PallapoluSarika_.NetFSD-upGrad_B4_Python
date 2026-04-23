using EMS.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<AppUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.Email)
                .IsUnique();

            modelBuilder.Entity<AppUser>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = 1,
                    Username = "Sarika",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Sharu123"),
                    Role = "Admin",
                    CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new AppUser
                {
                    Id = 2,
                    Username = "viewer",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("viewer123"),
                    Role = "Viewer",
                    CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    FirstName = "Sarika",
                    LastName = "Pallapolu",
                    Email = "sarika@123.com",
                    Phone = "9876543210",
                    Department = "Operations",
                    Designation = "Supply Chain Analyst",
                    Salary = 60000,
                    JoinDate = new DateTime(2022, 1, 10),
                    Status = "Active",
                    CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Aditya",
                    LastName = "Kumar",
                    Email = "aditya@xyz.com",
                    Phone = "9876543211",
                    Department = "Marketing",
                    Designation = "Digital Marketing Specialist",
                    Salary = 55000,
                    JoinDate = new DateTime(2021, 3, 15),
                    Status = "Inactive",
                    CreatedAt = new DateTime(2026, 1, 2, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2026, 1, 2, 0, 0, 0, DateTimeKind.Utc)
                },
                new Employee
                {
                    Id = 3,
                    FirstName = "Lakshmi",
                    LastName = "Kumar",
                    Email = "lakshmi@xyz.com",
                    Phone = "9876543212",
                    Department = "Finance",
                    Designation = "Finance Manager",
                    Salary = 70000,
                    JoinDate = new DateTime(2020, 7, 20),
                    Status = "Active",
                    CreatedAt = new DateTime(2026, 1, 3, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2026, 1, 3, 0, 0, 0, DateTimeKind.Utc)
                },
                new Employee
                {
                    Id = 4,
                    FirstName = "Rahul",
                    LastName = "Sharma",
                    Email = "rahul@xyz.com",
                    Phone = "9876543213",
                    Department = "HR",
                    Designation = "HR Executive",
                    Salary = 50000,
                    JoinDate = new DateTime(2023, 2, 5),
                    Status = "Active",
                    CreatedAt = new DateTime(2026, 1, 4, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2026, 1, 4, 0, 0, 0, DateTimeKind.Utc)
                },
                new Employee
                {
                    Id = 5,
                    FirstName = "Priya",
                    LastName = "Reddy",
                    Email = "priya@xyz.com",
                    Phone = "9876543214",
                    Department = "Engineering",
                    Designation = "Software Engineer",
                    Salary = 75000,
                    JoinDate = new DateTime(2021, 11, 11),
                    Status = "Active",
                    CreatedAt = new DateTime(2026, 1, 5, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2026, 1, 5, 0, 0, 0, DateTimeKind.Utc)
                },
                new Employee
                {
                    Id = 6,
                    FirstName = "Rishitha",
                    LastName = "Reddy",
                    Email = "sneha@xyz.com",
                    Phone = "9876543215",
                    Department = "Finance",
                    Designation = "Financial Analyst",
                    Salary = 68000,
                    JoinDate = new DateTime(2022, 9, 9),
                    Status = "Inactive",
                    CreatedAt = new DateTime(2026, 1, 6, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2026, 1, 6, 0, 0, 0, DateTimeKind.Utc)
                },
                new Employee
                {
                    Id = 7,
                    FirstName = "Chandana",
                    LastName = "Reddy",
                    Email = "chandana@123.com",
                    Phone = "9876543216",
                    Department = "Engineering",
                    Designation = "Backend Developer",
                    Salary = 80000,
                    JoinDate = new DateTime(2020, 12, 1),
                    Status = "Active",
                    CreatedAt = new DateTime(2026, 1, 7, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2026, 1, 7, 0, 0, 0, DateTimeKind.Utc)
                },
                new Employee
                {
                    Id = 8,
                    FirstName = "Meera",
                    LastName = "Chowdary",
                    Email = "meera@xyz.com",
                    Phone = "9876543217",
                    Department = "Marketing",
                    Designation = "Content Strategist",
                    Salary = 53000,
                    JoinDate = new DateTime(2023, 4, 18),
                    Status = "Active",
                    CreatedAt = new DateTime(2026, 1, 8, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2026, 1, 8, 0, 0, 0, DateTimeKind.Utc)
                },
                new Employee
                {
                    Id = 9,
                    FirstName = "Arjun",
                    LastName = "Nair",
                    Email = "arjun@xyz.com",
                    Phone = "9876543218",
                    Department = "Operations",
                    Designation = "Operations Executive",
                    Salary = 52000,
                    JoinDate = new DateTime(2021, 6, 25),
                    Status = "Active",
                    CreatedAt = new DateTime(2026, 1, 9, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2026, 1, 9, 0, 0, 0, DateTimeKind.Utc)
                },
                new Employee
                {
                    Id = 10,
                    FirstName = "Divya",
                    LastName = "Naidu",
                    Email = "divya@xyz.com",
                    Phone = "9876543219",
                    Department = "HR",
                    Designation = "Recruiter",
                    Salary = 49000,
                    JoinDate = new DateTime(2022, 8, 14),
                    Status = "Inactive",
                    CreatedAt = new DateTime(2026, 1, 10, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2026, 1, 10, 0, 0, 0, DateTimeKind.Utc)
                },
                new Employee
                {
                    Id = 11,
                    FirstName = "Vikram",
                    LastName = "Kumar",
                    Email = "vikram@xyz.com",
                    Phone = "9876543220",
                    Department = "Engineering",
                    Designation = "Frontend Developer",
                    Salary = 72000,
                    JoinDate = new DateTime(2023, 1, 30),
                    Status = "Active",
                    CreatedAt = new DateTime(2026, 1, 11, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2026, 1, 11, 0, 0, 0, DateTimeKind.Utc)
                },
                new Employee
                {
                    Id = 12,
                    FirstName = "Ananya",
                    LastName = "Reddy",
                    Email = "ananya@xyz.com",
                    Phone = "9876543221",
                    Department = "Finance",
                    Designation = "Accounts Executive",
                    Salary = 51000,
                    JoinDate = new DateTime(2021, 10, 12),
                    Status = "Active",
                    CreatedAt = new DateTime(2026, 1, 12, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2026, 1, 12, 0, 0, 0, DateTimeKind.Utc)
                },
                new Employee
                {
                    Id = 13,
                    FirstName = "Rohan",
                    LastName = "Naidu",
                    Email = "rohan@xyz.com",
                    Phone = "9876543222",
                    Department = "Operations",
                    Designation = "Logistics Coordinator",
                    Salary = 54000,
                    JoinDate = new DateTime(2022, 5, 22),
                    Status = "Active",
                    CreatedAt = new DateTime(2026, 1, 13, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2026, 1, 13, 0, 0, 0, DateTimeKind.Utc)
                },
                new Employee
                {
                    Id = 14,
                    FirstName = "Pooja",
                    LastName = "Reddy",
                    Email = "pooja@xyz.com",
                    Phone = "9876543223",
                    Department = "Marketing",
                    Designation = "SEO Specialist",
                    Salary = 56000,
                    JoinDate = new DateTime(2020, 3, 8),
                    Status = "Active",
                    CreatedAt = new DateTime(2026, 1, 14, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2026, 1, 14, 0, 0, 0, DateTimeKind.Utc)
                },
                new Employee
                {
                    Id = 15,
                    FirstName = "Suresh",
                    LastName = "Babu",
                    Email = "suresh@xyz.com",
                    Phone = "9876543224",
                    Department = "Engineering",
                    Designation = "QA Engineer",
                    Salary = 67000,
                    JoinDate = new DateTime(2023, 7, 19),
                    Status = "Active",
                    CreatedAt = new DateTime(2026, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2026, 1, 15, 0, 0, 0, DateTimeKind.Utc)
                }
            );
        }
    }
}