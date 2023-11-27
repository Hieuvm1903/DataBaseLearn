using System.Collections;
using Microsoft.EntityFrameworkCore;

namespace SchoolDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(FactoryContext fc = new())
            {


                //var students = fc.Students.FromSql($"SelectStudent 6");
                //foreach(Student s in students)
                //{
                //    Console.WriteLine(s.FirstName+" "+s.LastName);

                //}
                Test1();


            }
            static void Test1()
            {
                using (FactoryContext fc = new())
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
                    fc.Students.Attach(s);
                    // Student st = fc.Students.Find(12);
                    // Console.WriteLine(fc.Entry(st).State);
                    // Console.WriteLine(st.FirstName);
                    foreach(var stu in fc.Students)
                    {
                        Console.WriteLine(stu.StudentId+stu.FirstName+stu.LastName);
                    }


                    fc.SaveChanges();
                    //var a = fc.Database.SqlQuery<string>($"Select firstname from students");
                    //foreach(var item in a)
                    //{
                    //    Console.WriteLine(item);                   
                    //}
                }
            }
        }
    }
}