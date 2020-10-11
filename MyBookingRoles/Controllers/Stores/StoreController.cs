using MyBookingRoles.Models;
using MyBookingRoles.Models.Store;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Studio45.Controllers.Store
{

    public class StoreController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StoreHome

        public ActionResult ProdCatalogue()
        {
            return View(db.Products.ToList());
        }

        //
        //GET:/StoreHome/Browse
        public ActionResult Search()
        {
            //Search Code....
            //

            return View("ProdCatalogue");
        }

    }
}