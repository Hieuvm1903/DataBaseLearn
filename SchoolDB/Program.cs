using System.Collections;
using Microsoft.EntityFrameworkCore;

namespace SchoolDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
           




            Console.ReadKey();
        }
        static void Test4()
        {
            using (FactoryContext fc = new())
            {

                var s2 = fc.Students
                    //.ToList()
                    .Include(s => s.Grade)
                    ;
                //fc.Entry(s2.FirstOrDefault()).Reference(s => s.Grade).Load();
                foreach (var s in s2)
                {
                    //s.Grade= fc.Grades.Find(s.GradeId);

                    Console.WriteLine(s.Grade.GradeName);

                }





            }
        }
        static IEnumerable Test3()
        {
            using (FactoryContext fc = new())
            {
                foreach(var s in fc.Students)
                {

                    yield return s;
                }
                var s2 = fc.Students.Include(s => s.Grade);
            }
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
                var res = from s in students select  new{ s.FirstName,s.LastName} ;


            }
        }
        //Practice with entity state
        static void Test2()
        {
            using (FactoryContext fc = new())
            {
                var transaction = fc.Database.BeginTransaction();
                //Console.WriteLine("Before");
                //foreach (var stu in fc.Students)
                //{
                //    Console.WriteLine(stu.StudentId + stu.FirstName + stu.LastName);
                //}
                try
                {
                    Student s = new()
                    {
                        StudentId = 7,
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
                    transaction.Commit();
                }
                catch
                {
                    Console.WriteLine("Rollback");
                    transaction.Rollback();
                }
                
                
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