global using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OdeToFood.DataAccessLayer;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace OdeToFood
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddScoped<IRestaurantData, SqlRestaurantData>();
            builder.Services.AddDbContextPool<OdeToFoodDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("OdeToFoodDb"));
            });
            
            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();
            
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}