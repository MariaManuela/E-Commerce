using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CreepySuits.Models
{
    public class ShoppingCart
    {
        ApplicationDbContext db = new ApplicationDbContext();
        string ShoppingCartId { get; set; }
        string OrderId { get; set; }
        public const string CartSessionKey = "CartId";
        public const string OrderSessionKey = "OrderId";
        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }

        public static ShoppingCart GetOrder(HttpContextBase context)
        {
            var order = new ShoppingCart();
            //order.OrderId = order.GetOrderId(context);
            return order;
        }

        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        public static ShoppingCart GetOrder(Controller controller)
        {
            return GetOrder(controller.HttpContext);
        }

        public void AddToCart(Product product)
        {
            if (product != null)
            {
                var cartItem = db.Cart.FirstOrDefault(
                    c => c.CartId == ShoppingCartId
                    && c.ProductId == product.ProductId && c.Name == product.Name && c.Price == product.Price);

                if (cartItem == null)
                {
                    cartItem = new Cart
                    {
                        Name = product.Name,
                        Price = product.Price,
                        ProductId = product.ProductId,
                        CartId = ShoppingCartId,
                        Count = 1,
                        DateCreated = DateTime.Now

                    };

                    db.Cart.Add(cartItem);
                }
                else
                {
                    //If the item does exist in the cart,
                    //then add one to the quantity
                    cartItem.Count++;

                }

                db.SaveChanges();
            }
        }

       

        public void AddToOrderHistory(Product product)
        {
         
              var orderItem = db.OrderHistory.FirstOrDefault(c => c.OrderHistoryId == OrderId && c.ProductId == product.ProductId && c.Name == product.Name && c.Price == product.Price);
            if (product == null)
            {
                orderItem = new OrderHistory
                {
                    RecordId = 1,
                    Name = product.Name,
                    Price = product.Price,
                    ProductId = product.ProductId,
                    OrderHistoryId = OrderId,
                    Count = 1,
                    DateCreated = DateTime.Now

                };



                try
                {
                    db.OrderHistory.Add(orderItem);
                    db.SaveChanges();
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }
            }
        }  

        public int RemoveFromCart(int? id)
        {
            var cartItem = db.Cart.SingleOrDefault(
                cart => cart.CartId == ShoppingCartId
                && cart.RecordId == id);

            int itemCount = 0;

            if (cartItem.Count > 1)
            {
                cartItem.Count--;
                itemCount = cartItem.Count;
            }
            else
            {
                db.Cart.Remove(cartItem);
            }

            db.SaveChanges();


            return itemCount;
        }

        public void ClearCart()
        {
            var cartItemsCheckout = db.Cart.ToList();

            foreach (var cartItemCheckout in cartItemsCheckout)
            {
                db.Cart.Remove(cartItemCheckout);
            }

            db.SaveChanges();
        }

        public void EmptyCart()
        {
            var cartItems = db.Cart.Where(
                cart => cart.CartId == ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                db.Cart.Remove(cartItem);
            }

            db.SaveChanges();
        }

        public List<Cart> GetCartItems()
        {

            return db.Cart.Where(
                cart => cart.CartId == ShoppingCartId).ToList();
        }

        public List<OrderHistory> GetEachOrder()
        {
            return db.OrderHistory.Where(order => order.OrderHistoryId == OrderId).ToList();
        }

        public int GetCount()
        {
            int? count = (from cartItems in db.Cart
                          where cartItems.CartId == ShoppingCartId
                          select (int?)cartItems.Count).Sum();
            //return 0 if all entities are null
            return count ?? 0;
        }

        public decimal GetTotal()
        {
            // Multiply product price by count of that product to get 
            // the current price for each of those products in the cart
            // sum all product price totals to get the cart total

            decimal? total = (from cartItems in db.Cart
                              where cartItems.CartId == ShoppingCartId
                              select (decimal?)cartItems.Count *
                              cartItems.Product.Price).Sum();
            return total ?? decimal.Zero;

        }

        public int CreateOrder(Order order)
        {
            decimal orderTotal = 0;

            var cartItems = GetEachOrder();
            foreach (var item in cartItems)
            {
                var orderHistory = new OrderHistory
                {
                    //ProductId = item.ProductId,
                    
                    RecordId = order.OrderId,
                    Price = item.Product.Price,
                    //Quantity = item.Count
                };

                orderTotal += (item.Count * item.Product.Price);
                db.OrderHistory.Add(orderHistory);
            }

            order.Total = orderTotal;
            db.SaveChanges();
            //EmptyCart();
            return order.OrderId;
        }

        public void KeepOrder(Cart cart, Order order)
        {
            if (cart != null)
            {
                
                var keepOrder = db.OrderDetail.FirstOrDefault(
                    c => c.OrderId == order.OrderId
                    && c.UnitPrice == order.Total && c.ProductName ==cart.Product.Name);

                if (keepOrder == null)
                {
                    keepOrder = new OrderDetail
                    {
                        OrderId = order.OrderId,
                        UnitPrice = order.Total,
                        ProductName = cart.Product.Name

                    };

                    db.OrderDetail.Add(keepOrder);
                    db.SaveChanges();
                }
               
            }
           
        }

        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    Guid tempCartId = Guid.NewGuid();
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }

        //public string GetOrderId(HttpContextBase context)
        //{
        //    if (context.Session[OrderSessionKey] == null)
        //    {
        //        if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
        //        {
        //            context.Session[OrderSessionKey] = context.User.Identity.Name;
        //        }
        //        else
        //        {
        //            Guid tempOrderId = Guid.NewGuid();
        //            context.Session[OrderSessionKey] = tempOrderId.ToString();
        //        }
        //    }
        //    return context.Session[OrderSessionKey].ToString();
        //}

        public void MigrateCart(string userName)
        {
            var shoppingCart = db.Cart.Where(
                c => c.CartId == ShoppingCartId);

            foreach (Cart item in shoppingCart)
            {
                item.CartId = userName;
            }

            db.SaveChanges();
        }

        //public void MigrateOrder(string userName)
        //{
        //    var order = db.OrderHistory.Where(
        //        c => c.OrderHistoryId == ShoppingCartId);

        //    foreach (OrderHistory item in order)
        //    {
        //        item.OrderHistoryId = userName;
        //    }

        //    db.SaveChanges();
        //}
        public void UpdateOrder(Order order)
        {
        
                    db.Order.Add(order);
                    db.SaveChanges();


        }

    }
}