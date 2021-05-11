using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
namespace ECommerceWebSite
{
    public partial class ForgotPass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string searchText = TxtSearch.Text.Trim();
            Response.Redirect("~/Search.aspx?ürün=" + searchText);
        }
        protected void BtnREsetPass_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyWebsiteDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Tbl_Users WHERE Email=@Email", con);
                cmd.Parameters.AddWithValue("@Email", TxtEmail.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    string mGUID = Guid.NewGuid().ToString();
                    int Uid = Convert.ToInt32(dt.Rows[0][0]);
                    SqlCommand cmd1 = new SqlCommand("Insert into ForgotPass(Id,Uid,RequestDateTime) values('" + mGUID + "','" + Uid + "',GETDATE())", con);
                    cmd1.ExecuteNonQuery();
                    String ToEmailAddress = dt.Rows[0][3].ToString();
                    String Username = dt.Rows[0][1].ToString();
                    String EmailBody = "Hi ," + Username + ",<br/><br/>Click the link below to reset your password<br/> <br/> https://localhost:44304/NewPassword.aspx?Id=" + mGUID;
                    try
                     {
                        SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                        client.EnableSsl = true;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential("htccnbz06@gmail.com", "20022019Hatice.1");
                        MailMessage PassMail = new MailMessage("htccnbz06@gmail.com", ToEmailAddress);
       
                        PassMail.Subject = "şifre sıfırlama";
                        PassMail.Body = EmailBody;
                        client.Send(PassMail);
                        LblResetPassMsg.Text = "Link Başarılı Şekilde MAil Adresinize Gönderildi";
                        LblResetPassMsg.ForeColor = System.Drawing.Color.Green;
                        TxtEmail.Text = string.Empty;
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Link Gönderilemedi" + ex.Message);
                        TxtEmail.Text = string.Empty;
                        TxtEmail.Focus();
                    }





                   
                }
            }
        }
    }
}

