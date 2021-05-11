using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ECommerceWebSite
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["UNAME"] != null && Request.Cookies["UPASS"] != null)
                {
                    TxtPass.Text = Request.Cookies["UNAME"].Value;
                    TxtPass.Text = Request.Cookies["UPASS"].Value;
                    CheckBox1.Checked = true;

                }
            }
        }

        protected void BtnSingUp_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyWebsiteDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Tbl_Users WHERE UserName=@UserName and Password=@Pass and UserType='user'", con);
                cmd.Parameters.AddWithValue("@UserName", TxtUserName.Text);
                cmd.Parameters.AddWithValue("@Pass", TxtPass.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    if (CheckBox1.Checked)
                    {
                        Response.Cookies["UNAME"].Value = TxtUserName.Text;
                        Response.Cookies["UPASS"].Value = TxtPass.Text;
                        Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(10);
                        Response.Cookies["UPASS"].Expires = DateTime.Now.AddDays(10);
                    }
                    else
                    {
                        Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["UPASS"].Expires = DateTime.Now.AddDays(-1);
                    }
                    Session["UserName"] = TxtUserName.Text;
                    string UserID1 = dt.Rows[0][0].ToString();
                    Session["UserID"] = UserID1;
                    string UType;
                    UType = dt.Rows[0][5].ToString().Trim();
                    if (UType == "user")
                    {
                        Session["UserName"] = TxtUserName.Text;
                        Response.Redirect("~/Products.aspx");
                    }

                }
                else
                {
                    LblError.Text = "Geçersiz Kullanıcı Adı/Şifre";
                }
            }

        }
        protected void BtnADminSignIn_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyWebsiteDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Tbl_Users WHERE UserName=@UserName and Password=@Pass and UserType='admin'", con);
                cmd.Parameters.AddWithValue("@UserName", TxtUserName.Text);
                cmd.Parameters.AddWithValue("@Pass", TxtPass.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    if (CheckBox1.Checked)
                    {
                        Response.Cookies["UNAME"].Value = TxtUserName.Text;
                        Response.Cookies["UPASS"].Value = TxtPass.Text;
                        Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(10);
                        Response.Cookies["UPASS"].Expires = DateTime.Now.AddDays(10);
                    }
                    else
                    {
                        Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["UPASS"].Expires = DateTime.Now.AddDays(-1);
                    }
                    Session["AdminName"] = TxtUserName.Text;
                    string UserID1 = dt.Rows[0][0].ToString();
                    Session["AdminID"] = UserID1;

                    string UType;
                    UType = dt.Rows[0][5].ToString().Trim();

                    if (UType == "admin")
                    {
                        Session["AdminName"] = TxtUserName.Text;
                        Response.Redirect("~/AdminChart.aspx");
                    }


                }
                else
                {
                    LblError.Text = "Geçersiz Kullanıcı Adı/Şifre";
                }

                con.Close();
            }
        }

    }
}