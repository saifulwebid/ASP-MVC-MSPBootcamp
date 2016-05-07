namespace MvcBootcamp.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcBootcamp.Web.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MvcBootcamp.Web.Models.ApplicationDbContext context)
        {
            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var user = new ApplicationUser { UserName = "admin" };
                userManager.Create(user, "MvcBootcamp2016");
                roleManager.Create(new IdentityRole { Name = "Administrators" });
                userManager.AddToRole(user.Id, "Administrators");
            }

            if (!context.Users.Any(u => u.UserName == "user1"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var user = new ApplicationUser { UserName = "user1" };
                userManager.Create(user, "MvcBootcamp2016");
                roleManager.Create(new IdentityRole { Name = "Members" });
                userManager.AddToRole(user.Id, "Members");
            }
        }
    }
}
