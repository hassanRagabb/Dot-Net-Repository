using Microsoft.EntityFrameworkCore;
namespace webapilec2.Models
{
	public class ITIEntity: DbContext
	{
		public ITIEntity() { }
		public ITIEntity(DbContextOptions options):base(options) { }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=.;Database=itiTry2;Trusted_Connection=True;TrustServerCertificate=True");
			base.OnConfiguring(optionsBuilder);
		}
		public DbSet<Employee> Employees { get; set; }

	}
}
