using System.ComponentModel.DataAnnotations;

namespace AsgnLect2.ViewModelBusinessLogic
{
	public class LoginViewModel
	{
		[Required]
		public string UserName { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "Remember Me")]
		public bool RememberMe { get; set; }
	}
}
