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
   
    public partial class OrderList : System.Web.UI.Page
    {
        public static String ConnectString = ConfigurationManager.ConnectionStrings["MyWebsiteDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
           
                BindOrderCart();
          
            
        }
        private void BindOrderCart()
        {
            SqlConnection con = new SqlConnection(ConnectString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select S.Id, S.SepetId, U.UserName, S.SiparisTarihi, S.SiparisTutari, S.Durum from Siparis2 S inner join Tbl_Users U on U.Uid=S.KullaniciId ", con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            RepeaterOrderCart.DataSource = dt;
            RepeaterOrderCart.DataBind();
            con.Close();
        }
    }
}