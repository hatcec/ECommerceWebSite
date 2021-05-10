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
    public partial class NewPassword : System.Web.UI.Page
    {
        String GuIdValue;
        int Uid;
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyWebsiteDB"].ConnectionString))
            {

                GuIdValue = Request.QueryString["id"];
                if (GuIdValue != null)
                {
                    SqlCommand cmd = new SqlCommand("select * from ForgotPass where Id=@Id", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@Id", GuIdValue);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                    Uid = Convert.ToInt32(dt.Rows[0][1]);

                    if (dt.Rows.Count != 0)
                    {
                        Uid = Convert.ToInt32(dt.Rows[0][1]);
                    }
                    else
                    {
                        LblMsg.Text = "Bağlantınızın Süresi Doldu. Tekrar Deneyin";

                        LblMsg.ForeColor = System.Drawing.Color.Red;
                    }
                }

            


             else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
            if (!IsPostBack)
            {
                if (dt.Rows.Count != 0)
                {
                    TxTConfirmNewPass.Visible = true;
                    TxtNewPass.Visible = true;
                    LblNewPass.Visible = true;
                    Label1.Visible = true;
                    BtnREsetPass.Visible = true;
                }
                else
{
    LblMsg.Text = "tekrar deneyin";
    LblMsg.ForeColor = System.Drawing.Color.Red;
}
            }

        }

        protected void BtnREsetPass_Click(object sender, EventArgs e)
{
    if (TxtNewPass.Text != "" && TxTConfirmNewPass.Text != "" && TxtNewPass.Text == TxTConfirmNewPass.Text)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyWebsiteDB"].ConnectionString))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Update Tbl_Users set Password=@Pass where Uid=@Uid", con);
            cmd.Parameters.AddWithValue("@Pass", TxtNewPass.Text);
            cmd.Parameters.AddWithValue("@Uid", Uid);
            cmd.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand("delete from ForgotPass where Uid='" + Uid + "'", con);
            cmd2.ExecuteNonQuery();
            Response.Write("<script>alert('Şifre Yenilendi');</script>");
            Response.Redirect("~/SignIn.aspx");
        }
    }

}
    }
}