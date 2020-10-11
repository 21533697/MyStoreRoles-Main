using MyBookingRoles.Models;
using MyBookingRoles.Models.Store;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Studio45.Controllers.Store
{
    public class AddToCartController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        //Studio45DAL _mdal = new Studio45DAL();
        // GET: AddToCart
        public ActionResult Add(Product mo)
        {
            if (Session["cart"] == null)
            {
                List<Product> li = new List<Product>();
                li.Add(mo);
                Session["cart"] = li;
                ViewBag.cart = li.Count();

                Session["count"] = 1;
            }
            else
            {
                List<Product> li = (List<Product>)Session["cart"];
                li.Add(mo);
                Session["cart"] = li;
                ViewBag.cart = li.Count();
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;
            }
            return RedirectToAction("Catalogue", "Products");
        }

        public ActionResult Myorder()
        {
            return View((List<Product>)Session["cart"]);
        }
        public ActionResult Remove(Product mob)
        {
            List<Product> li = (List<Product>)Session["cart"];
            li.RemoveAll(x => x.ProductID == mob.ProductID);
            Session["cart"] = li;
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            return RedirectToAction("Myorder", "AddToCart");
            //return View();
        }
    }
}