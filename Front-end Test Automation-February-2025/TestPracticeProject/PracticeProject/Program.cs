using Microsoft.EntityFrameworkCore;
using PracticeProject.DbContext;
using PracticeProject.Services;
using PracticeProject.Services.Interfaces;

namespace PracticeProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services
                .AddDbContext<TestPractiveDb>(option => option.UseInMemoryDatabase("Test_Practice_DB"));
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            
            builder.Services.AddScoped<IEntityService, EntityService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
        }
    }
}
