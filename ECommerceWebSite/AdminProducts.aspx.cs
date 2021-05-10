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
    public partial class AdminProducts : System.Web.UI.Page
    {
        public static String ConnectString = ConfigurationManager.ConnectionStrings["MyWebsiteDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            
                BindProductCart();
         
        }
        private void BindProductCart()
        {
            SqlConnection con = new SqlConnection(ConnectString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select P.id, P.ProductName, P.ProductDescription,P.ProductImages,P.ProductPrice, C.CategoryName,B.Name from Table_Product P inner Join Tbl_Category C on C.CategoryId=P.Category inner join Tbl_Brands B on B.BrandId=P.Brand ", con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            RepeaterProductCart.DataSource = dt;
            RepeaterProductCart.DataBind();
            con.Close();
        }
     

        
    }
}