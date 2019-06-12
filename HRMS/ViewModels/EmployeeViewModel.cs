using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using HRMS.Models;

namespace HRMS.ViewModels
{
    public class EmployeeViewModel
    {
        [Key]
        public int EmployeeID { get; set; }

        [Display(Name = "Picture")]
        [Required(ErrorMessage = "Field Required")]
        public HttpPostedFileBase ImageUrl { get; set; }


        [Required(ErrorMessage = "Field Required")]
        public string Name { get; set; }

        [Display(Name = "Father's Name")]
        [Required(ErrorMessage = "Field Required")]
        public string FatherName { get; set; }

        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Field Required")]
        public DateTime DateofBirth { get; set; }


        [Required(ErrorMessage = "Field Required")]
        public string Phone { get; set; }


        [Required(ErrorMessage = "Field Required")]
        public string Address { get; set; }

        [Display(Name = "Department")]
        [Required(ErrorMessage = "Field Required")]
        public int DepartmentID { get; set; }
        public Department Departments { get; set; }

        [Display(Name = "Joining Date")]
        [Required(ErrorMessage = "Field Required")]
        public DateTime JoiningDate { get; set; }

        public bool Status { get; set; }

        [Display(Name = "Salary")]
        [Required(ErrorMessage = "Field Required")]
        public int CurrentSalary { get; set; }

        [Display(Name = "Account Holder's Name")]
        [Required(ErrorMessage = "Field Required")]
        public string AccountHolderName { get; set; }

        [Display(Name = "Account Number")]
        [Required(ErrorMessage = "Field Required")]
        public string AccountNumber { get; set; }

        [Display(Name = "Bank Name")]
        [Required(ErrorMessage = "Field Required")]
        public string BankName { get; set; }


        [Required(ErrorMessage = "Field Required")]
        public string Branch { get; set; }

        [Display(Name = "Resume")]
        public HttpPostedFileBase ResumeUrl { get; set; }

        [Display(Name = "Offer Letter")]
        public HttpPostedFileBase OfferLetterUrl { get; set; }

        [Display(Name = "Joining Letter")]
        public HttpPostedFileBase JoiningLetterUrl { get; set; }

        [Required(ErrorMessage = "Field Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Field Required")]
        public string Password { get; set; }
    }
}