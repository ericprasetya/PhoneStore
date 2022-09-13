using projectPSD.Factories;
using projectPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectPSD.Repositories
{
    public class CartRepository
    {
        private static projectDBEntities db = DBSingleton.GetInstance();
        public static List<cart> GetCarts()
        {
            return db.carts.ToList();
        }
        public static cart InsertToDB(String userId, String productId, int quantity)
        {
            cart cart = CartFactory.create(userId, productId, quantity);
            db.carts.Add(cart);
            db.SaveChanges();
            return cart;
        }

        public static cart CheckCart(String userId, String productId)
        {
            return (from cart in db.carts where cart.user_id.Equals(userId) && cart.product_id.Equals(productId) select cart).FirstOrDefault();
        }

        public static List<cart> GetCartsByUserId(String userId)
        {
            return (from cart in db.carts where cart.user_id.Equals(userId) select cart).ToList();
        }
        
        public static bool RemoveCart(String userId, String productId)
        {
            cart cart = CheckCart(userId, productId);
            db.carts.Remove(cart);
            db.SaveChanges();
            return true;
        }

        public static List<cart> RemoveUserCart(String userId)
        {
            List<cart> deletedCart = GetCartsByUserId(userId);
            foreach (cart cart in deletedCart)
            {
                db.carts.Remove(cart);
            }
            db.SaveChanges();
            return deletedCart;

        }
    }
}