using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CreepySuits.Models
{
    public class ShoppingCart
    {
       ApplicationDbContext db = new ApplicationDbContext();
        string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";
        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }

        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
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

            foreach(var cartItemCheckout in cartItemsCheckout)
            {
                db.Cart.Remove(cartItemCheckout);
            }

            db.SaveChanges();
        }

        public void EmptyCart()
        {
            var cartItems = db.Cart.Where(
                cart => cart.CartId == ShoppingCartId);

            foreach(var cartItem in cartItems)
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

            var cartItems = GetCartItems();
            foreach(var item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    ProductId = item.ProductId,
                    OrderId = order.OrderId,
                    UnitPrice = item.Product.Price,
                    Quantity = item.Count
                };

                orderTotal += (item.Count * item.Product.Price);
                db.OrderDetail.Add(orderDetail);
            }

            order.Total = orderTotal;
            db.SaveChanges();
            EmptyCart();
            return order.OrderId;
        }

        public string GetCartId(HttpContextBase context)
        {
            if(context.Session[CartSessionKey] == null)
            {
                if(!string.IsNullOrWhiteSpace(context.User.Identity.Name))
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

        public void MigrateCart(string userName)
        {
            var shoppingCart = db.Cart.Where(
                c => c.CartId == ShoppingCartId);

            foreach(Cart item in shoppingCart)
            {
                item.CartId = userName;
            }

            db.SaveChanges();
        }
    }
}