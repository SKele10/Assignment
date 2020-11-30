using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practical.BizRepositories;
using Practical.Models;

namespace Practical.Controllers
{
    public class StudentCourseController : Controller
    {
        IBizRepositories<StudentCourse, int> studentCourseRep;
        PracticalDbContext context;
        public StudentCourseController()
        {
            studentCourseRep = new StudentCourseRepository();
            context = new PracticalDbContext();
        }
        // GET: StudentCourse
        [Authorize(Roles = "Student")]
        public ActionResult SelectCourse(int sid, int cid)
        {
            StudentCourse studentCourse = new StudentCourse();
            studentCourse.CourseRowId = Convert.ToInt32(context.Courses.Where(e => e.CourseRowId == cid).FirstOrDefault());
            studentCourse.StudentRowId = Convert.ToInt32(context.Students.Where(e => e.StudentRowId == sid).FirstOrDefault());
            studentCourse.Status = "Not Completed";
            context.studentCourses.Add(studentCourse);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles = "Student")]
        public ActionResult Index(string uid)
        {
            Student student = context.Students.Where(e => e.UID == uid).FirstOrDefault();
            List<StudentCourse> studentCourses = context.studentCourses.Where(e => e.StudentRowId == student.StudentRowId).ToList();
            return View(studentCourses);
        }
    }
}