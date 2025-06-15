using EntityConsoleApp3.Context;
using EntityConsoleApp3.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
namespace EntityConsoleApp3
{
    class Program
    {
        static void Main()
        {
           
            using (EnterpriseDbContext context = new EnterpriseDbContext())//for garbage collector
            {
                #region lecture 7 
                ////BAD PRACTICE to drop database each once if production database u will be fired
                ////context.Database.EnsureDeleted();//run delete then recreate it 
                ////context.Database.EnsureCreated(); 

                //context.Database.Migrate();
                //#region Insert to database

                //Department dept1 = new Department { Name = "IT" };//just in heap need to add to context
                //Department dept2 = new Department { Name = "HR" };
                //context.Departments.Add(dept1); //in memory
                //context.Add(dept2);// like above ef core 3.1 //local chash of dbset need to savechanges to added into db sql server


                //context.SaveChanges(); //at rutime connect to databaase like adaptor.update() and commit changes have entity state 
                //#endregion

                //#region Select , update it and save changes


                //// linq to entity framework
                //var departmentResult = context.Departments
                //                  .Where(d => d.Name == "IT"); //defared excution just link not go to database import linq 

                //Department d = departmentResult.FirstOrDefault(); //EXCUTED Defered
                //d.Name = "INFORMATION TECH"; //UPDATE VALUE but still in memory need save changes

                ////to know state f object is it modifeied changed ....
                ////Console.WriteLine(context.Entry(d).State);
                //context.SaveChanges();
                //#endregion

                //#region Remove
                //context.Departments.Remove(context.Departments.First());//remove from local
                //context.SaveChanges();//remove from database
                //#endregion


                //TrainingCourse course = new TrainingCourse()
                //{
                //    CourseTitle = "8th Happits",
                //    CourseDuration = 12,
                //    CourseURL = "www.8thHppp"
                //};// state is detached in memory not database
                ////context.Add(course);//state added
                //context.TrainingCourses.Add(course);//added not add TrainingCourses is table is context DBset<>  == context.Entry(course).State= EntityState.Added;
                //context.SaveChanges();



                //context.Employees.Add(new Employee()//in memory not database
                //{
                //    FName = "Hassan",
                //    LName = "Ragab",
                //    Age = 24,
                //    Address = "Giza",
                //    Salary = 5555,
                //    Department = context.Departments.FirstOrDefault(d => d.Name == "HR")

                //});
                //Employee emp2 = new Employee() //in memory not database
                //{
                //    FName = "sayed",
                //    LName = "Ragab",
                //    Age = 28,
                //    Address = "Giza",
                //    Salary = 5555,
                //    Department = context.Departments.FirstOrDefault(d => d.Name == "HR")

                //};
                //Console.WriteLine(context.Entry(emp2).State);//state is detached 
                //context.Employees.Add(emp2);//this line equal context.Entry(emp2).State= EntityState.Added; local must save but state is added
                //Console.WriteLine(context.Entry(emp2).State);//added 
                //context.SaveChanges();//
                //Console.WriteLine(context.Entry(emp2).State);//unchanged
                #endregion)



                #region many to many
                /*
                        Student smsmStudent = new Student() { FirstName ="smsm", LastName = "Hassan" };
                        Student hasokaStudent = new Student() { FirstName = "hasoka", LastName = "Hassan" };

                        Subject sub1 = new Subject() { Name = "math", Code = "MATH101", Credits = 3 };

                        Subject sub2 = new Subject() { Name = "science", Code = "SCIEN101",Credits = 3};
                        // Link subjects to students
                        smsmStudent.Subjects.Add(sub1);// smsm takes math
                        smsmStudent.Subjects.Add(sub2);

                        hasokaStudent.Subjects.Add(sub2); // hasoka  takes science
                        hasokaStudent.Subjects.Add(sub1);

                        context.AddRange(new Subject[] { sub1, sub2 });
                        context.Students.AddRange(new Student[] { smsmStudent, hasokaStudent });//==   sub1.Students.Add(smsmStudent); sub2.Students.Add(smsmStudent);

                        context.SaveChanges();
                        /*
                        // Optionally: Add the reverse navigation (not required by EF but good for clarity)
                        sub1.Students.Add(smsmStudent);
                        sub2.Students.Add(smsmStudent);// hasoka takes Science
                        context.Students.Add(smsmStudent);//###########################  sved to datbase
                        sub2.Students.Add(hasokaStudent);
                        context.Students.Add(hasokaStudent); //###########################  sved to datbase

                        context.SaveChanges();*/






                /*
               Student SAIKO1 = new Student() { FirstName = "SAIKO", LastName = "Hassan" };

               Student SAIKO2 = new Student() { FirstName = "medo", LastName = "Hassan" };
               Subject sub1 = new Subject() { Name = "os", Code = "OS101", Credits = 3 };
               Subject sub2 = new Subject() { Name = "DS", Code = "DS101", Credits = 3 };


               SAIKO1.StudentSubjectsGrade.Add(new StudentSubjectGrade() { Student = SAIKO1, Subject = sub1, Grade = 99 });
               SAIKO1.StudentSubjectsGrade.Add(new StudentSubjectGrade() { Student = SAIKO1, Subject = sub2, Grade = 95 });

               SAIKO2.StudentSubjectsGrade.Add(new StudentSubjectGrade() { Student = SAIKO2, Subject = sub1, Grade = 75 });
               SAIKO2.StudentSubjectsGrade.Add(new StudentSubjectGrade() { Student = SAIKO2, Subject = sub2, Grade = 88 });

               context.AddRange(new Student[] { SAIKO1, SAIKO2 });
               context.AddRange(new Subject[] { sub1, sub2 });
               context.SaveChanges();       */

                #endregion

                //var std = context.Students.First();
                //var subjectss = std.StudentSubjectsGrade;
                //foreach(var sub in subjectss)
                //{
                //    //Console.WriteLine(sub.Subject.StudentSubjectsGrade);
                //    Console.WriteLine(sub.Subject.Name);
                //} 

               
                
                //sql query ,plain text or stord proc ,sql function retun for all is entity framework like emp dept or student ..
                //return data is tracked if u update it the update will heared in database  to not tracked put it as keyless entity 
                
                //IEnumerable<Student> students =  context.Students.FromSqlRaw("SELECT * FROM Students").ToList();
                //var studentId = 1;
                //var student = context.Students
                //    .FromSqlInterpolated($"SELECT * FROM Students WHERE StudentID = {studentId}")
                //    .FirstOrDefault();



            }


        }
    }
}