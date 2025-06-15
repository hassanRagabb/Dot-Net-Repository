using jwtTokienLec3.ContextDB;
using Microsoft.AspNetCore.Identity;

namespace jwtTokienLec3.Authintcation
{
	public class ApplicationUser : IdentityUser
	{
		// Add extra fields if needed
		public string? Address { get; set; }
	}
}
