using AutoMapper;
using JunBatchCodeFirstApproachImpl.Data;
using JunBatchCodeFirstApproachImpl.DTO;
using JunBatchCodeFirstApproachImpl.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace JunBatchCodeFirstApproachImpl.Controllers
{
    public class EmployeeHandlerController : Controller
    {

        ApplicationDbContext db;
        IMapper mapper;
        public EmployeeHandlerController(ApplicationDbContext db,IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            ViewBag.managers = new SelectList(db.managers.ToList(), "ManagerId", "ManagerName");
            return View();
        }

        public IActionResult AddEmployees(EmpAddDTO e)
        {
            var em = new Employee()
            {
                ename = e.ename,
                email = e.email,
                esalary = e.esalary,
                ManagerId = e.ManagerId
            };
            db.emps.Add(em);
            db.SaveChanges();
            return Json("");
        }

        public IActionResult FetchEmps()
        {
            var d = db.emps.Include(x=>x.mans).ToList();
            var mapdata = mapper.Map<List<EmpDTO>>(d);
            //var d = db.emps.Include(x => x.mans)
            //        .Select(e => new EmpDTO
            //        {
            //            eid=e.eid,
            //            ename=e.ename,
            //            email=e.email,
            //            esalary=e.esalary,
            //            ManagerId=e.ManagerId,
            //            ManagerName=e.mans!=null?e.mans.ManagerName:"No"
            //        }).ToList();
            return Json(mapdata);
        }

        public IActionResult EditEmployees(int eid)
        {
            var d=db.emps.Find(eid);
            return Json(d);
        }

        public IActionResult UpdateEmployees(EmpAddDTO e)
        {
            var em = new Employee()
            {
                eid=e.eid,
                ename = e.ename,
                email = e.email,
                esalary = e.esalary,
                ManagerId = e.ManagerId
            };

            db.emps.Update(em);
            db.SaveChanges();
            return Json("");
        }




    }
}
