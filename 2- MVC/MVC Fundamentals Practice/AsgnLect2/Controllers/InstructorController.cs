using AsgnLect2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AsgnLect2.Controllers
{
    public class InstructorController : Controller
    {
		private readonly ITIcontextDB context;

		// ITIcontextDB context = new ITIcontextDB();
		InstructorController(ITIcontextDB context)
		{
			this.context = context;
		}
		public IActionResult Index()
        {
            List<Instructore> instructores = context.Instructores.Include(i => i.Department)
            .Include(i => i.Course).ToList();
            return View(instructores);
        }
        public IActionResult Details(int id)
        {
            Instructore instructore = context.Instructores.FirstOrDefault(Iinst=> Iinst.Id==id);

            return View(instructore);
        }
		public IActionResult Add()
		{
			ViewBag.Departments = context.Departments.ToList();
			ViewBag.Courses = context.Courses.ToList(); 
			return View(new Instructore());
		}
        [HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Add(Instructore inst)
		{
            if (inst != null)
            {
                context.Instructores.Add(inst);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
				ViewBag.Departments = context.Departments.ToList();
				ViewBag.Courses = context.Courses.ToList();
				return View("Add",inst);

			}
                
		}
		
		public IActionResult Edit(int id)
		{
			Instructore oldInstance = context.Instructores.FirstOrDefault(x => x.Id == id);
			ViewBag.Departments = context.Departments.ToList();
			ViewBag.Courses = context.Courses.ToList();
			return View(oldInstance);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Instructore inst) //new
		{
			
			if (inst != null)
			{
				Instructore oldInstance=context.Instructores.FirstOrDefault(x => x.Id == inst.Id);
				oldInstance.Name = inst.Name;
				oldInstance.Salary=inst.Salary;
				oldInstance.Address=inst.Address;
				oldInstance.Image = inst.Image;
				oldInstance.crs_id=inst.crs_id;
				oldInstance.dept_id=inst.dept_id;
				context.SaveChanges();
				return RedirectToAction("Index");
			}
			else
			{
				ViewBag.Departments = context.Departments.ToList();
				ViewBag.Courses = context.Courses.ToList();
				return View("Edit", inst);

			}

		}
	}
}
