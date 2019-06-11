using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace HRMS.Models
{
    public class Expense
    {
        [Key]
        public int ID { get; set; }
        public string Item { get; set; }
        public string PurchasedFrom { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int CashAmount { get; set; }
        public string BillUrl { get; set; }
    }
}