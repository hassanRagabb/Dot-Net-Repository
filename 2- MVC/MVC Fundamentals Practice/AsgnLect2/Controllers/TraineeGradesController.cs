using AsgnLect2.GradesViewModel;
using AsgnLect2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace AsgnLect2.Controllers
{
    public class TraineeGradesController : Controller
    {

		//ITIcontextDB context = new ITIcontextDB();
		TraineeGradesController(ITIcontextDB context)
		{
			this.context = context;
		}
		TraineeCourseGradeViewModel TranineecrsGrades = new TraineeCourseGradeViewModel();
		private readonly ITIcontextDB context;

		public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            Trainee t = context.Trainees.FirstOrDefault(i => i.Id == id);
			TranineecrsGrades.traineeName = t.Name;
			//  TranineecrsGrades.SubjectName = "Databases";
			// Get the course result for the specific trainee and course
			//var courseResult = context.crsREsults
			//	.Include(r => r.Course)
			//	.FirstOrDefault(r => r.trainee_id == id && r.Course.Name == "Databases");

			// Get all course results for this trainee
			var courseResults = context.crsREsults
		    .Include(r => r.Course)
		    .Where(r => r.trainee_id == id)  //########################################
		    .ToList();

			TranineecrsGrades.Grades = courseResults.Select(r => r.Degree).ToList();
			TranineecrsGrades.Courses = courseResults.Select(r => r.Course).ToList();
			TranineecrsGrades.Colors = courseResults.Select(r => r.Degree > 60 ? "green" : "red").ToList();
            return View(TranineecrsGrades);
        }
    }
}
