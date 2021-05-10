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
    public partial class AdminUserList : System.Web.UI.Page
    {
        public static String ConnectString = ConfigurationManager.ConnectionStrings["MyWebsiteDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            
                SqlConnection con = new SqlConnection(ConnectString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select *  from Tbl_Users", con);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                RepeaterAdminUser.DataSource = dt;
                RepeaterAdminUser.DataBind();
                con.Close();
           
           
        }
      
    }
}