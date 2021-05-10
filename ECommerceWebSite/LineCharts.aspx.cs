using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ECommerceWebSite
{
    public partial class LineCharts : System.Web.UI.Page
    {
        public static String ConnectString = ConfigurationManager.ConnectionStrings["MyWebsiteDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void ShowData()
        {
            SqlConnection con = new SqlConnection(ConnectString);
           SqlCommand cmd = new SqlCommand("SELECT top (5) ProductName, Adet FROM SepetDetay S inner join Table_Product P on P.id=S.UrunId ORDER BY Adet DESC", con);
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr, LoadOption.OverwriteChanges);
                con.Close();
            }
            catch
            {

            }
            if (dt != null)
            {
                 
            }
            
        }
    }
}