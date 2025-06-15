using System.ComponentModel.DataAnnotations;

namespace jwtTokienLec3.ViewModel
{
	public class RegisterViewModel
	{
		[Required]
		[Display(Name = "Username")]
		public string Username { get; set; }

	

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		
		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Confirm Password")]
		[Compare("Password", ErrorMessage = "Passwords do not match.")]
		public string ConfirmPassword { get; set; }

		[EmailAddress]
		[Display(Name = "Email")]
		public string Email { get; set; }
	}
}