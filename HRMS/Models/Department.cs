using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace HRMS.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        public string Title { get; set; }
        
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Designation> Designations { get; set; }
    }
}