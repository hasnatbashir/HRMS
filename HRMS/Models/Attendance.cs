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
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int EmployeeID { get; set; }
        public Employee Employees { get; set; }
        public bool Status { get; set; }

        
    }
}