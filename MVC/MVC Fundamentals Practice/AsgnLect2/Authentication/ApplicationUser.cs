using Microsoft.AspNetCore.Identity;

namespace AsgnLect2.Authentication
{
	public class ApplicationUser : IdentityUser
	{

		public string? Address { get; set; }
		public string FullName { get; set; }

		// You can add more custom fields as needed
		// public DateTime DateOfBirth { get; set; }
		// public string ProfileImageUrl { get; set; }
	}
}
