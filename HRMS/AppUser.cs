using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HRMS
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
    }
}