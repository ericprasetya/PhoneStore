using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projectPSD.Views
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void productPageBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("products.aspx");
        }

        protected void aboutUsPageBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("aboutUs.aspx");
        }
    }
}