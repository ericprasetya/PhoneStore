using projectPSD.Models;
using projectPSD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectPSD.Handler
{
    public class CartHandler
    {
        public static void DeleteCart(String userId, String productId)
        {
            CartRepository.RemoveCart(userId, productId);
        }

        public static List<cart> GetCartsByUserId(String userId)
        {
            return CartRepository.GetCartsByUserId(userId);
        }

        public static void DeleteUserCart(String userId)
        {
            CartRepository.RemoveUserCart(userId);
        }

        public static cart GetCart(String userId, String productId)
        {
            return CartRepository.CheckCart(userId, productId);
        }

        public static void InsertToDB(String userId, String productId, int quantity)
        {
            CartRepository.InsertToDB(userId, productId, quantity);
        }

        public static void CheckoutCart(String userId, String paymentId, String status, String address, bool assurance)
        {
            TransactionHandler.InsertToDB(userId, paymentId, status, CartRepository.RemoveUserCart(userId), address, assurance);
        }
    }
}