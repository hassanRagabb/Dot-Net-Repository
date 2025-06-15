using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfLect10
{
    internal class ContextClass:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EFlect10DB;Integrated Security=true");
        }

        //table per hearichy - dbset per concrete type
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Student> Students { get; set; }

       // public virtual DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            //table per hireachy discremenator is nvarchar as string with 2 dbset(dbset per cc only child )
            modelBuilder.Entity<Teacher>().HasBaseType<Person>();
            modelBuilder.Entity<Student>().HasBaseType<Person>();

            // still table per Hearchy and (dbset per cc only child ) discriminator is filed bool here field still 2 dbset 
            //modelBuilder.Entity<Person>()
            //    .HasDiscriminator<bool>(P => P.IsEmployee) 
            //    .HasValue<Student>(false)
            //    .HasValue<Teacher>(true);


            //just single dbset person need to make table and also we create our own discriminator 
            //modelBuilder.Entity<Person>()
            //    .HasDiscriminator<string>("PersonType")
            //    .HasValue<Student>("STD")
            //    .HasValue<Teacher>("TCH")





            ////table per concreate class with 2 dbset 
            //modelBuilder.Entity<Teacher>().ToTable("Teacher");
            //modelBuilder.Entity<Student>().ToTable("Student");

            // Global filter for Teachers only
            //modelBuilder.Entity<Teacher>()
            //    .HasQueryFilter(t => t.HireDate.Year > 2010);
            //in main var teachers = context.Teachers.ToList(); // Only teachers hired after 2010
            //in main var allTeachers = context.Teachers.IgnoreQueryFilters().ToList();
            base.OnModelCreating(modelBuilder);
        }
    }
}
