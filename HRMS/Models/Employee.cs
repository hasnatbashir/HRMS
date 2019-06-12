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

        [Display(Name = "Picture")]
        [Required(ErrorMessage = "Field Required")]
        public string ImageUrl { get; set; }


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
        public string ResumeUrl { get; set; }

        [Display(Name = "Offer Letter")]
        public string OfferLetterUrl { get; set; }

        [Display(Name = "Joining Letter")]
        public string JoiningLetterUrl { get; set; }

        [Required(ErrorMessage = "Field Required")]
        public string Email { get; set; }

        public string Password { get; set; }

        public ICollection<Award> Awards { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
    }
}