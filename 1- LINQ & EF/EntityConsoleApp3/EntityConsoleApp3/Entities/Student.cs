using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityConsoleApp3.Entities
{
    public class Student
    {
        public int StudentID { get; set; }       // Primary Key
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Navigation property (optional)
        public virtual ICollection<Subject> Subjects { get; set; } = new HashSet<Subject>();// Many-to-many with students


        //many to many with measures
        public virtual ICollection<StudentSubjectGrade> StudentSubjectsGrade { get; set; } = new HashSet<StudentSubjectGrade>();// Many-to-many with students
    }
}
