using projectPSD.Factories;
using projectPSD.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace projectPSD.Repositories
{
    public class ProductRepository
    {
        private static projectDBEntities db = DBSingleton.GetInstance();
        public static dynamic GetProducts()
        {
            return db.products.Join(db.product_brands,
                product => product.product_brand_id,
                brand => brand.Id,
                (product, brand) => new
                {
                    ProductId = product.Id,
                    ProductName = product.name,
                    ProductDescription = product.description,
                    ProductBrand = brand.name,
                    ProductPrice = product.price,
                    ProductImage = product.image
                }).ToList();
        }

        public static bool DeleteImage(String imagePath)
        {
            FileInfo deleteImage = new FileInfo(HttpContext.Current.Server.MapPath(imagePath));
            if (deleteImage.Exists)
            {
                deleteImage.Delete();
                return true;
            }
            return false;
        }

        public static void UpdateProduct(String productId, String name, int price, String description, String productBrandId, FileUpload image)
        {
            product product = db.products.Where(x => x.Id == productId).FirstOrDefault();
            if (image.HasFile) // bila ada image utk update
            {
                if (product.image != null) //delete dulu yang lama
                {
                    DeleteImage(product.image);
                }
                //simpan image update
                var img = image.PostedFile;
                var imgPath = "~/Public/ProductImage/" + DateTime.Now.ToString("yyyyMMddTHHmmss") + "_" + img.FileName;
                img.SaveAs(HttpContext.Current.Server.MapPath(imgPath));
                product.image = imgPath;
            }
            //jika tidak ada image utk update maka tidak perlu ubah ubah imagenya
            
            product.name = name;
            product.price = price;
            product.description = description;
            product.product_brand_id = productBrandId;

            db.SaveChanges();
        }

        public static product DeleteProduct(String productId)
        {
            product product = GetProduct(productId);
            if (product == null) return null;
            if (product.image != null)
            {
                DeleteImage(product.image);
            }
            db.products.Remove(product);
            db.SaveChanges();
            return product;
        }

        public static product GetProduct(String id)
        {
            return (from product in db.products where product.Id == id select product).FirstOrDefault();
        }

        public static String GetLastId()
        {
            product product = db.products.ToList().LastOrDefault();
            return product.Id;
        }

        public static String GenerateId()
        {
            String nextId = "";
            String lastId = GetLastId();
            if (lastId != null)
            {
                int lastNumber = Convert.ToInt32(lastId.Substring(2));
                nextId = String.Format("PR{0:000}", lastNumber + 1);
            }
            else
            {
                nextId = "US001";
            }
            return nextId;
        }

        public static void InsertToDB(String name, int price, String description, String productBrandId, FileUpload image)
        {
            product product = ProductFactory.create(GenerateId(), name, price, description, productBrandId, image);
            db.products.Add(product);
            db.SaveChanges();
        }

        public static List<product_brands> GetBrands()
        {
            return db.product_brands.ToList();
        }
    }
}