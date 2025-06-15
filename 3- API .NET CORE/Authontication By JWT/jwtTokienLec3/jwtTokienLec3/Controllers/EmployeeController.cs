using jwtTokienLec3.ContextDB;
using jwtTokienLec3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace jwtTokienLec3.Controllers
{
	[Route("api/[controller]")]//resource url
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly ITIContextDB context;

		public EmployeeController(ITIContextDB context)
		{
			this.context = context;
		}
		//crud
		[HttpGet]
		[Authorize]
		public IActionResult GetEmployee()
		{
			List<Employee> employees = context.Employees.ToList();
			return Ok(employees);
		}
		// GET: api/Employee/5
		//[HttpGet]//concat 
	//	[Route("{id:int}")]
		[HttpGet("{id:int}")]
		public IActionResult GetEmployeeById(int id)
		{
			var employee = context.Employees.Find(id);
			if (employee == null)
				return NotFound();
			return Ok(employee);
		}

		//[HttpGet("{name}")]//concat 
		//[HttpGet]
		[HttpGet("{name:alpha}")]
		public IActionResult GetEmployeeByName(string name)
		{
			var employee = context.Employees.FirstOrDefault(e => e.Name == name);

			if (employee == null)
				return NotFound();

			return Ok(employee);
		}



		[HttpPut("{id}")]
		public IActionResult UpdateEmployee([FromRoute] int id, [FromBody] Employee newEmp) //put
		{
			Employee oldEmployee = context.Employees.FirstOrDefault(e=>e.Id==id);
			if (oldEmployee == null)
				return NotFound();
			if (ModelState.IsValid)
			{
				oldEmployee.Name = newEmp.Name;
				oldEmployee.Salary = newEmp.Salary;
				oldEmployee.Address = newEmp.Address;
				oldEmployee.Age = newEmp.Age;
				context.SaveChanges();
				return StatusCode(204);
			}
			return BadRequest(ModelState);
		}



		//post for add employee
		[HttpPost("{id}",Name ="addemployeeee")]//addemployeeee route name
		public IActionResult AddEmployee([FromBody] Employee newEmp)
		{
			if (ModelState.IsValid)
			{

				context.Employees.Add(newEmp);
				context.SaveChanges();
				string url = Url.Link("addemployeeee", new { id = newEmp.Id }); //after save chagne for id to take it from db
				return Created(url, newEmp);
				//or
				//return Created(("http/localhost:2054/api/employee/" + newEmp.Id,newEmp));
			}
			return BadRequest(ModelState);
		}

		// DELETE: api/Employee/5
		[HttpDelete("{id}")]
		public IActionResult DeleteEmployee(int id)
		{
			try
			{
				Employee employee = context.Employees.FirstOrDefault(e => e.Id == id);
				if (employee == null)
					return NotFound();

				context.Employees.Remove(employee);
				context.SaveChanges();
				return NoContent();
			}catch
				{
				return BadRequest(ModelState);
			}
		}
	}
}
