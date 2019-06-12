using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HRMS.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HRMS.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var userStore = new UserStore<AppUser>(context);
            var userManager = new UserManager<AppUser>(userStore);
            var user = new AppUser { UserName = "hasnatbashir900@gmail.com",
                Email = "hasnatbashir900@gmail.com",
                EmailConfirmed = true,
                Name = "Hasnat"
            };

            var useremp = new AppUser { UserName = "hasnatbashir@gmail.com",
                Email = "hasnatbashir@gmail.com",
                EmailConfirmed = true,
                Name = "Hasnat Bashir"
            };

            userManager.Create(user, "password");
            userManager.Create(useremp, "password");
            roleManager.Create(new IdentityRole { Name = "admin" });
            roleManager.Create(new IdentityRole { Name = "employee" });
            userManager.AddToRole(user.Id, "admin");
            userManager.AddToRole(useremp.Id, "employee");

        }
    }
}
