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
    public partial class AdminSearch : System.Web.UI.Page
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
                //burada olmadı!!
                SqlDataAdapter sda = new SqlDataAdapter("select P.id, P.ProductName, P.ProductDescription,P.ProductImages,P.ProductPrice, C.CategoryName,B.Name from Table_Product P inner Join Tbl_Category C on C.CategoryId=P.Category inner join Tbl_Brands B on B.BrandId=P.Brand where (ProductName like '%" + data + "%')", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                RepeaterProductCart.DataSource = dt;
                RepeaterProductCart.DataBind();
                con.Close();
               

            }
            else
            {
                Response.Redirect("~/AdminProducts.aspx");
            }
        }

      
    }
}