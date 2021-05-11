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
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyWebsiteDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Table_chart", con);
            cmd.ExecuteNonQuery();
            SqlCommand cmdd = new SqlCommand("INSERT INTO Table_chart ( gün, tutar)  SELECT datename(weekday,SiparisTarihi), sum(SiparisTutari) FROM Siparis2 group by  datename(weekday,SiparisTarihi)", con);
            cmdd.ExecuteNonQuery();

            con.Close();
            if (Session["AdminName"] != null)
            {

                Login.Visible = false;
               BtnAdminLogOut.Visible = true;
            }
            else
            {

                Login.Visible = true;
                BtnAdminLogOut.Visible = false;
                // Response.Redirect("~/Default.aspx");
            }
        }



            protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string searchText = TxtSearch.Text.Trim();
            Response.Redirect("~/AdminSearch.aspx?ürün=" + searchText);
        }

   

        protected void BtnAdminLogOut_Click(object sender, EventArgs e)
        {
            if (Session["AdminName"] != null)
            {
                Login.Visible = false;
                BtnAdminLogOut.Visible = true;
                Session["AdminName"] = null;
                Response.Redirect("~/Products.aspx");
            }
        }
    }
}