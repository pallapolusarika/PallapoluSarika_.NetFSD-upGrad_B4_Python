using DataAccessLayer.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;









using DataAccessLayer.Data;
using DataAccessLayer.Data;
using DataAccessLayer.Repository;
using Microsoft.EntityFrameworkCore;
namespace AppUILayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IContactRepository, ContactRepository>();
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
    pattern: "{controller=Contact}/{action=ShowContacts}/{id?}");

            app.Run();
        }
    }
}