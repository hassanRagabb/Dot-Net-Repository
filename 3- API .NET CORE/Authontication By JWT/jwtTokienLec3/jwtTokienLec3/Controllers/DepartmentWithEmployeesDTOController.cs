using jwtTokienLec3.ContextDB;
using jwtTokienLec3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace jwtTokienLec3.Controllers
{
	public class DepartmentWithEmployeesDTOController : Controller
	{
		private readonly ITIContextDB context;

		public DepartmentWithEmployeesDTOController(ITIContextDB context)
		{
			this.context = context;
		}
		public IActionResult Index()
		{
			return View();
		}
		//[HttpGet("p")]
		//public ActionResult<List<DeptWithEmpCountDTO>> GetDeptDetails()
		//{
		//	List<Department> deptlist = context.Departments.Include(d => d.Emps).ToList();
		//	List<DeptWithEmpCountDTO> deptListDto = deptlist.Select(item => new DeptWithEmpCountDTO
		//	{
		//		ID = item.Id,
		//		Name = item.Name,
		//		EmpCount = item.Emps.Count()
		//	}).ToList();

		//	return deptListDto;
		//}

		//[HttpGet("departments-with-employees")]
		//public IActionResult GetDepartmentsWithEmployees()
		//{
		//	var result = context.Departments
		//		.Include(d => d.Employees)
		//		.Select(d => new DepartmentWithEmployeesDTO
		//		{
		//			Id = d.Id,
		//			Name = d.Name,//DEPARTMENT NAME
		//			Employees = d.Employees.Select(e => new EmployeeDTO
		//			{
		//				Id = e.Id,
		//				Name = e.Name,
		//				Salary = e.Salary
		//			}).ToList()
		//		}).ToList();

		//	return Ok(result);
		//}

	}
}
