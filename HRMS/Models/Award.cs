using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace HRMS.Models
{
    public class Award
    {
        [Key]
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public Employee Employees { get; set; }
        public string Name { get; set; }
        public string Gift { get; set; }
        public string Cash { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
    }
}