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
    public partial class SignUp : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSingUp_Click(object sender, EventArgs e)
        {
            if (isformvalid())
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyWebsiteDB"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into Tbl_Users(UserName,Password,Email,Name,UserType)Values(@1,@2,@3,@4,@5)", con);
                    cmd.Parameters.AddWithValue("@1", TxtUName.Text);
                    cmd.Parameters.AddWithValue("@2", TxtPass.Text);
                    cmd.Parameters.AddWithValue("@3", TxtMail.Text);
                    cmd.Parameters.AddWithValue("@4", TxtName.Text);
                    cmd.Parameters.AddWithValue("@5", "user");
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                  
                    Response.Write("<script> alert ('Kayıt İşlemi Başarılı'); </script>");
                    clr();
                    con.Close();
                    LblMsg.Text = "Kayıt İşlemi Başarılı";
                    LblMsg.ForeColor = System.Drawing.Color.Green;
                }
                Response.Redirect("~/SignIn.aspx");


            }
            else
            {
                Response.Write("<script> alert ('Kayıt İşlemi Başarısız'); </script>");
                LblMsg.Text = "Kayıt İşlemi Başarısız";
                LblMsg.ForeColor = System.Drawing.Color.Red;

            }

        }

        private bool isformvalid()
        {
            if (TxtUName.Text == "")
            {
                Response.Write("<script> alert ('Kullanıcı Adı Giriniz'); </script>");
                TxtUName.Focus();
                return false;
            }
            else if (TxtPass.Text != TxtCPass.Text)
            {
                Response.Write("<script> alert ('Şifreler Aynı Olmalı'); </script>");
                TxtPass.Focus();
                return false;
            }
            else if (TxtMail.Text == "")
            {
                Response.Write("<script> alert ('Email Adresi Giriniz'); </script>");
                TxtMail.Focus();
                return false;
            }
            else if (TxtName.Text == "")
            {
                Response.Write("<script> alert ('Ad Soyad Giriniz'); </script>");
                TxtName.Focus();
                return false;
            }
            return true;
        }
        private void clr()
        {
            TxtUName.Text = string.Empty;
            TxtPass.Text = string.Empty;
            TxtCPass.Text = string.Empty;
            TxtMail.Text = string.Empty;
            TxtName.Text = string.Empty;
            LblMsg.Text = string.Empty;

        }
    }
}