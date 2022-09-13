using projectPSD.Handler;
using projectPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace projectPSD.Controllers
{
    public class ProductController
    {
        public static product GetProduct(String id)
        {
            return ProductHandler.GetProduct(id);
        }

        public static string CheckName(String name)
        {
            if (name.Length == 0) return "name cannot be empty";
            return "";
        }

        public static string CheckDescription(String description)
        {
            if (description.Length == 0) return "description cannot be empty";
            else if (description.Length >= 250) return "description length must be lest than 250 characters";
            return "";
        }

        public static string CheckImage(FileUpload image)
        {
            if (image.HasFile == false) return "image cannot be empty";
            if (System.IO.Path.GetExtension(image.FileName) != ".png" && System.IO.Path.GetExtension(image.FileName) != ".jpeg" && System.IO.Path.GetExtension(image.FileName) != ".jpg") return "image must be .png or .jpg or .jpeg";
            if (image.PostedFile.ContentLength > 5242880) return "image size must be less than 5MB";
            return "";
        }

        public static String InsertToDB(String name, int price, String description, String productBrandId, FileUpload image)
        {
            String response = CheckName(name);
            if (response.Equals("")) response = CheckPrice(price);
            if (response.Equals("")) response = CheckDescription(description);
            if (response.Equals("")) response = CheckImage(image);

            if (response.Equals(""))
            {
                ProductHandler.InsertToDB(name, price, description, productBrandId, image);
            }
            return response;
        }

        public static String UpdateProduct(String productId, String name, int price, String description, String productBrandId, FileUpload image)
        {
            String response = CheckName(name);
            if (response.Equals("")) response = CheckPrice(price);
            if (response.Equals("")) response = CheckDescription(description);
            if (response.Equals("") && image.HasFile) response = CheckImage(image);

            if (response.Equals(""))
            {
                ProductHandler.UpdateProduct(productId, name, price, description, productBrandId, image);
            }
            return response;
        }

            private static string CheckPrice(int price)
        {
            if (price <= 0) return "Price must be greater than 0";
            return "";
        }

        public static List<product_brands> GetBrands()
        {
            return ProductHandler.GetBrands();
        }
        public static product DeleteProduct(String productId)
        {
            return ProductHandler.DeleteProduct(productId);
        }
    }
}