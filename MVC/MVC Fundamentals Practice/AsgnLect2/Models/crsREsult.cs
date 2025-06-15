using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsgnLect2.Models
{
    public class crsREsult
    {
        public int Id { get; set; }
        [Range(0, 100)]
        public int Degree { get; set; }

        [ForeignKey("Course")]
        public int crs_id { get; set; }//fk
        public virtual Course Course { get; set; }
        [ForeignKey("Trainee")]
        public int trainee_id { get; set; }//fk
        public virtual Trainee Trainee { get; set; } 
    }
}
