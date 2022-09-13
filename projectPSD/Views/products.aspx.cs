using projectPSD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projectPSD.Views
{
    public partial class products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductRepository repo = new ProductRepository(); 
            ProductRepeater.DataSource = ProductRepository.GetProducts(); 
            ProductRepeater.DataBind();

            alertBox.Visible = false;
            if (Request.QueryString["msg"] != null)
            {
                alertBox.Visible = true;
                msgLbl.Text = Request.QueryString["msg"];
            }
        }

        protected void ViewDetailBtn_Click(object sender, EventArgs e)
        {
            LinkButton linkbtn = (LinkButton)sender; 
            string id = linkbtn.CommandArgument; 
            Response.Redirect("~/Views/productDetails.aspx?id=" + id);
        }

        public string ProductImageAlt(object imagePath)
        {
            if(imagePath == null)
            {
                return "https://source.unsplash.com/500x500?smartphone";
            }
            return (string)imagePath;
        }
    }
}