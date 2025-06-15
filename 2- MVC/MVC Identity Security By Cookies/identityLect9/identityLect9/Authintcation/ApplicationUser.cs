using identityLect9.ContextDB;
using Microsoft.AspNetCore.Identity;

namespace identityLect9.Authintcation
{
	public class ApplicationUser : IdentityUser
	{
		// Add extra fields if needed
		public string? Address { get; set; }
	}
}
