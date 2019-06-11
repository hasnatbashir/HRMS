using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace HRMS.Models
{
    public class Designation
    {
        [Key]
        public int ID { get; set; }
        public int DepartmentID { get; set; }
        public Department Departments { get; set; }
        public string DesignationTitle { get; set; }


    }
}