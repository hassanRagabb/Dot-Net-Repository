using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfLect10
{
    public abstract class Person
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }
        //public bool IsEmployee { get; set; }
    }

    public class Teacher : Person
    {
        //public Teacher() =>IsEmployee= true;
        public DateTime HireDate { get; set; }//DateTime structre value type by default required 
    }
    public class Student : Person
    {
       // public Student() => IsEmployee = false;
        public DateTime  EnrolmentDate { get; set; }
    }
}