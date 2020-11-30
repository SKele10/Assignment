using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practical.BizRepositories;
using Practical.Models;

namespace Practical.Controllers
{

    public class StudentController : Controller
    {
        IBizRepositories<Student, int> student;
        IBizRepositories<Trainer, int> trainer;
        public StudentController()
        {
            student = new StudentRepository();
            trainer = new TrainerRepository();
        }
        // GET: Student
        public ActionResult Index()
        {
            var result = student.GetData();
            return View(result);
        }
        public ActionResult Create(string uid)
        {
            var result = new Student();
            result.UID = uid;
            var last = student.GetData().OrderByDescending(p => p.StudentId).FirstOrDefault();

            if (last == null)
            {
                result.StudentId = "STD1";
            }
            else
            {
                Int32.TryParse(last.StudentId.Substring(3, last.StudentId.Length - 3), out int x);
                result.StudentId = "STD" + (x + 1).ToString();
            }
            return View(result);
        }
        [HttpPost]
        public ActionResult Create(Student data)
        {
            if (ModelState.IsValid)
            {
                student.Create(data);
                return RedirectToAction("Index", "Home");
            }
            return View(data);
        }
        public ActionResult Edit(int id)
        {
            var result = student.GetData(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(int id, Student data)
        {
            if (ModelState.IsValid)
            {
                student.Update(id, data);
                return RedirectToAction("Index");
            }
            return View(data);
        }
        public ActionResult Delete(int id)
        {
            student.Delete(id);
            return RedirectToAction("Index");
        }
    }
}