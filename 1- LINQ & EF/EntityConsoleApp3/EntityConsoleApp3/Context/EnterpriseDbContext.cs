using EntityConsoleApp3.Configuration;
using EntityConsoleApp3.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EntityConsoleApp3.Context
{
    public class EnterpriseDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Choose your provider (SQLite, SQL Server, etc.)
            optionsBuilder.UseSqlServer("data source =.;Initial Catalog =EnterpriseDb;Integrated Security =True;");
        }

        // Validate all added or modified entities
        public override int SaveChanges()
        {
            // Validate all added or modified entities
            foreach (var entry in ChangeTracker.Entries()
                                               .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified)) //no need for detached or deleted to validate
            {
                var entity = entry.Entity; //added or modified
                var Validationcontext = new ValidationContext(entity);
                Validator.ValidateObject(entity, Validationcontext, validateAllProperties: true); // 
            }

            return base.SaveChanges();
        }

        // fluent api method and also method 4 configuration class
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region fluent api
            //fluent api onmdel chaining 

            //protected override void OnModelCreating(ModelBuilder modelBuilder)
            //{
            //    // Composite key for Attendance
            //    modelBuilder.Entity<Attendance>() modelBuilder.Entity<Attendance>()
            //         .HasKey(a => a.ID});
            //                //.HasKey(a => new { a.EmployeeId, a.CourseId });
            //            modelBuilder.Entity<Attendance>()
            //                .Property(a => a.Name)
            //                .IsRequired()
            //                .HasMaxLength(50)
            //                .IsUnicode(false) //varchar just english not nvarcahr for 

            //            modelBuilder.Entity<Attendance>()
            //             .Property(a => a.year)
            //             .HasDefaultValue(DateTime.NOW.Year)
            //             //.HasAnnotation("Range",minand maz); #############################

            //            base.OnmMdelCreating(modelBuilder);
            //// or NEW CODE SYNTAX
            //modelBuilder.Entity<Attendance>() (DB=>
            //            {
            //                DB.HasKey(a => a.ID)

            //                DB.Property(a => a.Name)
            //                .IsRequired()
            //                .HasMaxLength(50)
            //                .IsUnicode(false);

            //         DB.Property(a => a.year)
            //                .HasDefaultValue(DateTime.NOW.Year)
            //             //.HasAnnotation("Range",minand maz);
            //          } );


            //        /*
            //            // Attendance relationships
            //            modelBuilder.Entity<Attendance>()
            //                .HasOne(a => a.Employee)
            //                .WithMany(e => e.Attendances)
            //                .HasForeignKey(a => a.EmployeeId);

            //            modelBuilder.Entity<Attendance>()
            //                .HasOne(a => a.TrainingCourse)
            //                .WithMany(c => c.Attendances)
            //                .HasForeignKey(a => a.CourseId);

            //            // Optional: Custom table names, column types, constraints etc.
            //            modelBuilder.Entity<Employee>()
            //                .Property(e => e.Salary)
            //                .HasColumnType("decimal(10,2)");

            //            // You can continue configuring more entities here...

            //             }
            //        }
            //                  * / 

            #endregion

            // or and make folder configuration 
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            //for each entity
            //modelBuilder.ApplyConfiguration(new DepartmentConfiguration());

            //modelBuilder.Entity<Employee>(){hasone ...} // no file so i wirte it here


           
            modelBuilder.Entity<StudentSubjectGrade>(entity =>
            {
                // Composite primary key for the join table
                entity.HasKey(ssg => new { ssg.StudentID, ssg.SubjectID });

                // Relationship with Student (one Student has many StudentSubjectGrades)
                entity.HasOne(ssg => ssg.Student)
                      .WithMany(s => s.StudentSubjectsGrade) // match this exactly
                      .HasForeignKey(ssg => ssg.StudentID);

                // Relationship with Subject (one Subject has many StudentSubjectGrades)
                entity.HasOne(ssg => ssg.Subject)
                      .WithMany(s => s.StudentSubjectsGrade) // match this exactly
                      .HasForeignKey(ssg => ssg.SubjectID);
            });                         
            base.OnModelCreating(modelBuilder);
        }
        

            


public virtual DbSet<Employee> Employees { get; set; } //virtual means if u create another class of DbContext and inherit from this EnterpriseDbContext so hi can override  table need to generate  virtual here not lazy loading its just lazy in class emp and dept
public virtual DbSet<Department> Departments { get; set; }//table need to generate 
public DbSet<TrainingCourse> TrainingCourses { get; set; }// u can just select courses without emp 

public virtual DbSet<Student> Students { get; set; }
public virtual DbSet<Subject> Subjects { get; set; }
    }
}
