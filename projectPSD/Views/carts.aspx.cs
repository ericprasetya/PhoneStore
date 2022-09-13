using projectPSD.Controllers;
using projectPSD.Models;
using projectPSD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projectPSD.Views
{
    public partial class carts : System.Web.UI.Page
    {
        public List<cart> cartList = new List<cart>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if(Session["admin"] != null)
            {
                Response.Write("<script>alert('Admin doesnt have a cart')</script>");
                Response.Redirect("products.aspx");
            }

            String productId = Request.QueryString["id"];
            String userId = Session["login"].ToString();

            if (productId != null)
            {
                int quantity = Convert.ToInt32(Request.QueryString["quantity"]);
                cart cart = CartController.GetCart(userId, productId);
                if (cart != null)
                {
                    Response.Write("<script>alert('Already added to cart')</script>");
                }
                else
                {
                    CartController.InsertToDB(userId, productId, quantity);
                }
            }
            cartList = CartController.GetCartsByUserId(userId);
            if(cartList.Count == 0)
            {
                CheckoutBtn.Visible = false;
                lblTitle.Text = "Cart List is Empty, Please Add Product First!";
            }
            else
            {
                CheckoutBtn.Visible = true;
                lblTitle.Text = "Cart List";
                cartGridView.DataSource = cartList;
                cartGridView.DataBind();

            }
        }


        protected void cartGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = cartGridView.Rows[e.RowIndex];
            String id = row.Cells[0].Text.ToString();
            String userId = Session["login"].ToString();

            CartController.DeleteCart(userId, id);
            cartGridView.DataSource = CartController.GetCartsByUserId(userId);
            cartGridView.DataBind();
            Response.Redirect("carts.aspx");
        }

        protected void CheckoutBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("checkout.aspx");
        }
    }
}