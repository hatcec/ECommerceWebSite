using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

using System.Web.Services;
using System.Data;
namespace ECommerceWebSite
{
    public partial class AdminChart : System.Web.UI.Page
    {

        [WebMethod]
        public static List<object> GetChartData()
        {

            string query = "select Gün ,tutar from Table_chart";
            List<object> chartdata = new List<object>();
            chartdata.Add(new object[]
           {
                "Gün","tutar"
           });
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyWebsiteDB"].ConnectionString))
            {
              

                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                                chartdata.Add(new object[]
                            {
                               
                                 reader["Gün"],reader["tutar"]
                            });
                        }
                        reader.Close();
                    }
                    con.Close();
                    return chartdata;
                }
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminUser"] == null)
            {
                Response.Redirect("~/SignIn.aspx");
            }
        }
    }
}