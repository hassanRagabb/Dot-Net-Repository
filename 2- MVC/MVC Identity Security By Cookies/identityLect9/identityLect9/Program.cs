using identityLect9.Authintcation;
using identityLect9.ContextDB;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Net;

namespace identityLect9
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
			builder.Services.AddDbContext<ITIContextDB>(options =>
			options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options=> //classes this wreach to user manager and role manger
                {
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                }
            ).AddEntityFrameworkStores<ITIContextDB>(); //reach u with database with stores :(

			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles(); //root

            app.UseRouting();
            app.UseAuthentication();//check if u have cookie
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
