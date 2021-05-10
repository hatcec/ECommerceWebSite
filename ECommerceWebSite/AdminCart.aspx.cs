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
    public partial class AdminCart : System.Web.UI.Page
    {
        public static String ConnectString = ConfigurationManager.ConnectionStrings["MyWebsiteDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminUser"] != null)
            {
                BindCartCart();
            }
            else
            {
                Response.Redirect("~/SignIn.aspx");
            }
            
        }
        private void BindCartCart()
        {
            SqlConnection con = new SqlConnection(ConnectString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select S.id, S.SepetTutari,S.OlusturmaTarihi, U.UserName,  S.Durum from Sepet S inner join Tbl_Users U on U.Uid=S.KullaniciId ", con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            RepeaterCartCart.DataSource = dt;
            RepeaterCartCart.DataBind();
            con.Close();
        }
    }
}