using projectPSD.Controllers;
using projectPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projectPSD.Views
{
    public partial class productDetails : System.Web.UI.Page
    {
        public product prod = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["admin"] != null)
            {
                UserAction.Visible = false;
                AdminAction.Visible = true;
            }
            else
            {
                UserAction.Visible = true;
                AdminAction.Visible = false;
            }
            alertBox.Visible = false;
            if (Request.QueryString["msg"] != null)
            {
                alertBox.Visible = true;
                msgLbl.Text = Request.QueryString["msg"];
            }
            String productId = Request.QueryString["id"];
            prod = ProductController.GetProduct(productId);
            nameLbl.Text = prod.name;
            priceLbl.Text = prod.price.ToString();
            brandLbl.Text = prod.product_brands.name;
            descriptionLbl.Text = prod.description;
            if(prod.image == null)
            {
                productImage.ImageUrl = "https://source.unsplash.com/500x500?smartphone";
            }
            else
            {
                productImage.ImageUrl = prod.image;
            }
        }

        protected void addToCartBtn_Click(object sender, EventArgs e)
        {
            if(Session["login"] == null)
            {
                Response.Redirect("login.aspx");
            }
            
            Response.Redirect("~/Views/carts.aspx?id=" + prod.Id + "&quantity=" + quantityTxt.Text);
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/editProduct.aspx?id=" + prod.Id);
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            String productId = Request.QueryString["id"];
            if (ProductController.DeleteProduct(productId) != null)
            {
                Response.Redirect("~/Views/products.aspx?msg=" + "Successfull deleted the product");
            }
            
        }
    }
}