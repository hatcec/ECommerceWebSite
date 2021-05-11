using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace ECommerceWebSite
{
    public partial class AdminHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminName"] != null) {
            Label1.Text = "Admin  Sayfasına HoşGeldiniz: " + Session["AdminName"].ToString();
            }
            else
            {
                Response.Redirect("~/SignIn.aspx");
            }
        }
    }
}