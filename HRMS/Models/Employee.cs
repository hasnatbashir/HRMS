using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public int DepartmentID { get; set; }
        public Department Departments { get; set; }
        public DateTime JoiningDate { get; set; }
        public int CurrentSalary { get; set; }
        public string AccountHolderName { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public string Branch { get; set; }
        public string ResumeUrl { get; set; }
        public string OfferLetterUrl { get; set; }
        public string JoiningLetterUrl { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<Award> Awards { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
    }
}