using identityLect9.Authintcation;
using identityLect9.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace identityLect9.ContextDB
{
	public class ITIContextDB : IdentityDbContext<ApplicationUser> //key u can make it her int and default is string
	{
		public ITIContextDB(DbContextOptions options) : base(options) { }

		// Add other DbSets here
		public DbSet<Employee> Employees { get; set; }
	}
}
