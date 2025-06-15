using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityConsoleApp3.Entities
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Employee> Employees { get; set; } //= new List<Employee>();//virtual for lazt load
        public Department()
        {
            Employees = new HashSet<Employee>();
        }
    }
}
