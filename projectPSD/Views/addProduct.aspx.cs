using projectPSD.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projectPSD.Views
{
    public partial class addProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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
        }

        protected void AddProductBtn_Click(object sender, EventArgs e)
        {
            String name = TxtName.Text;
            String description = TxtDescription.Text;
            String productBrandId = BrandList.SelectedValue;
            int price = int.Parse(TxtPrice.Text);
            String response = ProductController.InsertToDB(name, price, description, productBrandId, ImageFile);
            if (response.Equals(""))
            {
                Response.Redirect("products.aspx");
            }
            else
            {
                lblError.Text = response;
                lblError.Visible = true;
            }
        }
    }
}