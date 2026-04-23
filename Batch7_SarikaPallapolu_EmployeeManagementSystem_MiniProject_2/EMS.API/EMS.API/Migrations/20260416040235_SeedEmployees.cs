using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EMS.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedEmployees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Department", "Designation", "Email", "FirstName", "JoinDate", "LastName", "Salary" },
                values: new object[] { "Operations", "Supply Chain Analyst", "sarika@123.com", "Sarika", new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pallapolu", 60000m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Department", "Designation", "Email", "FirstName", "JoinDate", "LastName", "Salary", "Status" },
                values: new object[] { "Marketing", "Digital Marketing Specialist", "aditya@xyz.com", "Aditya", new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kumar", 55000m, "Inactive" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Designation", "Email", "FirstName", "JoinDate", "LastName", "Salary", "Status" },
                values: new object[] { "Finance Manager", "lakshmi@xyz.com", "Lakshmi", new DateTime(2020, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kumar", 70000m, "Active" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedAt", "Department", "Designation", "Email", "FirstName", "JoinDate", "LastName", "Phone", "Salary", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 4, new DateTime(2026, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc), "HR", "HR Executive", "rahul@xyz.com", "Rahul", new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sharma", "9876543213", 50000m, "Active", new DateTime(2026, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 5, new DateTime(2026, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Engineering", "Software Engineer", "priya@xyz.com", "Priya", new DateTime(2021, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reddy", "9876543214", 75000m, "Active", new DateTime(2026, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 6, new DateTime(2026, 1, 6, 0, 0, 0, 0, DateTimeKind.Utc), "Finance", "Financial Analyst", "sneha@xyz.com", "Rishitha", new DateTime(2022, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reddy", "9876543215", 68000m, "Inactive", new DateTime(2026, 1, 6, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 7, new DateTime(2026, 1, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Engineering", "Backend Developer", "chandana@123.com", "Chandana", new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reddy", "9876543216", 80000m, "Active", new DateTime(2026, 1, 7, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 8, new DateTime(2026, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), "Marketing", "Content Strategist", "meera@xyz.com", "Meera", new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chowdary", "9876543217", 53000m, "Active", new DateTime(2026, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 9, new DateTime(2026, 1, 9, 0, 0, 0, 0, DateTimeKind.Utc), "Operations", "Operations Executive", "arjun@xyz.com", "Arjun", new DateTime(2021, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nair", "9876543218", 52000m, "Active", new DateTime(2026, 1, 9, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 10, new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), "HR", "Recruiter", "divya@xyz.com", "Divya", new DateTime(2022, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Naidu", "9876543219", 49000m, "Inactive", new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 11, new DateTime(2026, 1, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Engineering", "Frontend Developer", "vikram@xyz.com", "Vikram", new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kumar", "9876543220", 72000m, "Active", new DateTime(2026, 1, 11, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 12, new DateTime(2026, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), "Finance", "Accounts Executive", "ananya@xyz.com", "Ananya", new DateTime(2021, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reddy", "9876543221", 51000m, "Active", new DateTime(2026, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 13, new DateTime(2026, 1, 13, 0, 0, 0, 0, DateTimeKind.Utc), "Operations", "Logistics Coordinator", "rohan@xyz.com", "Rohan", new DateTime(2022, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Naidu", "9876543222", 54000m, "Active", new DateTime(2026, 1, 13, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 14, new DateTime(2026, 1, 14, 0, 0, 0, 0, DateTimeKind.Utc), "Marketing", "SEO Specialist", "pooja@xyz.com", "Pooja", new DateTime(2020, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reddy", "9876543223", 56000m, "Active", new DateTime(2026, 1, 14, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 15, new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Engineering", "QA Engineer", "suresh@xyz.com", "Suresh", new DateTime(2023, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Babu", "9876543224", 67000m, "Active", new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$Sp5.2MsaHR/yPdvh24KAJOtS13PZLQlnEB8bBch4Q6GdS04rLBi6i");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$VlIu54VhgmrKsbj2bpbRauMTZ.q3bQwYi69FZ7Satk4CovVp5jnuq");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Department", "Designation", "Email", "FirstName", "JoinDate", "LastName", "Salary" },
                values: new object[] { "Engineering", "Software Engineer", "priya.menon@xyz.com", "Priya", new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Menon", 750000m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Department", "Designation", "Email", "FirstName", "JoinDate", "LastName", "Salary", "Status" },
                values: new object[] { "HR", "HR Executive", "rahul.sharma@xyz.com", "Rahul", new DateTime(2021, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sharma", 500000m, "Active" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Designation", "Email", "FirstName", "JoinDate", "LastName", "Salary", "Status" },
                values: new object[] { "Financial Analyst", "sneha.reddy@xyz.com", "Sneha", new DateTime(2020, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reddy", 680000m, "Inactive" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$CL.3gpfpftf9TuGaSMI7Ju8pVzLx/pXCq2lMXNHbrxRr7STY0VeCa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$IaX7hDgZkZCTNvf4Cb5qjOvoIVAu9BbPHoB6rmwFqraDIo5TVtWlu");
        }
    }
}
