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
    public partial class AddBrand : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBrandRepeater();
            }
        }

        protected void BtnBrandAdd_Click(object sender, EventArgs e)
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyWebsiteDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into Tbl_Brands(Name)Values('" + TxtBrandName.Text + "')", con);
                cmd.ExecuteNonQuery();
                Response.Write("<script> alert ('Marka Eklendi'); </script>");
                TxtBrandName.Text = string.Empty;
                con.Close();
                //LblMsg.Text = "Kayıt İşlemi Başarılı";
                //LblMsg.ForeColor = System.Drawing.Color.Green;
                TxtBrandName.Focus();
                BindBrandRepeater();
            }
        }
        private void BindBrandRepeater()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyWebsiteDB"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select * from Tbl_Brands", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        RepeaterBrand.DataSource = dt;
                        RepeaterBrand.DataBind();
                    }
                }
            }
        }



   

        protected void BtnSil_Click1(object sender, EventArgs e)
        {
            Button btn = (Button)(sender);
            string BrandId = btn.CommandArgument;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyWebsiteDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete  from Tbl_Brands where BrandId=@id", con);
                cmd.Parameters.AddWithValue("@id", BrandId);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("~/AdminProducts.aspx");
            }
        }
    }
}