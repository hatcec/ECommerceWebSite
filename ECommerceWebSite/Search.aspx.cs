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
    public partial class Search : System.Web.UI.Page
    {
        public static String ConnectString = ConfigurationManager.ConnectionStrings["MyWebsiteDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            BindProductRepeater();
        }
        private void BindProductRepeater()
        {
            SqlConnection con = new SqlConnection(ConnectString);
            con.Open();
         
             if (Request.QueryString["ürün"] != null)
            {
                string data = Request.QueryString["ürün"].ToString();

                SqlDataAdapter sda = new SqlDataAdapter("select * from Table_Product where (ProductName like '%" + data + "%')or (id like '%" + data + "%')", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                RepeaterProducts.DataSource = dt;
                RepeaterProducts.DataBind();
                con.Close();
                //SqlCommand cmd = new SqlCommand("select * from Table_Product P where P.ProductName=@id", con);
                //cmd.Parameters.AddWithValue("@id", data);
                //cmd.ExecuteNonQuery();
                //DataTable dt = new DataTable();
                //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //sda.Fill(dt);


                RepeaterProducts.DataSource = dt;

                RepeaterProducts.DataBind();
            }
            else
            {
                Response.Redirect("~/Products.aspx");
            }




        }
      
    }
}