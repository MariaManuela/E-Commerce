﻿using CreepySuits.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreepySuits.ViewModels;


namespace CreepySuits.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
  
        private ApplicationDbContext db = new ApplicationDbContext();
       // const string PromoCode = "FREE";
        //
        // GET: /Checkout/AddressAndPayment
        public ActionResult AddressAndPayment()
        {
            return View();
        }
        //
        // POST: /Checkout/AddressAndPayment
        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var order = new Order();
            TryUpdateModel(order);

            try
            {
                //if (string.Equals(values["PromoCode"], PromoCode,
                //    StringComparison.OrdinalIgnoreCase) == false)
                //{
                //    return View(order);
                //}
                //else
               // {
                    order.Email = User.Identity.Name;
                    order.OrderDate = DateTime.Now;

                    //Save Order
                    db.Order.Add(order);
                    db.SaveChanges();
                    //Process the order
                    var cart = ShoppingCart.GetCart(this.HttpContext);
                    cart.CreateOrder(order);

                    return RedirectToAction("Complete",
                        new { id = order.OrderId });
               // }
            }
            catch
            {
                //Invalid - redisplay with errors
                return View(order);
            }
        }
        //
        // GET: /Checkout/Complete
        public ActionResult Complete(int? id)
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            // Validate customer owns this order
            bool isValid = db.Order.Any(
                o => 
                o.Email == User.Identity.Name);

            if (isValid)
            {
                cart.ClearCart();
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }
    }
}