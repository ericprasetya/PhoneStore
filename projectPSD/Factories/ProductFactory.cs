using projectPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace projectPSD.Factories
{
    public class ProductFactory
    {

        public static product create(String id, String name, int price, String description, String product_brand_id, FileUpload image)
        {
            var img = image.PostedFile;
            var imgPath = "~/Public/ProductImage/" + DateTime.Now.ToString("yyyyMMddTHHmmss") + "_" + img.FileName;
            img.SaveAs(HttpContext.Current.Server.MapPath(imgPath));

            product product = new product();
            product.Id = id;
            product.name = name;
            product.price = price;
            product.description = description;
            product.product_brand_id = product_brand_id;
            product.image = imgPath;

            return product;
        }
    }
}