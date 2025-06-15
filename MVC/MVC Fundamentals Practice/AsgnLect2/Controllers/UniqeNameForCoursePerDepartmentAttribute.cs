using AsgnLect2.Models;
using System.ComponentModel.DataAnnotations;

namespace AsgnLect2.validator
{
	public class UniqeNameForCoursePerDepartmentAttribute : ValidationAttribute
	{
		private readonly ITIcontextDB context;

		UniqeNameForCoursePerDepartmentAttribute(ITIcontextDB context)
		{
			this.context = context;
		}
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			//ITIcontextDB context=new ITIcontextDB();
			
			if (context == null)
				throw new InvalidOperationException("DbContext is not available");

			// now you can query the db with context
			var crsForm = validationContext.ObjectInstance as Course;
			if (crsForm == null)
				return ValidationResult.Success;

			string courseName = value?.ToString()?.Trim() ?? "";

			var exists = context.Courses.FirstOrDefault(c =>
				c.Name == courseName &&
				c.dept_id == crsForm.dept_id &&
				c.Id != crsForm.Id);

			if (exists != null)
				return new ValidationResult("This course name already exists in the selected department.");

			return ValidationResult.Success;
		}
	}
}

//	if (value is not string name || string.IsNullOrWhiteSpace(name))
//		return ValidationResult.Success!;

//	string courseName = value.ToString()!.Trim();
//	//ITIcontextDB context = new ITIcontextDB();

//	////Course crsDB=context.Courses.FirstOrDefault(c=>c.Name==newName);
//	Course crsForm = validationContext.ObjectInstance as Course;
//	//Course existInDb = context.Courses.FirstOrDefault(c => c.Name == courseName && c.dept_id == crsForm.dept_id && c.Id != crsForm.Id);

//	//if (existInDb != null)
//	//	return new ValidationResult("This course name already exists in the selected department.");
//	int deptId = crsForm.dept_id;
//	int courseId = crsForm.Id;

//	using (var context = new ITIcontextDB())
//	{
//		var exists = context.Courses
//			.FirstOrDefault(c => c.Name == courseName && c.dept_id == deptId && c.Id != courseId);

//		if (exists != null)
//			return new ValidationResult("This course name already exists in the selected department.");
//	}

//	return ValidationResult.Success;


//return base.IsValid(value, validationContext);