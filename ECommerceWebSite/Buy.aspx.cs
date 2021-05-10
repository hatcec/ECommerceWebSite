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
    
    public partial class Buy : System.Web.UI.Page
    {
        public static String ConnectString = ConfigurationManager.ConnectionStrings["MyWebsiteDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            BindProductCart();
        }
        private void BindProductCart()
        {
            Sepet sepet = new Sepet();
            SqlConnection con = new SqlConnection(ConnectString);
            con.Open();
            SqlCommand command = new SqlCommand("select * from Sepet where KullaniciId=@ui and Durum=@d", con);
            command.Parameters.AddWithValue("@ui", Convert.ToInt32(Session["UserID"]));
            command.Parameters.AddWithValue("@d", false);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                sepet.id = Convert.ToInt32(reader[0]);
                sepet.sepettutarı = Convert.ToDecimal(reader[1]);
            }
            reader.Close();
            SqlCommand komut2 = new SqlCommand("select  P.id, P.ProductImages, P.ProductName, P.ProductPrice  from SepetDetay S inner join Table_Product P on S.UrunId=P.id inner join Sepet Sp on Sp.id=S.SepetId where S.SepetId=@sepetId", con);
            komut2.Parameters.AddWithValue("@sepetId", sepet.id);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(komut2);
            sda.Fill(dt);
            con.Close();
            Label6.Text = sepet.sepettutarı.ToString();
            RepeaterProductCart.DataSource = dt;
            RepeaterProductCart.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Siparis2 siparis2 = new Siparis2();
            Sepet sepet = new Sepet();

            SqlConnection con = new SqlConnection(ConnectString);
            con.Open();
            SqlCommand komut1 = new SqlCommand("select * from Sepet where KullaniciId=@ui and Durum=@d", con);
            komut1.Parameters.AddWithValue("@ui", Convert.ToInt32(Session["UserID"]));
            komut1.Parameters.AddWithValue("@d", false);
            SqlDataReader sqlDataReader = komut1.ExecuteReader();
            if (sqlDataReader.Read())
            {
                sepet.id = Convert.ToInt32(sqlDataReader[0]);
            }
            sqlDataReader.Close();
            SqlCommand komut3 = new SqlCommand("select * from Siparis2 where SepetId=@sepetid and Durum=@d " , con);
            komut3.Parameters.AddWithValue("@sepetid",sepet.id);
            komut3.Parameters.AddWithValue("@d", false);
            SqlDataReader reader = komut3.ExecuteReader();
            if (reader.Read())
            {
                siparis2.SiparisTutari = Convert.ToDecimal(reader[4]);
                siparis2.siparisid = Convert.ToInt32(reader[0]);
            }
            reader.Close();
        
                SqlCommand komut2 = new SqlCommand("insert into Odeme (SiparisId,KullaniciId,KartNo,Cvv,Tutar,Durum) values (@SiparisId,@KullaniciId,@KartNo,@Cvv,@Tutar,@Durum) ", con);
                komut2.Parameters.AddWithValue("@SiparisId",siparis2.siparisid );
                komut2.Parameters.AddWithValue("@KullaniciId", Convert.ToInt32(Session["UserID"]));
                komut2.Parameters.AddWithValue("@KartNo", Convert.ToInt32(TxtCartNo.Text));
                komut2.Parameters.AddWithValue("@Cvv", Convert.ToInt32(TxtCvc.Text));
                komut2.Parameters.AddWithValue("@Tutar", siparis2.SiparisTutari);
                komut2.Parameters.AddWithValue("@Durum", true);
                komut2.ExecuteNonQuery();
            SqlCommand sql = new SqlCommand("update Siparis2 set Durum=@durum where Id=@siparisId", con);
            sql.Parameters.AddWithValue("@durum", true);
            sql.Parameters.AddWithValue("@siparisId", siparis2.siparisid);
            sql.ExecuteNonQuery();
            SqlCommand sql2 = new SqlCommand("update Sepet set Durum=@durum where KullaniciId=@ui", con);
            sql2.Parameters.AddWithValue("@durum", true);
            sql2.Parameters.AddWithValue("@ui", Convert.ToInt32(Session["UserID"]));
            sql2.ExecuteNonQuery();
          
            con.Close();

            Response.Write("<script> alert ('Ödeme İşlemi Başarı ile TamamLanmıştır'); </script>");



            Response.Redirect("~/Products.aspx");
        }
      
       public class Siparis2
        {
            public int siparisid { get; set; }
            public decimal SiparisTutari { get; set; }
        }
        public class Sepet
        {
            public int id { get; set; }
            public decimal sepettutarı { get; set; }
            public Boolean durum { get; set; }
        }

    }
}