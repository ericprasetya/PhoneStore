using projectPSD.Handler;
using projectPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectPSD.Controllers
{
    public class CartController
    {
        public static void DeleteCart(String userId, String productId)
        {
            CartHandler.DeleteCart(userId, productId);
        }

        public static List<cart> GetCartsByUserId(String userId)
        {
            return CartHandler.GetCartsByUserId(userId);
        }

        public static void DeleteUserCart(String userId)
        {
            CartHandler.DeleteUserCart(userId);
        }

        public static cart GetCart(String userId, String productId)
        {
            return CartHandler.GetCart(userId, productId);
        }

        public static void InsertToDB(String userId, String productId, int quantity)
        {
            CartHandler.InsertToDB(userId, productId, quantity);
        }

        public static bool CheckAddress(String address)
        {
            if(address.Length > 250)
            {
                return false;
            }
            return true;
        }

        public static String CheckoutCart(String userId, String paymentId, String status, String address, bool assurance)
        {
            if (CheckAddress(address))
            {
                CartHandler.CheckoutCart(userId, paymentId, status, address, assurance);
                return "";
            }
            return "address must be less than 250 characters";
        }
    }
}