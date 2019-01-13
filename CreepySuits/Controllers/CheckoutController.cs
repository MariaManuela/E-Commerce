using CreepySuits.Models;
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
            var cart = ShoppingCart.GetCart(this.HttpContext);
            var orderH = ShoppingCart.GetOrder(this.HttpContext);
            var orderhistory = new OrderHistory();
            var product = new Product();
            var cp = new Cart();
            var order = new Order();
            TryUpdateModel(order);

            try {
                
                    order.Email = User.Identity.Name;
                    order.OrderDate = DateTime.Now;
                    order.Total = cart.GetTotal();


                //Save Order
                //db.OrderHistory.Add(orderhistory);
                db.Order.Add(order);
                    db.SaveChanges();
                //Process the order
                //var cart = ShoppingCart.GetCart(this.HttpContext);
                cart.KeepOrder(cp, order);

                //return RedirectToAction("Complete",
                //    new { id = order.OrderId });
                return View(order);
            }
            catch
            {
                orderH.AddToOrderHistory(product);
                //orderH.AddToOrderHistory(product);
                cart.ClearCart();
                
                
                //Invalid - redisplay with errors
                return View("Complete");
                
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
                //cart.ClearCart();
                return View(id);
            }
            else
            {
                return View("Error");
            }

           
        }
      
    }
}