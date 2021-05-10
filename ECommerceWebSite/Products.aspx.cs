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
    public partial class Products : System.Web.UI.Page
    {
        public static String ConnectString = ConfigurationManager.ConnectionStrings["MyWebsiteDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProductRepeater();

            }
          
        }

        private void BindProductRepeater()
        {
            SqlConnection con = new SqlConnection(ConnectString);
            con.Open();
            if (Request.QueryString["category"] != null)
            {

                int id =Convert.ToInt32 (Request.QueryString["category"]);

                SqlCommand cmd = new SqlCommand("select * from Table_Product P inner join Tbl_Category  C  on C.CategoryId=P.Category inner join Tbl_Brands B on B.BrandId=P.Brand where C.CategoryId=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                RepeaterProducts.DataSource = dt;
                RepeaterProducts.DataBind();
            }
           else  if (Request.QueryString["BrandId"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["BrandId"]);
                SqlCommand cmd = new SqlCommand("select * from Table_Product P inner join Tbl_Brands  B  on B.BrandId=P.Brand where B.BrandId=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                RepeaterProducts.DataSource = dt;
                RepeaterProducts.DataBind();
            }
            else if (Request.QueryString["ürün"] != null)
            {
                string data = Request.QueryString["ürün"].ToString();
                SqlCommand cmd = new SqlCommand("select * from Table_Product where (ProductName like '% @data %')or (id like '%@data%')", con);
                cmd.Parameters.AddWithValue("@data", data);

               // SqlDataAdapter sda = new SqlDataAdapter("select * from Table_Product where (ProductName like '%" + data + "%')or (id like '%" + data + "%')", con);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                RepeaterProducts.DataSource = dt;
                RepeaterProducts.DataBind();
                con.Close();
                RepeaterProducts.DataSource = dt;
                RepeaterProducts.DataBind();
            }
            else
            {
                SqlCommand cmd = new SqlCommand("select P.id, P.ProductName, P.ProductDescription,P.ProductImages,P.ProductPrice, C.CategoryName,B.Name from Table_Product P inner Join Tbl_Category C on C.CategoryId=P.Category inner join Tbl_Brands B on B.BrandId=P.Brand ", con);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                RepeaterProducts.DataSource = dt;
                RepeaterProducts.DataBind();
                con.Close();
            }
        }
        protected string GetActiveImgClass(int ItemIndex)//cs kısmında çağırdık-sepette kaç tane eleman var?
        {
            if (ItemIndex == 0)
            {
                return "active";
            }
            else
            {
                return "";
            }
        }

    }
}