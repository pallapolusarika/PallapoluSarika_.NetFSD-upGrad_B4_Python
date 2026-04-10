/*Problem Statement
Many small organizations struggle to efficiently manage employee records such as personal details, department assignments, salary information, and job status. Traditional systems often rely on manual data handling or basic CRUD operations without advanced filtering, sorting, and searching capabilities.
There is a need for a dynamic web application that not only performs CRUD operations but also demonstrates powerful data querying capabilities using LINQ (Language Integrated Query) within ASP.NET Core MVC.
The goal of this project is to build a web-based Employee Management System that leverages LINQ for efficient data retrieval, filtering, grouping, sorting, and aggregation.

●	Performs CRUD operations on employee records
●	Uses LINQ for advanced querying
●	Implements filtering, sorting, grouping, and aggregation
●	Demonstrates real-world data manipulation using Entity Framework Core
________________________________________
System Requirements
The application should allow users to:
1️⃣ Employee Management
●	Add new employee records
●	Edit employee details
●	Delete employees
●	View employee list
2️⃣ LINQ-Based Functionalities
●	Search employees by name
●	Filter employees by department
●	Sort employees by salary (ascending/descending)
●	Group employees by department
●	Calculate:
○	Total number of employees
○	Average salary per department
○	Highest paid employee
●	Display employees hired within a specific date range
________________________________________
Technical Constraints
●	Use ASP.NET Core MVC
●	Use Entity Framework Core (Code First or Database First)
●	Perform all data queries using LINQ
●	Use SQL Server as the database
●	Apply proper model validation
●	Implement Dependency Injection
________________________________________
Expected Outcome
The final system should:
●	Demonstrate practical use of LINQ in real-world scenarios
●	Efficiently handle data operations
●	Provide a clean and user-friendly interface
●	Follow MVC architecture principles*/
________________________________________



using EmployeeManagementSystem.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();