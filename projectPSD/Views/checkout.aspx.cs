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
    public partial class checkout : System.Web.UI.Page
    {
        List<cart> carts = null;
        private const int DELIVERY_FEE = 20000;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] != null)
            {
                String userId = Session["login"].ToString();
                user user = LoginController.GetUserById(userId);
                carts = CartController.GetCartsByUserId(userId);
                txtSubtotal.Text = CountSubtotal().ToString();
                txtTotal.Text = CountTotal().ToString();
                cartRepeater.DataSource = CartController.GetCartsByUserId(userId);
                cartRepeater.DataBind();
                txtName.Text = user.name;
                txtEmail.Text = user.email;
                lblError.Visible = false;
                List<payment> payments = TransactionController.GetPayments();
                PaymentDropDownList.DataSource = payments;
                PaymentDropDownList.DataValueField = "Id";
                PaymentDropDownList.DataTextField = "name";
                PaymentDropDownList.DataBind();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        private int CountSubtotal()
        {
            int subtotal = 0;
            foreach(cart c in carts){
                subtotal += c.product.price * c.quantity;
            }
            return subtotal;
        }

        private int CountTotal()
        {
            return CountSubtotal() + DELIVERY_FEE;
        }

        protected void PayBtn_Click(object sender, EventArgs e)
        {
            String response = CartController.CheckoutCart(Session["login"].ToString(), PaymentDropDownList.SelectedValue, "waiting approval", txtAddress.Text, chkAssurance.Checked);
            if (response.Equals(""))
            {
                Response.Redirect("~/Views/dashboard.aspx?msg=" + "Transaction Success!");
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = response;
            }
        }

        public string ProductImageAlt(object imagePath)
        {
            if (imagePath == null)
            {
                return "https://source.unsplash.com/500x500?smartphone";
            }
            return (string)imagePath;
        }

        protected void chkAssurance_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAssurance.Checked)
            {
                txtTotal.Text = (CountTotal() + 300000).ToString() + " (added assurance Rp 300000)";
            }
            else
            {
                txtTotal.Text = CountTotal().ToString();
            }
        }
    }
}