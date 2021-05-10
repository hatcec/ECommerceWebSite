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
    public partial class ProductEdit : System.Web.UI.Page
    {
        public static String ConnectString = ConfigurationManager.ConnectionStrings["MyWebsiteDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
           
                BindBrand();
                BindCategory();
                if (!IsPostBack)
                {
                    BindProduct();
                }

          


        }
        private void BindProduct()
        {

            Product product = new Product();
            SqlConnection con = new SqlConnection(ConnectString);
            con.Open();
            if (Request.QueryString["id"] != null)
            {
                int pid = Convert.ToInt32(Request.QueryString["id"]);
                SqlCommand cmd = new SqlCommand("select * from Table_Product where id=@id", con);
                cmd.Parameters.AddWithValue("@id", pid);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TxtProduceName.Text = reader[1].ToString();
                    TxtDescription.Text = reader[2].ToString();
                    TxtPrice.Text = (Convert.ToDecimal(reader[3])).ToString();
                    TxtImage.Text = reader[4].ToString();
                    DdlCategory.SelectedValue = reader[5].ToString();
                    DdlBrand.SelectedValue = reader[6].ToString();
                }
                reader.Close();

            }
            else
            {
                Response.Redirect("~/AdminProducts.aspx");
            }
        }
        private void BindCategory()
        {
            Product product = new Product();
            using (SqlConnection con = new SqlConnection(ConnectString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("Select * from Tbl_Category", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    DdlCategory.DataSource = dt;
                    DdlCategory.DataTextField = "CategoryName";
                    DdlCategory.DataValueField = "CategoryId";
                    DdlCategory.DataBind();


                }
            }
        }
        private void BindBrand()
        {
            using (SqlConnection con = new SqlConnection(ConnectString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Tbl_Brands", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    DdlBrand.DataSource = dt;
                    DdlBrand.DataTextField = "Name";
                    DdlBrand.DataValueField = "BrandId";
                    DdlBrand.DataBind();


                }
            }
        }
        public class Product
        {
            public int Id { get; set; }
            public string ProductName { get; set; }
            public string ProductDescription { get; set; }
            public decimal ProductPrice { get; set; }
            public int ProductQuantity { get; set; }
            public string ProductImages { get; set; }
            public int Category { get; set; }
            public int SubCategory { get; set; }
            public int Brand { get; set; }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            int pid = Convert.ToInt32(Request.QueryString["id"]);
            if (FuImg01.HasFile)
            {
                string a = Class1.GetRandom(10).ToString();
                FuImg01.SaveAs(Request.PhysicalApplicationPath + "./Images/" + a + FuImg01.FileName.ToString());
                TxtImage.Text = "./Images/" + a + FuImg01.FileName.ToString();
            }


            SqlConnection con = new SqlConnection(ConnectString);
            con.Open();
            SqlCommand cmd = new SqlCommand("update Table_Product set ProductName=@ProductName, ProductDescription = @Description,ProductPrice = @Price,ProductImages = @Image ,Category = @Cat,Brand = @Brand  where id=@id ", con);
            cmd.Parameters.AddWithValue("@id", pid);
            cmd.Parameters.AddWithValue("@ProductName", TxtProduceName.Text);
            cmd.Parameters.AddWithValue("@Description", TxtDescription.Text);
            cmd.Parameters.AddWithValue("@Price", TxtPrice.Text);
            cmd.Parameters.AddWithValue("@Image", TxtImage.Text);
            cmd.Parameters.AddWithValue("@Cat", DdlCategory.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@Brand", DdlBrand.SelectedValue.ToString());
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("~/AdminProducts.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            int pid = Convert.ToInt32(Request.QueryString["id"]);
            SqlConnection con = new SqlConnection(ConnectString);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Table_Product where id=@id ", con);
            cmd.Parameters.AddWithValue("@id", pid);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("~/AdminProducts.aspx");
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminProducts.aspx");
        }
    }
}