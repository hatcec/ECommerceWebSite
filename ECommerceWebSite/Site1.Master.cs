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
    public partial class Site1 : System.Web.UI.MasterPage
    {
        public static String ConnectString = ConfigurationManager.ConnectionStrings["MyWebsiteDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            SqlConnection con = new SqlConnection(ConnectString);
            con.Open();
            if (Request.QueryString["CategoryName"] == null)
            {
                SqlCommand cmd = new SqlCommand("select * from Tbl_Category", con);
                cmd.ExecuteNonQuery();
                DataTable dtt = new DataTable();
                SqlDataAdapter sdaa = new SqlDataAdapter(cmd);
                sdaa.Fill(dtt);
                DataList.DataSource = dtt;
                DataList.DataBind();

                con.Close();
            }
            else
            {
                SqlCommand cmd = new SqlCommand("select * from Tbl_Category where CategoryName=@data", con);
                cmd.Parameters.AddWithValue("@data", Request.QueryString["category"].ToString());
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                DataList.DataSource = dt;
                DataList.DataBind();

                con.Close();
            }
            if (Request.QueryString["Name"] == null)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Tbl_Brands", con);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                DataList2.DataSource = dt;
                DataList2.DataBind();

                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Tbl_Brands where Name=@data", con);
                cmd.Parameters.AddWithValue("@data", Request.QueryString["brand"].ToString());
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                DataList2.DataSource = dt;
                DataList2.DataBind();

                con.Close();


            }

            if (Session["UserName"] != null)
            {
                //  LblSuccess.Text = "Giriş Yapıldı, Hoşgeldiniz" + Session["UserName"].ToString();
                btnSingUp.Visible = false;
                btnSingIn.Visible = false;
                BtnLogOut.Visible = true;
            }
            else
            {
                btnSingUp.Visible = true;
                btnSingIn.Visible = true;
                BtnLogOut.Visible = false;
                // Response.Redirect("~/Default.aspx");
            }
        }
              public class Sepet
        {
            public int id { get; set; }
        }

        protected void BtnLogOut_Click(object sender, EventArgs e)
        {
            Session["UserName"] = null;
            Session["UserID"] = null;
            Response.Redirect("~/SignIn.aspx");
        }

      
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string searchText = TxtSearch.Text.Trim();
            Response.Redirect("~/Search.aspx?ürün=" + searchText);
        }
    }


}

