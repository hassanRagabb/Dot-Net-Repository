
using jwtTokienLec3.Authintcation;
using jwtTokienLec3.ContextDB;
using jwtTokienLec3.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Runtime.Intrinsics.X86;
using System.Text;
namespace jwtTokienLec3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
		
			builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
			//builder.Services.AddSwaggerGen();
			builder.Services.AddSwaggerGen(options =>
			{
				// Register multiple Swagger docs (v1, v2)
				options.SwaggerDoc("v1", new OpenApiInfo
				{
					Version = "v1",
					Title = "moco - API",
					Description = "ITI Project"
				});

				options.SwaggerDoc("v2", new OpenApiInfo
				{
					Version = "v2",
					Title = "moco - API",
					Description = "ITI Project"
				});

				//  Add JWT Bearer definition
				options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					Name = "Authorization",
					Type = SecuritySchemeType.Http,
					Scheme = "Bearer",
					BearerFormat = "JWT",
					In = ParameterLocation.Header,
					Description = "Enter 'Bearer' followed by a space and your token"
				});

				//  Apply JWT to all operations
				options.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
				{
						Reference = new OpenApiReference
						{
							Type = ReferenceType.SecurityScheme,
							Id = "Bearer"
						}
					},
					Array.Empty<string>()
					}
				});
			});



	


			//--- custom service ---\\

			builder.Services.AddDbContext<ITIContextDB>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			builder.Services.AddIdentity<ApplicationUser, IdentityRole>//classes this wreach to user manager and role manger
				( ).AddEntityFrameworkStores<ITIContextDB>(); //reach u with database with stores ROLE AND USER :(

			//[Authorize] use jwt tokien in check authontication
			builder.Services.AddAuthentication(options  =>
            {
                //valid tokien only maybe another domain
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;//have username and password and tokein valid sign or not valid return unauthorized
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; //if not valid challenage schema redirect u to login form
                options.DefaultScheme= JwtBearerDefaults.AuthenticationScheme;//other schema Same behaviour for other schema like default schema
			}).AddJwtBearer(options => //check same domain local
			{
				options.SaveToken = true;
				options.RequireHttpsMetadata=false;//https
				options.TokenValidationParameters = new TokenValidationParameters //validation its object
				{
					ValidateIssuer = true,//same 
					ValidIssuer = builder.Configuration["JwtSettings:validIssuer"],

					ValidateAudience = true,
					ValidAudience = builder.Configuration["JwtSettings:validAudience"], //may many  

					//ValidateLifetime = true,
					//key to check signature
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey( //open encrypte
						Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:secretKey"]))
				};
			});



			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
