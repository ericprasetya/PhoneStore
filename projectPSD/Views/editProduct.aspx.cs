using projectPSD.Controllers;
using projectPSD.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projectPSD.Views
{
    public partial class editProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["login"] == null)
                {
                    Response.Redirect("login.aspx");
                }
                if (Session["admin"] == null)
                {
                    Response.Redirect("home.aspx");
                }
                BrandList.DataSource = ProductController.GetBrands();
                BrandList.DataValueField = "Id";
                BrandList.DataTextField = "name";
                BrandList.DataBind();
                lblError.Visible = false;

                String productId = Request.QueryString["id"];
                product prod = ProductController.GetProduct(productId);

                TxtDescription.Text = prod.description;
                TxtName.Text = prod.name;
                TxtPrice.Text = prod.price.ToString();
                BrandList.SelectedValue = prod.product_brand_id;
            }

        }

        protected void EditProductBtn_Click(object sender, EventArgs e)
        {
            String name = TxtName.Text;
            String description = TxtDescription.Text;
            String productBrandId = BrandList.SelectedValue;
            int price = int.Parse(TxtPrice.Text);
            String productId = Request.QueryString["id"];

            String response = ProductController.UpdateProduct(productId, name, price, description, productBrandId, ImageFile);
            if (response.Equals(""))
            {
                Response.Redirect("~/Views/productDetails.aspx?id=" + productId  + "&msg=" + "Successfull edited the product");
            }
            else
            {
                lblError.Text = response;
                lblError.Visible = true;
            }
        }
    }
}