using projectPSD.Models;
using projectPSD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace projectPSD.Handler
{
    public class ProductHandler
    {
        public static product GetProduct(String id)
        {
            return ProductRepository.GetProduct(id);
        }

        public static void InsertToDB(String name, int price, String description, String productBrandId, FileUpload image)
        {
            ProductRepository.InsertToDB(name, price, description, productBrandId, image);
        }

        public static List<product_brands> GetBrands()
        {
            return ProductRepository.GetBrands();
        }

        public static void UpdateProduct(String productId, String name, int price, String description, String productBrandId, FileUpload image)
        {
            ProductRepository.UpdateProduct(productId, name, price, description, productBrandId, image);        
        }

        public static product DeleteProduct(String productId)
        {
            return ProductRepository.DeleteProduct(productId);
        }
    }
}