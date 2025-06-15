//using Microsoft.EntityFrameworkCore;
//using static System.Net.Mime.MediaTypeNames;
//using static System.Runtime.InteropServices.JavaScript.JSType;

//namespace AsgnLect2.Models
//{
//    public class ITIcontextDB:DbContext
//    {
//        //   ITIcontextDB()base:{}
//        public ITIcontextDB():base() //hi take options from on configure
//        {
//		}
//        //inject no look for onconfigre when u call it inside ur repositry using new object
//        //public ITIcontextDB(DbContextOptions options):base(options) //we will write this hi take object from another class need to inject lect 
//        //{
             
//        //}
        
      

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
//        {
//            optionsBuilder.UseSqlServer("Data Source =.; Initial Catalog = ITImvc; Integrated Security = True");

       
//        }

//        public DbSet<Department> Departments { get; set; }
//        public DbSet<Instructore> Instructores{ get; set; }
//        public DbSet<Course> Courses { get; set; }
//        public DbSet<crsREsult> crsREsults { get; set; }
//        public DbSet<Trainee> Trainees { get; set; }

//    }
//}
