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
    public partial class AdminUserEdit : System.Web.UI.Page
    {
        public static String ConnectString = ConfigurationManager.ConnectionStrings["MyWebsiteDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindUser();
            }



        }
        private void BindUser()
        {

            if (Request.QueryString["id"] != null && Session["AdminName"] != null)
            {
                SqlConnection con = new SqlConnection(ConnectString);
                con.Open();
                int ui = Convert.ToInt32(Request.QueryString["id"]);
                SqlCommand cmd = new SqlCommand("select * from Tbl_Users where Uid=@ui", con);
                cmd.Parameters.AddWithValue("@ui", ui);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TxtUserName.Text = reader[1].ToString();
                    TxtEmail.Text = reader[3].ToString();
                    TxtName.Text = reader[4].ToString();
                    DdlRole.SelectedValue = reader[5].ToString();
                }
                reader.Close();

            }
            else
            {
                Response.Redirect("~/AdminProducts.aspx");
            }

        }


        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            int uid = Convert.ToInt32(Request.QueryString["id"]);
            SqlConnection con = new SqlConnection(ConnectString);
            con.Open();
            SqlCommand cmd = new SqlCommand("update Tbl_Users set UserName=@user, Email=@Email, Name=@name, UserType=@USerType where Uid=@uid ", con);
            cmd.Parameters.AddWithValue("@uid", uid);
            cmd.Parameters.AddWithValue("@user", TxtUserName.Text);
            cmd.Parameters.AddWithValue("@Email", TxtEmail.Text);
            cmd.Parameters.AddWithValue("@name", TxtName.Text);
            cmd.Parameters.AddWithValue("@USerType", DdlRole.SelectedValue.ToString());
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("~/AdminProducts.aspx");
        }

        protected void BtnDel_Click(object sender, EventArgs e)
        {
            int uid = Convert.ToInt32(Request.QueryString["id"]);
            SqlConnection con = new SqlConnection(ConnectString);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Tbl_Users where Uid=@id ", con);
            cmd.Parameters.AddWithValue("@id", uid);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("~/AdminProducts.aspx");
        }

        protected void BtnCanCEl_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminUserList.aspx");
        }
    }
}