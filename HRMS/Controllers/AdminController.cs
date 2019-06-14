using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Models;
using HRMS.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HRMS.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin
        public ActionResult Index()
        {
            var attendances = db.Attendances.Include("Employees").Where(a => a.Date.Day == DateTime.Now.Day
                                                                                                              && a.Date.Month == DateTime.Now.Month
                                                                                                              && a.Date.Year == DateTime.Now.Year
                                                                                                              && a.Status == false).ToList();
            ViewBag.attendance = attendances;
            ViewBag.Employees = db.Employees.ToList().Count;
            ViewBag.Departments = db.Departments.ToList().Count;
            ViewBag.Awards = db.Awards.ToList().Count;
            return View();
        }

        public ActionResult Employees()
        {
            var employees = db.Employees.Include("Departments").ToList();
            List<DepartmentViewModel> depvmList = new List<DepartmentViewModel>();
            foreach (var dep in employees)
            {

                var designations = db.Designations.Where(d => d.DepartmentID == dep.Departments.DepartmentID).ToArray();
                List<string> desList = new List<string>();
                foreach (var des in designations)
                {

                    desList.Add(des.DesignationTitle);

                }
                DepartmentViewModel depvm = new DepartmentViewModel()
                {
                    DepartmentID = dep.DepartmentID,
                    Title = dep.Departments.Title,
                    Designations = desList.ToArray()
                };
                depvmList.Add(depvm);
            }
            ViewBag.Designations = depvmList;
            return View(employees);
        }

        public ActionResult EditEmployee(int id)
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
            var employee = db.Employees.Find(id);
            EmployeeViewModel employeevm = new EmployeeViewModel()
            {
                EmployeeID = employee.EmployeeID,
                Email = employee.Email,
                Name = employee.Name,
                FatherName = employee.FatherName,
                AccountHolderName = employee.AccountHolderName,
                AccountNumber = employee.AccountNumber,
                Address = employee.Address,
                BankName = employee.BankName,
                DepartmentID = employee.DepartmentID,
                DateofBirth = employee.DateofBirth,
                JoiningDate = employee.JoiningDate,
                CurrentSalary = employee.CurrentSalary,
                Branch = employee.Branch,
                Departments = employee.Departments,
                Phone = employee.Phone
            };
            ViewBag.Departments = depitems;
            return View(employeevm);
        }

        [HttpPost]
        public ActionResult EditEmployee(EmployeeViewModel editEmployeeViewModel)
        {
            if (ModelState.IsValid)
            {
                var department = db.Departments.FirstOrDefault(d => d.DepartmentID == editEmployeeViewModel.DepartmentID);
                var filePath = Path.Combine(Server.MapPath("~/Content/EmployeePictures"),
                    Path.GetFileName(editEmployeeViewModel.ImageUrl.FileName));
                editEmployeeViewModel.ImageUrl.SaveAs(filePath);
                Employee employee = new Employee()
                {
                    EmployeeID = editEmployeeViewModel.EmployeeID,
                    Email = editEmployeeViewModel.Email,
                    Name = editEmployeeViewModel.Name,
                    FatherName = editEmployeeViewModel.FatherName,
                    AccountHolderName = editEmployeeViewModel.AccountHolderName,
                    AccountNumber = editEmployeeViewModel.AccountNumber,
                    Address = editEmployeeViewModel.Address,
                    BankName = editEmployeeViewModel.BankName,
                    DepartmentID = editEmployeeViewModel.DepartmentID,
                    DateofBirth = editEmployeeViewModel.DateofBirth,
                    JoiningDate = editEmployeeViewModel.JoiningDate,
                    CurrentSalary = editEmployeeViewModel.CurrentSalary,
                    Branch = editEmployeeViewModel.Branch,
                    Departments = department,
                    Phone = editEmployeeViewModel.Phone,
                    ImageUrl = editEmployeeViewModel.ImageUrl.FileName,
                    Status = editEmployeeViewModel.Status
                };
                if (editEmployeeViewModel.ResumeUrl != null)
                {
                    filePath = Path.Combine(Server.MapPath("~/Content/EmployeeDocuments"),
                        Path.GetFileName(editEmployeeViewModel.ResumeUrl.FileName));
                    editEmployeeViewModel.ImageUrl.SaveAs(filePath);
                    employee.ResumeUrl = filePath;
                }

                if (editEmployeeViewModel.JoiningLetterUrl != null)
                {
                    filePath = Path.Combine(Server.MapPath("~/Content/EmployeeDocuments"),
                        Path.GetFileName(editEmployeeViewModel.JoiningLetterUrl.FileName));
                    editEmployeeViewModel.ImageUrl.SaveAs(filePath);
                    employee.JoiningLetterUrl = filePath;
                }

                if (editEmployeeViewModel.OfferLetterUrl != null)
                {
                    filePath = Path.Combine(Server.MapPath("~/Content/EmployeeDocuments"),
                        Path.GetFileName(editEmployeeViewModel.OfferLetterUrl.FileName));
                    editEmployeeViewModel.ImageUrl.SaveAs(filePath);
                    employee.OfferLetterUrl = filePath;
                }
                var roleStore = new RoleStore<IdentityRole>(db);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var userStore = new UserStore<AppUser>(db);
                var userManager = new UserManager<AppUser>(userStore);
                var user = new AppUser
                {
                    UserName = editEmployeeViewModel.Email,
                    Email = editEmployeeViewModel.Email,
                    EmailConfirmed = true,
                    Name = editEmployeeViewModel.Name
                };
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                userManager.Update(user);
                db.SaveChanges();
                return Redirect(Url.Action("Employees", "Admin"));
            }
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

        public ActionResult Departments()
        {
            var departments = db.Departments.ToList();
            List<DepartmentViewModel> depvmList = new List<DepartmentViewModel>();
            foreach (var dep in departments)
            {

                var designations = db.Designations.Where(d => d.DepartmentID == dep.DepartmentID).ToArray();
                List<string> desList = new List<string>();
                foreach (var des in designations)
                {
                    
                    desList.Add(des.DesignationTitle);

                }
                DepartmentViewModel depvm = new DepartmentViewModel()
                {
                    DepartmentID = dep.DepartmentID,
                    Title = dep.Title,
                    Designations = desList.ToArray()
                };
                depvmList.Add(depvm);
            }

            ViewBag.Departments = depvmList;
            return View();
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
        [Authorize(Roles = "admin")]
        public ActionResult AddEmployee(EmployeeViewModel addEmployee)
        {
            if (ModelState.IsValid)
            {
                var department = db.Departments.FirstOrDefault(d => d.DepartmentID == addEmployee.DepartmentID);
                var filePath = Path.Combine(Server.MapPath("~/Content/EmployeePictures"),
                    Path.GetFileName(addEmployee.ImageUrl.FileName));
                addEmployee.ImageUrl.SaveAs(filePath);
                Employee employee = new Employee()
                {
                    Email = addEmployee.Email,
                    Name = addEmployee.Name,
                    FatherName = addEmployee.FatherName,
                    AccountHolderName = addEmployee.AccountHolderName,
                    AccountNumber = addEmployee.AccountNumber,
                    Address = addEmployee.Address,
                    BankName = addEmployee.BankName,
                    DepartmentID = addEmployee.DepartmentID,
                    DateofBirth = addEmployee.DateofBirth,
                    JoiningDate = addEmployee.JoiningDate,
                    CurrentSalary = addEmployee.CurrentSalary,
                    Branch = addEmployee.Branch,
                    Departments = department,
                    Phone = addEmployee.Phone,
                    ImageUrl = addEmployee.ImageUrl.FileName,
                    Status = addEmployee.Status
                };
                if (addEmployee.ResumeUrl != null)
                {
                    filePath = Path.Combine(Server.MapPath("~/Content/EmployeeDocuments"),
                        Path.GetFileName(addEmployee.ResumeUrl.FileName));
                    addEmployee.ImageUrl.SaveAs(filePath);
                    employee.ResumeUrl = filePath;
                }

                if (addEmployee.JoiningLetterUrl != null)
                {
                    filePath = Path.Combine(Server.MapPath("~/Content/EmployeeDocuments"),
                        Path.GetFileName(addEmployee.JoiningLetterUrl.FileName));
                    addEmployee.ImageUrl.SaveAs(filePath);
                    employee.JoiningLetterUrl = filePath;
                }

                if (addEmployee.OfferLetterUrl != null)
                {
                    filePath = Path.Combine(Server.MapPath("~/Content/EmployeeDocuments"),
                        Path.GetFileName(addEmployee.OfferLetterUrl.FileName));
                    addEmployee.ImageUrl.SaveAs(filePath);
                    employee.OfferLetterUrl = filePath;
                }
                var roleStore = new RoleStore<IdentityRole>(db);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var userStore = new UserStore<AppUser>(db);
                var userManager = new UserManager<AppUser>(userStore);
                var user = new AppUser
                {
                    UserName = addEmployee.Email,
                    Email = addEmployee.Email,
                    EmailConfirmed = true,
                    Name = addEmployee.Name
                };
                userManager.Create(user, addEmployee.Password);
                db.Employees.Add(employee);
                db.SaveChanges();
                userManager.AddToRole(user.Id, "employee");
                db.SaveChanges();
                return Redirect(Url.Action("Employees", "Admin"));
            }
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
        public ActionResult AddDepartment(DepartmentViewModel depvm)
        {
            if (ModelState.IsValid)
            {
                Department dep = new Department()
                {
                    Title = depvm.Title,
                };
                db.Departments.Add(dep);
                db.SaveChanges();
                var departmenttoadd = db.Departments.SingleOrDefault(d => d.Title == dep.Title);
                List<Designation> designationList = new List<Designation>();
                foreach (var designation in depvm.Designations)
                {
                    Designation des = new Designation()
                    {
                        Departments = departmenttoadd,
                        DesignationTitle = designation
                    };
                    designationList.Add(des);
                }

                db.Designations.AddRange(designationList);
                db.SaveChanges();
            }

            var departments = db.Departments.ToList();
            List<DepartmentViewModel> depvmList = new List<DepartmentViewModel>();
            foreach (var dep in departments)
            {

                var designations = db.Designations.Where(d => d.DepartmentID == dep.DepartmentID).ToArray();
                List<string> desList = new List<string>();
                foreach (var des in designations)
                {

                    desList.Add(des.DesignationTitle);

                }
                DepartmentViewModel depVM = new DepartmentViewModel()
                {
                    DepartmentID = dep.DepartmentID,
                    Title = dep.Title,
                    Designations = desList.ToArray()
                };
                depvmList.Add(depVM);
            }

            ViewBag.Departments = depvmList;
            return View("Departments");
        }

        public ActionResult EditDepartment(int id)
        {
            var department = db.Departments.Find(id);
            List<DepartmentViewModel> depvmList = new List<DepartmentViewModel>();
            var designations = db.Designations.Where(d => d.DepartmentID == id).ToArray();
            List<string> desList = new List<string>();
            foreach (var des in designations)
            {

                desList.Add(des.DesignationTitle);

            }

            DepartmentViewModel depvm = new DepartmentViewModel()
            {
                DepartmentID = department.DepartmentID,
                Title = department.Title,
                Designations = desList.ToArray()
            };

            return View(depvm);
        }

        [HttpPost]
        public ActionResult EditDepartment(DepartmentViewModel departmentViewModel)
        {
            if (ModelState.IsValid)
            {
                Department dep = new Department()
                {
                    DepartmentID = departmentViewModel.DepartmentID,
                    Title = departmentViewModel.Title,
                };
                db.Entry(dep).State = EntityState.Modified;
                db.SaveChanges();
                List<Designation> designationList = new List<Designation>();
                foreach (var designation in departmentViewModel.Designations)
                {
                    Designation des = new Designation()
                    {
                        Departments = dep,
                        DesignationTitle = designation
                    };
                    designationList.Add(des);
                }

                db.Designations.RemoveRange(db.Designations.Where(des => des.DepartmentID == dep.DepartmentID));
                db.SaveChanges();
                db.Designations.AddRange(designationList);
                db.SaveChanges();
                return Redirect(Url.Action("Departments"));
            }

            var departments = db.Departments.ToList();
            List<DepartmentViewModel> depvmList = new List<DepartmentViewModel>();
            foreach (var dep in departments)
            {

                var designations = db.Designations.Where(d => d.DepartmentID == dep.DepartmentID).ToArray();
                List<string> desList = new List<string>();
                foreach (var des in designations)
                {

                    desList.Add(des.DesignationTitle);

                }
                DepartmentViewModel depVM = new DepartmentViewModel()
                {
                    DepartmentID = dep.DepartmentID,
                    Title = dep.Title,
                    Designations = desList.ToArray()
                };
                depvmList.Add(depVM);
            }

            ViewBag.Departments = depvmList;
            return View("EditDepartment");
        }

        public ActionResult Attendance(DateTime? id)
        {
            if (id == null)
            {
                id = DateTime.Now;
            }
            var attendances = db.Attendances.Include("Employees").Include("Employees.Departments").Where(a => a.Date.Day == id.Value.Day 
                                                                                                              && a.Date.Month == id.Value.Month
                                                                                                              && a.Date.Year == id.Value.Year).ToList();

            if (attendances == null || attendances.Count == 0)
            {
                var employees = db.Employees.Include("Departments").ToList();
                attendances = new List<Attendance>();
                foreach (var emp in employees)
                {
                    Attendance a = new Attendance()
                    {
                        Date = id.GetValueOrDefault(),
                        Employees = emp,
                        Status = false
                    };
                    attendances.Add(a);
                }
            }
            ViewBag.Attendances = attendances;
            return View();
        }

        [HttpPost]
        public ActionResult MarkAttendance(List<Attendance> attendances)
        {
            if (ModelState.IsValid)
            {
                var firstItem = attendances[0];
                foreach (var attendance in attendances)
                {
                    attendance.Employees = db.Employees.Find(attendance.EmployeeID);
                }

                var check = db.Attendances.FirstOrDefault(a => a.Date == firstItem.Date);
                if (check == null)
                {
                    db.Attendances.AddRange(attendances);
                    db.SaveChanges();
                }
                else
                {
                    foreach (var attendance in attendances)
                    {
                        var att = db.Attendances.SingleOrDefault(a => a.ID == attendance.ID);
                        att.Status = attendance.Status;
                        db.SaveChanges();
                    }

                }
            }
            var date = attendances[0].Date;
            var attends = db.Attendances.Include("Employees").Include("Employees.Departments").Where(a => a.Date == date).ToList();

            if (attends == null || attends.Count == 0)
            {
                var employees = db.Employees.Include("Departments").ToList();
                attends = new List<Attendance>();
                foreach (var emp in employees)
                {
                    Attendance a = new Attendance()
                    {
                        Date = date,
                        Employees = emp,
                        Status = false
                    };
                    attendances.Add(a);
                }
            }
            ViewBag.Attendances = attends;
            return View("Attendance");
        }

        public ActionResult ViewAttendance(DateTime? id)
        {
            if (id == null)
            {
                id = DateTime.Now;
            }
            var attendances = db.Attendances.Include("Employees").Include("Employees.Departments").Where(a => a.Date.Day == id.Value.Day
                                                                                                              && a.Date.Month == id.Value.Month
                                                                                                              && a.Date.Year == id.Value.Year).ToList();

            if (attendances == null || attendances.Count == 0)
            {
                var employees = db.Employees.Include("Departments").ToList();
                attendances = new List<Attendance>();
                foreach (var emp in employees)
                {
                    Attendance a = new Attendance()
                    {
                        Date = id.GetValueOrDefault(),
                        Employees = emp,
                        Status = false
                    };
                    attendances.Add(a);
                }
            }
            ViewBag.Attendances = attendances;
            return View();
            return View();
        }
    }
}