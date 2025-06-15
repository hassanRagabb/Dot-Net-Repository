using AsgnLect2.validator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsgnLect2.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Display(Name = "Course Name")]
		// [UniqeNameForCoursePerDepartment]
		//[UniqueDepartmentForCourse]
		//[UniqeNameForCoursePerDepartment]
		[Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string Name { get; set; }
        [Range(50,100)]
        [Required]  
        public int Degree { get; set; }
        //[Range(50, 100)]
        [Remote(action:"CheckMinDegreeWithDegree", controller: "Course", AdditionalFields = "Degree", ErrorMessage ="min deegree must be less than final degree above ")]
        public int minDegree { get; set; }
        [ForeignKey("Department")]
		//[UniqeNameForCoursePerDepartment]
		
		public int dept_id { get; set; }//fk

		[ValidateNever]
		public Department Department { get; set; }
		[ValidateNever]
		public List<Instructore> Instructores { get; set; }//many Instructores
		[ValidateNever]
		public List<crsREsult> crsREsults { get; set; }


		

	}
}
