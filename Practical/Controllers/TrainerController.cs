using Practical.BizRepositories;
using Practical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical.Controllers
{
    public class TrainerController : Controller
    {
        ApplicationDbContext context;
        IBizRepositories<Trainer, int> trainer;
        public TrainerController()
        {
            context = new ApplicationDbContext();
            trainer = new TrainerRepository();
        }
        // GET: Trainer
        public ActionResult Index()
        {
            var result = trainer.GetData();
            return View(result);
        }
        public ActionResult Create(string uid)
        {
            var result = new Trainer();
            result.UID = uid;
            var last = trainer.GetData().OrderByDescending(p => p.TrainerId).FirstOrDefault();

            if (last == null)
            {
                result.TrainerId = "TNR1";
            }
            else
            {
                Int32.TryParse(last.TrainerId.Substring(3, last.TrainerId.Length - 3), out int x);
                result.TrainerId = "TNR" + (x + 1).ToString();
            }
            return View(result);
        }
        [HttpPost]
        public ActionResult Create(Trainer data)
        {
            if (ModelState.IsValid)
            {
                trainer.Create(data);
                TempData["Trainer"] = data;
                return RedirectToAction("Index","Home");
            }
            return View(data);
        }
        public ActionResult Edit(int id)
        {
            var result = trainer.GetData(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(int id, Trainer data)
        {
            if (ModelState.IsValid)
            {
                trainer.Update(id, data);
                return RedirectToAction("Index");
            }
            return View(data);
        }
        public ActionResult Delete(int id)
        {
            trainer.Delete(id);
            return RedirectToAction("Index");
        }
    }
}