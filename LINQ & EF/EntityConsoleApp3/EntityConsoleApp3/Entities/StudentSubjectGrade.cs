using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityConsoleApp3.Entities
{
    public class StudentSubjectGrade
    {
        public int StudentID { get; set; }
        public int SubjectID { get; set; }
        public virtual Student  Student  { get; set; }//ONE FOR join  virtual for LAZY LOAD
        public virtual Subject Subject { get; set; }//ONE
        public int Grade { get; set; }


    }
}
