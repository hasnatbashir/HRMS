using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace HRMS.Models
{
    public class Attendance
    {
        [Key]
        public DateTime Date { get; set; }
        public int EmployeeID { get; set; }
        public Employee Employees { get; set; }
        public string Status { get; set; }

        
    }
}