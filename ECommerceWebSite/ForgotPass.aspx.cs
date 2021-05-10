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





                    //    //send reset Link via email
                    //    String ToEmailAdress = dt.Rows[0][3].ToString();
                    //    String UserName = dt.Rows[0][1].ToString();
                    //    String EmailBody ="Merhaba, "+UserName+ "<br/><b/> Linke Tıklayarak Şifrenizi Sıfırlayınız<b/>https://localhost:44304/NewPassword.aspx?Id="+mGUID;
                    //    MailMessage PassMail = new MailMessage("htccnbz06@gmail.com", ToEmailAdress);
                    //    PassMail.Body = EmailBody;
                    //    PassMail.IsBodyHtml = true;
                    //    PassMail.Subject = "Şifre Sıfırlama";
                    //    using(SmtpClient client=new SmtpClient())
                    //    {
                    //        client.EnableSsl = true;
                    //        client.UseDefaultCredentials = false;
                    //        client.Credentials = new NetworkCredential("htccnbz06@gmail.com", "aditi@12345");
                    //        client.Host = "smtp.gmail.com";
                    //        client.Port = 587;
                    //        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    //        client.Send(PassMail);
                    //    }




                    //    //SmtpClient SMTP = new SmtpClient("smtp.gmail.com",587);
                    //    //SMTP.Credentials = new NetworkCredential()
                    //    //{
                    //    //    UserName = "EmailAdres@gmail.com",
                    //    //    Password = "yeniSifre"
                    //    //};
                    //    //SMTP.EnableSsl = true;
                    //    //SMTP.Send(PassMail);



                    //    //---------------------

                    //    LblResetPassMsg.Text = "Sıfırlama Linki Mail Adresinize Gönderildi, Lütfen Kontrol Ediniz";
                    //    LblResetPassMsg.ForeColor = System.Drawing.Color.Green;
                    //    TxtEmail.Text = string.Empty;
                    //}
                    //else
                    //{
                    //    LblResetPassMsg.Text = "birşeyler ters gitti.";
                    //    LblResetPassMsg.ForeColor = System.Drawing.Color.Red;
                    //    TxtEmail.Text = string.Empty;
                    //    TxtEmail.Focus();
                    //}
                }
            }
        }
    }
}

