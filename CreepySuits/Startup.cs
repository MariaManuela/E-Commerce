using CreepySuits.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System.ComponentModel.DataAnnotations;

[assembly: OwinStartupAttribute(typeof(CreepySuits.Startup))]
namespace CreepySuits
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //createRoles();
        }

        /*
        public void createRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(context));

            if(!roleManager.RoleExists("Visitor"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Visitor";
                roleManager.Create(role);
            }

            if(!roleManager.RoleExists("Admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }
        }*/
    }
}
