﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;

using MyBookingRoles.Models;
using Owin;
using System.Data.Entity.Migrations;
using System.Linq;

[assembly: OwinStartupAttribute(typeof(MyBookingRoles.Startup))]
namespace MyBookingRoles
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateDefaultUsersAndRoles();
            Internals();
        }

        public void CreateDefaultUsersAndRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context)); 
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //Add SuperAdmin Role
            if (!roleManager.RoleExists("SuperAdmin"))
            {
                //create SuperAdmin
                var role = new IdentityRole("SuperAdmin");
                roleManager.Create(role);

                //Create SuperAdmin user
                var user = new ApplicationUser();
                user.UserName = "SuperAdmin@gmail.com";
                user.Email = "SuperAdmin@gmail.com";
                string pwd = "Password@2020";
                user.Name = "SuperAdmin";
               
                var newuser = userManager.Create(user, pwd);

                if(newuser.Succeeded)
                {
                    var result = userManager.AddToRole(user.Id, "SuperAdmin");                    
                }
            }

            //create Customer Role
            if (!roleManager.RoleExists("Customer"))
            {
                var Crole = new IdentityRole("Customer");
                roleManager.Create(Crole);
            }
        }

        public void Internals()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            //Ratings Rates
            context.Rates.AddOrUpdate(c => c.Rates_Name,
                new Models.RateService.Rates()
                {
                    Rates_Name = "Poor Rating"
                },
                new Models.RateService.Rates()
                {
                    Rates_Name = "Poorly Adequate Rating"
                },
                new Models.RateService.Rates()
                {
                    Rates_Name = "Average Rating"
                },
                new Models.RateService.Rates()
                {
                    Rates_Name = "Above Average Rating"
                },
                new Models.RateService.Rates()
                {
                    Rates_Name = "Excellent Performance Rating"
                });

            context.Category.AddOrUpdate(c => c.CategoryName,
                new Models.Store.Category()
                {
                    CategoryName = "Tripods"

                },
                new Models.Store.Category()
                {
                    CategoryName = "Cameras"
                },
                new Models.Store.Category()
                {
                    CategoryName = "Storage Device"
                });

            context.Brands.AddOrUpdate(c=>c.Name,
                new Models.Store.Brand()
                {
                    Name = "Samsung"
                },
                new Models.Store.Brand()
                {
                    Name = "Nikon"
                }, 
                new Models.Store.Brand()
                {
                    Name = "Apple"
                });
            //Save Changes
            context.SaveChanges();
        }
    }
}
