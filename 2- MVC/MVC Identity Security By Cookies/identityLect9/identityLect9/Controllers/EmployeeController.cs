using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace identityLect9.Controllers
{
	public class EmployeeController : Controller
	{
		[Authorize]
		public IActionResult Index()
		{
			//employee service
			return View();
		}
	}
}
