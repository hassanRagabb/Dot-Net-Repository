using Microsoft.AspNetCore.Mvc;

namespace AsgnLect2.Controllers
{
	public class AccountController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
