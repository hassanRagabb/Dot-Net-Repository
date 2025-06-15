using AsgnLect2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsgnLect2.GradesViewModel
{   
    public class TraineeCourseGradeViewModel
    {
        public string traineeName { get; set; }
		//SubjectName must be deleted u have ist of courses
		public string SubjectName { get; set; }
      
        public List<int> Grades { get; set; }
        public List<Course> Courses { get; set; }
        public List<string> Colors { get; set; }

    }
}
