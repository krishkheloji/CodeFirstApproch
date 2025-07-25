using JunBatchCodeFirstApproachImpl.Data;
using JunBatchCodeFirstApproachImpl.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JunBatchCodeFirstApproachImpl.Controllers
{
    public class ManagerController : Controller
    {
        ApplicationDbContext db;
        public ManagerController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var data=db.Manager.ToList();
            return View(data);
        }

        public IActionResult AddManager()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddManager(Manager m)
        {
            db.Manager.Add(m);
            db.SaveChanges();
            TempData["success"] = "Manager Added Successfully!!";
            return RedirectToAction("Index");
        }

        public IActionResult DelManager(int id)
        {
            //var d=db.Manager.Find(id);
            var data=db.Manager.Include(x => x.emps).FirstOrDefault(x => x.Mid.Equals(id));
            if(data.emps!=null)
            {
                TempData["errMsg"] = "can not delete this record";
            }
            else
            {
                db.Manager.Remove(data);
                db.SaveChanges();
                TempData["error"] = "Manager Deleted Successfully!!";
             
            }
            return RedirectToAction("Index");


        }

        public IActionResult AddDept()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDept(Dept d)
        {
            db.depts.Add(d);
            db.SaveChanges();
            TempData["success"] = "Dept Added Successfully!!";
            return RedirectToAction("Index");
        }


    }
}
