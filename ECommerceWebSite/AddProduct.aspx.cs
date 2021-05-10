using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
namespace ECommerceWebSite
{
    public partial class AddProduct : System.Web.UI.Page
    {
        public static String ConnectString = ConfigurationManager.ConnectionStrings["MyWebsiteDB"].ConnectionString;
        string a, b;
        SqlConnection con = new SqlConnection(ConnectString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //sayfa ilk çalıştığında buradaki kod çalışacak
                BindBrand();
                BindCategory();
            }
        }
        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            con.Open();           
            a = Class1.GetRandom(10).ToString();
            FuImg01.SaveAs(Request.PhysicalApplicationPath + "./Images/" +a+ FuImg01.FileName.ToString());
            b = "./Images/" + a + FuImg01.FileName.ToString();
            SqlCommand cmd = new SqlCommand("insert into Table_Product values('" +TxtProduceName.Text + "','" + TxtDescription.Text + "','" + TxtPrice.Text + "','" + b.ToString() + "','" + DdlCategory.SelectedValue.ToString() + "','" + DdlBrand.SelectedValue.ToString() + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("~/AdminProducts.aspx");
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
                    DdlBrand.Items.Insert(0, new ListItem("-Select-", "0"));

                }
            }
        }
        private void BindCategory()
        {
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
                    DdlCategory.Items.Insert(0, new ListItem("-Select-", "0"));

                }
            }
        }

       
      
    }
}