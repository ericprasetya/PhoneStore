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
    public partial class login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["login"] != null)
            {
                Response.Redirect("home.aspx");
            }
            lblError.Visible = false;

        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            String email = txtEmail.Text;
            String password = txtPassword.Text;
            String response = LoginController.ValidateLogin(email, password);
            if(!response.Equals(""))
            {
                lblError.Text = response;
                lblError.Visible = true;
            }else
            {
                user user = LoginController.DoLogin(email, password);
                if(user != null)
                {
                    Session["login"] = user.Id;
                    if(user.isAdmin == true)
                    {
                        Session["admin"] = user.Id;
                    }
                    Response.Redirect("home.aspx");
                }
                else
                {
                    lblError.Text = "wrong credentials";
                    lblError.Visible = true;
                }
            }
        }
    }
}