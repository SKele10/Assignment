using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Practical.Models
{
    public class Student
    {
        [Key]
        public int StudentRowId { get; set; }
        public string StudentId  { get; set; }
        [Required(ErrorMessage = "Email is Must")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Address is Must")]
        public string Address { get; set; }
        [Required(ErrorMessage = "City is Must")]
        public string City { get; set; }
        [Required(ErrorMessage = "Select AreaOfInterests")]
        public string AreaOfInterests { get; set; }
        [Required(ErrorMessage = "Enter BirthDate")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Number is Must")]
        public int Mobile { get; set; }
        public string UID { get; set; }

    }
    public class Course
    {
        [Key]
        public int CourseRowId { get; set; }
        public string CourseId { get; set; }
        [Required(ErrorMessage = "Course Name is Must")]
        public string CourseName { get; set; }
        [Required(ErrorMessage = "Course Area is Must")]
        public string CourseArea { get; set; }
        [Required(ErrorMessage = "Modules is Must")]
        public int Modules { get; set; }
        [Required(ErrorMessage = "Price is Must")]
        public int Price { get; set; }
        public virtual Trainer Trainer { get; set; }
    }
    public class Trainer
    {
        [Key]
        public int TrainerRowId { get; set; }
        public string TrainerId { get; set; }
        [Required(ErrorMessage = "Name is Must")]
        public string TrainerName { get; set; }
        [Required(ErrorMessage = "Expertise Area is Must")]
        public string ExpertiseArea { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public string UID { get; set; }

    }
    public class StudentCourse
    {
        [Key]
        public int StudentCourseRowId { get; set; }
        public virtual int CourseRowId { get; set; }
        public virtual int StudentRowId { get; set; }
        public string Status { get; set; }
    }
    //public class TrainerCourse
    //{
    //    [Key]
    //    [Column(Order = 0)]
    //    public Trainer Trainer { get; set; }
    //    [Key]
    //    [Column(Order = 1)]
    //    public Course Course { get; set; }
    //}
}