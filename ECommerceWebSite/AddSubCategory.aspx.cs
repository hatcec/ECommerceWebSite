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
    public partial class AddSubCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMainCat();
                BindSubCategoryRepeater();
            }
        }

        private void BindSubCategoryRepeater()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyWebsiteDB"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select A.*, B.* from Tbl_SubCategory A inner join Tbl_Category B on B.CategoryId=A.MainCatID", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        RepeaterSubCat.DataSource = dt;
                        RepeaterSubCat.DataBind();
                    }
                }
            }
        }

        private void BindMainCat()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyWebsiteDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Tbl_Category", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    DdlMainCategoryID.DataSource = dt;
                    DdlMainCategoryID.DataTextField = "CategoryName";
                    DdlMainCategoryID.DataValueField = "CategoryId";
                    DdlMainCategoryID.DataBind();
                    DdlMainCategoryID.Items.Insert(0, new ListItem("-Seçiniz-", "0"));

                }
            }
        }

        protected void BtnCategoryAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyWebsiteDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into Tbl_SubCategory(SubCatName,MainCatID)Values('" + TxtSubCategoryName.Text + "','"+DdlMainCategoryID.SelectedItem.Value+"')", con);
                cmd.ExecuteNonQuery();
                Response.Write("<script> alert ('Alt Kategori Eklendi'); </script>");
                TxtSubCategoryName.Text = string.Empty;
                con.Close();
                //LblMsg.Text = "Kayıt İşlemi Başarılı";
                //LblMsg.ForeColor = System.Drawing.Color.Green;
                TxtSubCategoryName.Focus();
                DdlMainCategoryID.ClearSelection();
                DdlMainCategoryID.Items.FindByValue("0").Selected = true;
                //BindCategoryRepeater();
                BindMainCat();
                BindSubCategoryRepeater();
            }
        }
    }
}