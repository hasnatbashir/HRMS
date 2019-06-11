using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace HRMS.Models
{
    public class Holiday
    {
        [Key]
        public DateTime Date { get; set; }
        public string Reason { get; set; }
    }
}