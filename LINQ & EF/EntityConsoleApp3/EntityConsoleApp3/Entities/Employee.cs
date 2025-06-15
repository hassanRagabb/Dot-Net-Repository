using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityConsoleApp3.Entities
{
    // poco class plainn old clr object  no realted to EF 
    public class Employee
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public decimal Salary { get; set; } //not null by default
        public int? Age { get; set; }
        public string Address { get; set; }

        // Foreign key
        //:( dont comment it so when u delete department hi will remove employess inside it if u forget to add it u can make it by fluent api

        //public int DepartmentID { get; set; }//same name in dep   for cascade deleting 



        // Navigation or inver property: An employee belongs to one department
        //[InverseProperity("Department")]
        public virtual Department Department { get; set; }//virtual for lazt load 
        


        // Navigation property for many-to-many with TrainingCourse but if u need to add things u must make third table take fk from both 
        public virtual ICollection<TrainingCourse> TrainingCourses { get; set; } = new HashSet<TrainingCourse>();

       
    }
}
