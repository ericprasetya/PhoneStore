using projectPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectPSD.Factories
{
    public class CartFactory
    {
        public static cart create(String userId, String productId, int quantity)
        {
            cart cart = new cart();
            cart.user_id = userId;
            cart.product_id = productId;
            cart.quantity = quantity;
            return cart;
        }
    }
}