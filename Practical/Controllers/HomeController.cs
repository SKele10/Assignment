using Practical.BizRepositories;
using Practical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical.Controllers
{
    public class HomeController : Controller
    {
        PracticalDbContext ctx;
        IBizRepositories<Course, int> course;
        public HomeController(PracticalDbContext dbContext)
        {
            this.ctx = dbContext;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public JsonResult getCourse()
        {
            List<Course> courses = ctx.Courses.OrderBy(c => c.CourseRowId).ToList();
            return Json(courses, JsonRequestBehavior.AllowGet);
        }
    }
}