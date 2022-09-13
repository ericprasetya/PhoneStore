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
    public partial class transactionDetail : System.Web.UI.Page
    {
        List<transaction_details> transaction_Details = null;
        private const int DELIVERY_FEE = 20000;
        public String ProductImageAlt(object imagePath)
        {
            if (imagePath == null)
            {
                return "https://source.unsplash.com/500x500?smartphone";
            }
            return (String)imagePath;
        }
        transaction transaction = null;
        public void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] != null)
            {
                String transactionId = Request.QueryString["id"];
                transaction_Details = TransactionController.GetTransaction_Details(transactionId);
                transaction = TransactionController.GetTransaction(transactionId);

                txtSubtotal.Text = CountSubtotal().ToString();
                txtTotal.Text = CountTotal().ToString();
                TransactionRepeater.DataSource = transaction_Details;
                TransactionRepeater.DataBind();
                txtName.Text = transaction.user.name;
                txtEmail.Text = transaction.user.email;
                txtPayment.Text = transaction.payment.name;
                txtAddress.Text = transaction.address;
                txtDate.Text = transaction.transaction_date.ToString("G");
                txtStatus.Text = transaction.status;
                txtAssurance.Text = transaction.assurance ? "use assurance (added Rp 300000 to total)" : "not use assurance";
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
        private int CountSubtotal()
        {
            int subtotal = 0;
            foreach (transaction_details td in transaction_Details)
            {
                subtotal += td.product.price * td.quantity;
            }
            return subtotal;
        }

        private int CountTotal()
        {
            int assurance = transaction.assurance ? 300000 : 0;
            return CountSubtotal() + DELIVERY_FEE + assurance;
        }
    }
}