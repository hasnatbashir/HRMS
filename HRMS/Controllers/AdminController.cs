using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Models;
using HRMS.ViewModels;

namespace HRMS.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Employees()
        {
            return View();
        }

        public ActionResult Departments()
        {
            throw new NotImplementedException();
        }

        public ActionResult Awards()
        {
            throw new NotImplementedException();
        }

        public ActionResult Expenses()
        {
            throw new NotImplementedException();
        }

        public ActionResult Holidays()
        {
            throw new NotImplementedException();
        }

        public ActionResult AddEmployee()
        {
            var departments = db.Departments.ToList();
            List<SelectListItem> depitems = new List<SelectListItem>();
            foreach (var d in departments)
            {
                depitems.Add(new SelectListItem()
                {
                    Text = d.Title,
                    Value = d.DepartmentID.ToString()
                });
            }
            ViewBag.Departments = depitems;
            return View();
        }

        [HttpPost]
        [Authorize(Roles="admin")]
        public ActionResult AddEmployee(AddEmployeeViewModel addEmployee)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }

    }
}