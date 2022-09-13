using projectPSD.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projectPSD.Views
{
    public partial class dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] != null)
            {
                String userId = Session["login"].ToString();
                if(TransactionController.GetUserTransactions(userId).Count == 0)
                {
                    lblTitle.Text = "There is no transaction yet, Please Checkout Your Cart!";
                }
                else
                {
                    TransactionRepeater.DataSource = TransactionController.GetUserTransactions(userId);
                    TransactionRepeater.DataBind();
                    lblTitle.Text = "Transaction List";
                }
            }
            else
            {
                Response.Redirect("login.aspx");
            }
            if(Session["admin"] != null)
            {
                AdminTable.Visible = true;
                AdminTable2.Visible = true;
                CustomerTable.Visible = false;
                AdminWaitingRepeater.DataSource = TransactionController.GetWaitingTransactions();
                AdminWaitingRepeater.DataBind();
                AdminRepeater.DataSource = TransactionController.GetUnwaitingTransactions();
                AdminRepeater.DataBind();
            }
            else
            {
                AdminTable.Visible = false;
                AdminTable2.Visible = false;
                CustomerTable.Visible = true;
            }
            alertBox.Visible = false;
            if (Request.QueryString["msg"] != null)
            {
                alertBox.Visible = true;
                msgLbl.Text = Request.QueryString["msg"];
            }

        }

        protected void ViewDetailBtn_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            String transactionId = linkButton.CommandArgument;
            Response.Redirect("~/Views/transactionDetail.aspx?id=" + transactionId);
        }

        protected void AcceptBtn_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            String transactionId = linkButton.CommandArgument;
            TransactionController.UpdateTransactionStatus(transactionId, "on going");
            Response.Redirect("~/Views/dashboard.aspx?msg=" + "Transaction Accepted!");
        }

        protected void DeclineBtn_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            String transactionId = linkButton.CommandArgument;
            TransactionController.UpdateTransactionStatus(transactionId, "declined");
            Response.Redirect("~/Views/dashboard.aspx?msg=" + "Transaction Declined!");
        }
    }
}