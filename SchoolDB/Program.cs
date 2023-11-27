using System.Collections;
using Microsoft.EntityFrameworkCore;

namespace SchoolDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Test2();

            Console.ReadKey();
        }
        static void Test1()
        {
            using (FactoryContext fc = new())
            {



                fc.Database.ExecuteSqlRaw("""
                   Create or alter Procedure [dbo].[SelectStudent] @id int
                   as 
                   Select * from Students where StudentId = @id;
                   
                   """);
                var students = fc.Students.FromSql($"SelectStudent 6");
                foreach (Student s in students)
                {
                    Console.WriteLine(s.FirstName + " " + s.LastName);

                }



            }
        }
        //Practice with entity state
        static void Test2()
        {
            using (FactoryContext fc = new())
            {
                //Console.WriteLine("Before");
                //foreach (var stu in fc.Students)
                //{
                //    Console.WriteLine(stu.StudentId + stu.FirstName + stu.LastName);
                //}
                Student s = new()
                {
                    StudentId = 100,
                    FirstName = "urc",
                    LastName = "Evol",
                    DateOfBirth = DateTime.Now,
                    Weight = 50,
                    Height = 173,
                    GradeId = 1,
                    Photo = [1, 2]
                };
                Console.WriteLine("After");
                fc.Students.Attach(s);
                Console.WriteLine(fc.Entry(s).State);
                foreach (var stu in fc.Students)
                {
                    Console.WriteLine(stu.StudentId + stu.FirstName + stu.LastName);
                }
                fc.SaveChanges();
                
            }
        }
        static void TestExec()
        {
            using(FactoryContext fc = new())
            {
                var a = fc.Database.SqlQuery<string>($"Select firstname from students");
                foreach (var item in a)
                {
                    Console.WriteLine(item);
                }
            }

        }

    }
}