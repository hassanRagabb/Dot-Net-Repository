using EfLect10;
using System;

namespace lect10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ContextClass context = new ContextClass())
            {
                #region tph cc with just 2 dbset teacher and student

                //var teacher = new Teacher { FullName = "Dr. Mona",HireDate=new DateTime(2005,1,24)};
                //context.Teacher.Add(teacher);//in memory local cash%
                //var stud = new Student() { FullName = "smsm", EnrolmentDate = new DateTime(2010, 1, 24) };
                //context..Student.Add(stud); //in memory local cash

                //context.SaveChanges(); //saved in ur database immedaitly


                //foreach (var teaches in context.Teachers)
                //{
                //    Console.WriteLine($"Name: {teaches.FullName}  {teaches.HireDate}");
                //}
                #endregion


                // deal with just One dbset PersOn and the teacher and student DBSETS ARE removed
                var teacher = new Teacher { FullName = "Dr. Mona", HireDate = new DateTime(2005, 1, 24) };
               
                var stud = new Student() { FullName = "smsm", EnrolmentDate = new DateTime(2010, 1, 24) };
               // in person
               // context.Person.Add(teacher);//in memory local cash% but in person 
               //context.Person.Add(stud); //in memory local cash

                context.SaveChanges(); //saved in ur database immedaitly


                foreach (var teaches in context.Person.OfType<Teacher>()) //type of add where in sql like where personType = "TCH"
                {
                    Console.WriteLine($"Name: {teaches.FullName}  {teaches.HireDate}");
                }
                foreach (var teaches in context.Person.OfType<Student>())
                {
                    Console.WriteLine($"Name: {teaches.FullName}  {teaches.EnrolmentDate}");
                }
            }
        }
    }
}