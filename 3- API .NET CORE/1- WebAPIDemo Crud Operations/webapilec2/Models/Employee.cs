using System.ComponentModel.DataAnnotations;

namespace webapilec2.Models
{
	public class Employee
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Salary { get; set; }
		[Range(1000, 100000)]
		public string Address { get; set; }
		public int Age { get; set; }


	}
}
