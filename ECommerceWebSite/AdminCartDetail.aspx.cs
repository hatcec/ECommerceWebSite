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
    public partial class AdminCartDetail : System.Web.UI.Page
    {
        public static String ConnectString = ConfigurationManager.ConnectionStrings["MyWebsiteDB"].ConnectionString;
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
          
                if (Request.QueryString["id"] != null)
                {
                    if (!IsPostBack)
                    {
                        BindCartDetail();
                    }
                }
                else
                {
                    Response.Redirect("~/OrderList.aspx");
                }
         
            
        }
        private void BindCartDetail()
        {
            id = Convert.ToInt32(Request.QueryString["id"].ToString());
            SqlConnection con = new SqlConnection(ConnectString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select S.id, SD.Id, P.ProductName, SD.Fiyat, SD.Adet from  Sepet S inner Join  SepetDetay SD on SD.SepetId=S.id inner join  Table_Product P on P.id=SD.UrunId where S.id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            RepeaterCartDetail.DataSource = dt;
            RepeaterCartDetail.DataBind();
            con.Close();
        }
    }
}