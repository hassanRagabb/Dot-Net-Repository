using AsgnLect2.validator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


namespace AsgnLect2.ViewModelBusinessLogic
{
public class CourseViewModel
{
	public int Id { get; set; }

	[Display(Name = "Course Name")]
	[Required]
	[MinLength(3)]
	[MaxLength(10)]
	//[UniqeNameForCoursePerDepartment]
	public string Name { get; set; }

	[Range(50, 100)]
	[Required]
	public int Degree { get; set; }

	[Remote(action: "CheckMinDegreeWithDegree", controller: "Course", AdditionalFields = "Degree", ErrorMessage = "Min degree must be less than final degree above")]
	public int minDegree { get; set; }

	//[Required(ErrorMessage = "Department is required")]
	[Display(Name = "Department")]
	//	[UniqeNameForCoursePerDepartment]
		public int dept_id { get; set; } // selected department ID

	// For dropdown of departments
	public IEnumerable<SelectListItem> DepartmentsList { get; set; }

	[Display(Name = "Instructors")]
	public List<int> SelectedInstructorIds { get; set; } = new List<int>(); // selected instructors

	// For checkbox or multi-select of instructors
	public IEnumerable<SelectListItem>? InstructorsList { get; set; }
}
}
