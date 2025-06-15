namespace AsgnLect2.Models
{
    public class Department
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Manager { get; set; }

        public List<Instructore> Instructores { get; set; }//many Instructores
        public List<Course> courses  { get; set; }//many courses
        public List<Trainee> Trainees { get; set; }
    }
}
