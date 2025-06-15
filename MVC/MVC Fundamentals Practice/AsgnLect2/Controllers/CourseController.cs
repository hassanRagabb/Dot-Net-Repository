using AsgnLect2.Models;
using AsgnLect2.ViewModelBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace AsgnLect2.Controllers
{
	public class CourseController : Controller
	{
		private readonly ITIcontextDB context;

		//ITIcontextDB context = new ITIcontextDB();
		CourseController(ITIcontextDB context)
		{
			this.context = context;
		}
		public IActionResult Index()
		{
			List<Course> Courses = context.Courses.Include(c=>c.Department).ToList();//nav properity
			return View(Courses);
		}
		// In Controller (for MVC) or PageModel (for Razor Pages)
		public IActionResult AddNew()
		{
			ViewBag.Departments = new SelectList(context.Departments, "Id", "Name");
			return View();
		}

		[HttpPost]
		public IActionResult AddNew(Course model)
		{
			if (ModelState.IsValid)
			{
				context.Courses.Add(model);
				context.SaveChanges();
				return RedirectToAction("Index");
			}

			// If validation fails, reload Departments list
			ViewBag.Departments = new SelectList(context.Departments, "Id", "Name");
			return View(model);
		}
		
		//public IActionResult AddNew()
		//{

		//	//using course class 
		//	//ViewBag.Instructores = context.Instructores.ToList();
		//	//ViewBag.Departments = context.Departments.ToList();
		//	//// Pass Instructors to ViewBag if needed (for multi-select)
		//	//ViewBag.InstructorList = new MultiSelectList(context.Instructores.ToList(), "Id", "FullName");
		//	//ViewBag.Courses = context.Courses.Include(c => c.Department).ToList();
		//	//return View();


		//	//using course view model
		//	var viewModel = new CourseViewModel
		//	{
		//		DepartmentsList = new SelectList(context.Departments.ToList(), "Id", "Name"),
		//		InstructorsList = new SelectList(context.Instructores.ToList(), "Id", "Name")
		//	};

		//	return View(viewModel);
			
		//}
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public IActionResult AddNew(CourseViewModel crsVm)
		//{
		//	//using course class model
		//	//if (ModelState.IsValid)
		//	//{
		//	//	if (crs.dept_id != null)
		//	//	{
		//	//		context.Courses.Add(crs);
		//	//		context.SaveChanges();
		//	//		return RedirectToAction("Index");
		//	//	}
		//	//}
		//	//ViewBag.InstructorList = new MultiSelectList(context.Instructores.ToList(), "Id", "FullName");
		//	//ViewBag.Instructores = context.Instructores.ToList();
		//	//ViewBag.Departments = context.Departments.ToList();
		//	//ViewBag.Courses = context.Courses.Include(c => c.Department).ToList();
		//	//return View("AddNew",crs);

		//	//using course view model
		//	if (!ModelState.IsValid)
		//	{
		//		crsVm.DepartmentsList = new SelectList(context.Departments.ToList(), "Id", "Name");
		//		crsVm.InstructorsList = new SelectList(context.Instructores.ToList(), "Id", "Name");
		//		return View("AddNew",crsVm);
		//	}

		//	var course = new Course
		//	{
		//		Name = crsVm.Name,
		//		Degree = crsVm.Degree,
		//		minDegree = crsVm.minDegree,
		//		dept_id = crsVm.dept_id,
		//		Instructores = context.Instructores
		//						  .Where(i => crsVm.SelectedInstructorIds.Contains(i.Id))
		//						  .ToList()
		//	};

		//	context.Courses.Add(course);
		//	context.SaveChanges();

		//	return RedirectToAction("Index");
		//}
		
		public IActionResult CheckMinDegreeWithDegree(int minDegree,int Degree) {
			if (minDegree < Degree)
			{
				return Json(true);
			}
			else
			{
				return Json("Minimum degree must be less than final degree.");
			}
		}

	}
}
