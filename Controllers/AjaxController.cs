using JunBatchCodeFirstApproachImpl.Data;
using JunBatchCodeFirstApproachImpl.Models;
using Microsoft.AspNetCore.Mvc;

namespace JunBatchCodeFirstApproachImpl.Controllers
{
    public class AjaxController : Controller
    {
        ApplicationDbContext db;
        public AjaxController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee e)
        {
            db.emps.Add(e);
            db.SaveChanges();
            return Json("");
        }

        public IActionResult FetchEmployeeData()
        {
            var data=db.emps.ToList();
            return Json(data);
        }

        public IActionResult DelEmp(int empid)
        {
            var data=db.emps.Find(empid);
            db.emps.Remove(data);
            db.SaveChanges();
            return Json("");
        }

        public IActionResult SearchEmployeeData(string mydata)
        {
            if(mydata!=null)
            {
                var data = db.emps.Where(x => x.ename.Contains(mydata)).ToList();
                return Json(data);
            }
            else
            {
                var data = db.emps.ToList();
                return Json(data);
            }
            
        }
        
    }
}
