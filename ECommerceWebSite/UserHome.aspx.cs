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
    public partial class UserHome : System.Web.UI.Page
    {
        public static String ConnectString = ConfigurationManager.ConnectionStrings["MyWebsiteDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (IsPostBack)
            {
                string searchText = TxtSearch.Text.Trim();
                Response.Redirect("~/Search.aspx?product=" + searchText);
            }

           
            if (Session["UserName"] != null)
            {
                BindOrderCart();
                LblSuccess.Text = "Giriş Yapıldı, Hoşgeldiniz " + Session["UserName"].ToString();
                BtnLogOut.Visible = true;
                BtnLogIn.Visible = false;

            }
            else
            {
                BtnLogIn.Visible = true;
                BtnLogOut.Visible = false;
                Response.Redirect("~/SignIn.aspx");
            }
        }

        private void BindOrderCart()
        {
            SqlConnection con = new SqlConnection(ConnectString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select S.Id, S.SepetId, U.UserName, S.SiparisTarihi, S.SiparisTutari, S.Durum from Siparis2 S inner join Tbl_Users U on U.Uid=S.KullaniciId where S.KullaniciId=@ui", con);
            cmd.Parameters.AddWithValue("@ui", Convert.ToInt32(Session["UserID"]));
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            RepeaterOrderCart.DataSource = dt;
            RepeaterOrderCart.DataBind();
            con.Close();
        }


      
        
        protected void BtnLogOut_Click1(object sender, EventArgs e)
        {
            Session.Abandon();
            Session["UserName"] = null;
            Response.Redirect("~/Product.aspx");
        }

        protected void BtnLogIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SignIn.aspx");
        }
    }
}