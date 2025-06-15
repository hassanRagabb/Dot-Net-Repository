using Microsoft.AspNetCore.Http; 
using Microsoft.AspNetCore.Mvc;

namespace jwtTokienLec3.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BindController : ControllerBase
	{
		//primitive type
		[HttpGet("by-primitive")]  
		public IActionResult GetByPrimitive(int id, string name)
		{
			return Ok(new { Id = id, Name = name });
		}
	}
}
