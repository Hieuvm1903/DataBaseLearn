using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SchoolDB
{
    internal class FactoryContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=School;Trusted_Connection=True;TrustServerCertificate=True;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasMany(x => x.Courses).WithMany(x => x.Students)
                //.UsingEntity<StudentCourse>()
            ;
            //modelBuilder.Entity<Course>().InsertUsingStoredProcedure();
            //modelBuilder.Entity<StudentCourse>().ToView("StdC");

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Course> Courses { get; set; }
        public  DbSet<StudentCourse> StdC { get; set; }
    }
    
    public class Student
    {
        public Student()
        {
        }
        public int StudentId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
       
        public byte[] Photo { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }
        
        public int GradeId { get; set; }
        public Grade Grade { get; set; }
        public HashSet<Course> Courses { get; } = new HashSet<Course>();
        public HashSet<Student> Friends { get; } = new HashSet<Student>();
    }

    public class Grade
    {
        public Grade()
        {
            Students = new List<Student>();
        }

        public int GradeId { get; set; }
        public string GradeName { get; set; }

        public IList<Student> Students { get; set; }
    }
    public class Course
    {
        public HashSet<Student> Students { get; } = new HashSet<Student>();
        //public HashSet<StudentCourse> StudentCourse { get; set; }

        public int CourseID { get; set; }

    }
    [Keyless]
    public class StudentCourse
    {
        public int StudentID { get; set; }
        public int CourseID { get; set; }


    }
}
