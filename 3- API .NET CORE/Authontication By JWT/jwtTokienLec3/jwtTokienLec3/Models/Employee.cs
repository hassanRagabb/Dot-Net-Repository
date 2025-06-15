using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jwtTokienLec3.Models
{
	public class Employee
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Salary { get; set; }
		[Range(1000, 100000)]
		public string Address { get; set; }
		public int Age { get; set; }
		[ForeignKey("Department")]
		public int dept_id { get; set; }
		public Department? Department { get; set; }


	}
}
