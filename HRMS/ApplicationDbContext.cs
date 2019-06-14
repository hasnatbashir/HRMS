using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using HRMS.Models;

namespace HRMS
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext() : base("HRMS")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<Designation> Designations { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<Holiday> Holidays{ get; set; }

    }
}