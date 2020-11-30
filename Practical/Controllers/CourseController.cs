using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practical.BizRepositories;
using Practical.Models;

namespace Practical.Controllers
{
    public class CourseController : Controller
    {
        IBizRepositories<Course, int> course;
        IBizRepositories<Trainer, int> trainer;
        PracticalDbContext context;
        public CourseController()
        {
            context = new PracticalDbContext();
            course = new CourseRepository();
            trainer = new TrainerRepository();
        }
        // GET: Student
        public ActionResult Index()
        {
            var result = course.GetData();
            return View();
        }

        public JsonResult GetCourse()

        {
            List<Course> courses = context.Courses.OrderBy(e => e.CourseId).ToList();
            

            return Json(courses, JsonRequestBehavior.AllowGet);

        }
        public ActionResult CoursesByTrainer(string uid)
        {
            var result = course.GetData();
            //result = result.Where(e => e.Trainer.TrainerId == uid).ToList();
            return View(result);
        }
        [Authorize(Roles = "Trainer")]
        public ActionResult Create(string uid)
        {
            var result = new Course();
            result.Trainer = context.Trainers.Where(e => e.TrainerId == uid).FirstOrDefault();
            var last = course.GetData().OrderByDescending(p => p.CourseId).FirstOrDefault();
            result.Trainer = (Trainer)TempData["Trainer"];
            if (last == null)
            {
                result.CourseId = "CSE1";
            }
            else
            {
                Int32.TryParse(last.CourseId.Substring(3, last.CourseId.Length - 3), out int x);
                result.CourseId = "CSE" + (x + 1).ToString();
            }
            return View(result);
        }
        [HttpPost]
        public ActionResult Create(Course data)
        {
            if (ModelState.IsValid)
            {
                course.Create(data);
                return RedirectToAction("Index","Home");
            }
            return View(data);
        }
        [Authorize(Roles = "Trainer")]
        public ActionResult Edit(int id)
        {
            var result = course.GetData(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(int id,Course data)
        {
            if (ModelState.IsValid)
            {
                course.Update(id, data);
                return RedirectToAction("Index");
            }
            return View(data);
        }
        [Authorize(Roles = "Trainer")]
        public ActionResult Delete(int id)
        {
            course.Delete(id);
            return RedirectToAction("Index");
        }
    }
}