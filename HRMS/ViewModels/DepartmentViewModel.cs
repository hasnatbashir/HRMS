using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRMS.ViewModels
{
    public class DepartmentViewModel
    {
        public int DepartmentID { get; set; }
        public string Title { get; set; }

        public string[] Designations { get; set; }
    }
}