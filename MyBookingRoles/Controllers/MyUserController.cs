using Microsoft.AspNet.Identity;
using MyBookingRoles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBookingRoles.Controllers
{
    [Authorize(Roles = "Customer")]
    public class MyUserController : Controller
    {
        private ApplicationDbContext context;

        public MyUserController()
        {
            context = new ApplicationDbContext();
        }

        // Index
        public ActionResult Index()
        {
            return View();
        }

        // UserProfile
        public ActionResult UserProfile()
        {
            return View();
        }

        public ActionResult RatingSerciveIndex()
        {
            var usr = User.Identity.GetUserName().ToString();
            var myrate_Services = context.Rate_Services.Where(b => b.Rate_ServiceUser == usr).ToList();
            return View(myrate_Services);
        }

        public ActionResult DeleteUser(string id)
        {
            var usr = context.Users.Find(id);
            return View(usr);
        }

        [HttpPost]
        [ActionName("DeleteUser")]
        public ActionResult DeleteUserConfirm(string id)
        {
            var usr = context.Users.Find(id);
            context.Users.Remove(usr);
            context.SaveChanges();
            return RedirectToAction("Login", "Account");
        }





















        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}