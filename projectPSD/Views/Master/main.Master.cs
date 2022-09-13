using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projectPSD.Views.Master
{
    public partial class main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["login"] != null)
            {
                guest.Visible = false;
                loggedIn.Visible = true;
                if(Session["admin"] != null)
                {
                    addProductBtn.Visible = true;
                    cartBtn.Visible = false;
                }
                else
                {
                    addProductBtn.Visible = false;
                    cartBtn.Visible = true;
                }

            }
            else
            {
                guest.Visible = true;
                loggedIn.Visible = false;
                
            }
        }


        protected void logoBtn_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("home.aspx");
        }

        protected void productBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("products.aspx");

        }

        protected void aboutUsBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("aboutUs.aspx");

        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");

        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("register.aspx");

        }

        protected void homeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");

        }

        protected void dashboardBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("dashboard.aspx");
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            Session.Remove("login");
            Session.Remove("admin");
            Response.Redirect("login.aspx");
        }

        protected void cartBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("carts.aspx");
        }

        protected void addProductBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("addProduct.aspx");
        }
    }
}