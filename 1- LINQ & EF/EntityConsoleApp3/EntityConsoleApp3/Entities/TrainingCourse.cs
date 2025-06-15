using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;////[Key]
using System.ComponentModel.DataAnnotations.Schema;///[Table("Courses")]

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityConsoleApp3.Entities
{
    [Table("Courses")]//creation class
    public class TrainingCourse
    {
        [Key]//:pk
        public int CourseNumber { get; set; }//pk not follow convention
        [Required]//not null
        [MaxLength(50)]
        public string CourseTitle { get; set; }
        [Column("Duration",TypeName="int")]//change colname  [Column("Duration")
        public short CourseDuration { get; set; }//hours
        [Required]//not null
        [StringLength(200,MinimumLength =10)]
        public string CourseURL  { get; set; }


        // Navigation property for many-to-many relationship
        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

      
    }
}
