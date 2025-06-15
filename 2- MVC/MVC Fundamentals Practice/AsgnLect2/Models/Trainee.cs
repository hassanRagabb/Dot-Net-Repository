using System.ComponentModel.DataAnnotations.Schema;

namespace AsgnLect2.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public int Level { get; set; }

        [ForeignKey("Department")]
        public int dept_id { get; set; }//fk
        public virtual Department Department { get; set; }
        public List<crsREsult> crsREsults { get; set; }
    }
}
