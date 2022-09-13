using projectPSD.Controllers;
using projectPSD.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projectPSD.Views
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] != null)
            {
                Response.Redirect("home.aspx");
            }
            lblError.Visible = false;
        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            String name = txtName.Text;
            String email = txtEmail.Text;
            String password = txtPassword.Text;
            
            String response = RegisterController.DoRegister(name, email, password);

            if (response.Equals(""))
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                lblError.Text = response;
                lblError.Visible = true;
            }
           

        }
    }
}