using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityConsoleApp3.Entities
{
    public class Subject
    {
        public int SubjectID { get; set; }            // Primary Key
        [Required(ErrorMessage = "Subject name is required.")]
        [StringLength(100)]
        public string Name { get; set; }              // Subject name
        [Range(1, 10, ErrorMessage = "Credits must be between 1 and 10.")]
        public int Credits { get; set; }              // Number of credits
        [Required(ErrorMessage = "Subject code is required.")]
        [StringLength(20)]
        public string Code { get; set; }              // Subject code (e.g., MATH101)

        // Navigation property (optional)
        public ICollection<Student> Students { get; set; } = new HashSet<Student>();// Many-to-many with students

        //many to many with measures

        public virtual ICollection<StudentSubjectGrade> StudentSubjectsGrade { get; set; } = new HashSet<StudentSubjectGrade>();
    }
}
