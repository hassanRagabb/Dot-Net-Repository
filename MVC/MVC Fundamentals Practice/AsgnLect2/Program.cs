using AsgnLect2.Authentication;
using AsgnLect2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

internal class Program
{
	private static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.
		builder.Services.AddControllersWithViews();

		//builder.Services.AddDbContext<ITIcontextDB>(optionBuilder =>{
		//	optionBuilder.UseSqlServer("Data Source =.; Initial Catalog = ITImvc; Integrated Security = True");//for second constructor
		//});

		builder.Services.AddDbContext<ITIcontextDB>(options =>
			options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
		builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
		{
			options.Password.RequireNonAlphanumeric = false;
			options.Password.RequireUppercase = false;
		})
	    .AddEntityFrameworkStores<ITIcontextDB>();

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
		app.UseAuthentication();
		app.UseAuthorization();

		app.MapControllerRoute(
			name: "default",
			pattern: "{controller=Home}/{action=Index}/{id?}");

		app.Run();
	}
}