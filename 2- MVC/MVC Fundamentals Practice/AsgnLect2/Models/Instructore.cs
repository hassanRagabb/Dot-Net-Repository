using System.ComponentModel.DataAnnotations.Schema;

namespace AsgnLect2.Models
{
    public class Instructore
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        [ForeignKey("Department")]
        public int dept_id { get; set; }//fk
        public virtual Department Department { get; set; }

        [ForeignKey("Course")]
        public int crs_id { get; set; }//fk
        public virtual Course Course { get; set; }//nav properity

    }
}
