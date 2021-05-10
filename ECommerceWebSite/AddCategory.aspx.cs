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
    public partial class AddCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCategoryRepeater();
            }
            
        }

    

        protected void BtnCategoryAdd_Click(object sender, EventArgs e)
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyWebsiteDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into Tbl_Category(CategoryName)Values('" + TxtCategoryName.Text + "')", con);
                cmd.ExecuteNonQuery();
                Response.Write("<script> alert ('Kategori Eklendi'); </script>");
                TxtCategoryName.Text = string.Empty;
                con.Close();
                //LblMsg.Text = "Kayıt İşlemi Başarılı";
                //LblMsg.ForeColor = System.Drawing.Color.Green;
                TxtCategoryName.Focus();
                BindCategoryRepeater();
                Session["CategoryName"] = TxtCategoryName.Text;
            }
        }
        private void BindCategoryRepeater()
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyWebsiteDB"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select * from Tbl_Category", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        RepeaterCategory.DataSource = dt;
                        RepeaterCategory.DataBind();
                    }
                }
            }
        }
       


        protected void BtnSil_Click1(object sender, EventArgs e)
        {
            Button btn = (Button)(sender);
            string Catid = btn.CommandArgument;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyWebsiteDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete  from Tbl_Category where CategoryId=@id", con);
                cmd.Parameters.AddWithValue("@id", Catid);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("~/AdminProducts.aspx");
            }
        }
    }
}