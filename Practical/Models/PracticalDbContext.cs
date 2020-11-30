using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Practical.Models
{
    public class PracticalDbContext : DbContext
    {
        public PracticalDbContext() : base("name = PracticalDbConnection")
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<StudentCourse> studentCourses { get; set; }
        //public DbSet<StudentCourse> studentCourses { get; set; }
        //public DbSet<TrainerCourse> trainerCourses { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}