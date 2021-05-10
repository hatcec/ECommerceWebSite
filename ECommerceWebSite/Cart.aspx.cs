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
    public partial class Cart : System.Web.UI.Page
    {
        public static String ConnectString = ConfigurationManager.ConnectionStrings["MyWebsiteDB"].ConnectionString;
        int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                if (!IsPostBack)
                {
                    BindProductCart();
                }
            }
        }

        public class Sepet
        {
            public int id { get; set; }
            public decimal sepettutarı { get; set; }
            public int OlustumaTarihi { get; set; }
            public int KullaniciId { get; set; }
            public Boolean Durum { get; set; }
           
        }
        public class Product
        {
            public int id { get; set; }
            public string ProductName { get; set; }
            public string ProductDescription { get; set; }
            public decimal ProductPrice { get; set; }
            public int ProductQuantity { get; set; }
            public string ProductImages { get; set; }
            public int Category { get; set; }
            public int SubCategory { get; set; }
            public int Brand { get; set; }
        }

        public class SepetDetay
        {
            public int Id { get; set; }
            public int sepetid { get; set; }
            public decimal ürünid { get; set; }
            public decimal fiyat { get; set; }
            public int adet { get; set; }
        }
        private void BindProductCart()
        {
            SepetDetay sepetDetay = new SepetDetay();
            Sepet sepet = new Sepet();
            Product product = new Product();
            SqlConnection con = new SqlConnection(ConnectString);
            con.Open();
            SqlCommand command = new SqlCommand("select * from Sepet where KullaniciId=@ui and Durum=@d", con);
            command.Parameters.AddWithValue("@ui", Convert.ToInt32(Session["UserID"]));
            command.Parameters.AddWithValue("@d", false);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                sepet.id = Convert.ToInt32(reader[0]);
                sepet.sepettutarı = Convert.ToDecimal(reader[1]);
                sepet.Durum = Convert.ToBoolean(reader[4]);
                count++;
            }
            reader.Close();
          
            SqlCommand komut2 = new SqlCommand("select  P.id, P.ProductImages, P.ProductName, P.ProductPrice  from SepetDetay S inner join Table_Product P on P.id=S.UrunId inner join Sepet Sp on Sp.id=S.SepetId where S.SepetId=@sepetId", con);
            komut2.Parameters.AddWithValue("@sepetId", sepet.id);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(komut2);
            sda.Fill(dt);
       
            CarTotalSpan.InnerText = sepet.sepettutarı.ToString();
            RepeaterProductCart.DataSource = dt;
            RepeaterProductCart.DataBind();
                con.Close();
            
        }
        protected void BtnRemoveCard_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            Sepet sepet = new Sepet();
            Button btn = (Button)(sender);
            string pid = btn.CommandArgument;
            SepetDetay sepetDetay = new SepetDetay();
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
            CarTotalSpan.InnerText = sepet.sepettutarı.ToString();
            reader.Close();
            SqlCommand cmd1 = new SqlCommand("select * from SepetDetay where UrunId=@urunid", con);//ürün kaç tane kontrol için
            cmd1.Parameters.AddWithValue("@urunid", product.id);
            SqlDataReader dataReader = cmd1.ExecuteReader();
            if (dataReader.Read())
            {
                sepetDetay.ürünid = Convert.ToInt32(dataReader[2]);
                sepetDetay.adet = Convert.ToInt32(dataReader[4]);
            }
            dataReader.Close();
            SqlCommand komut = new SqlCommand("select * from Table_Product where id = @id", con);
            komut.Parameters.AddWithValue("@id", pid);
            SqlDataReader rdr = komut.ExecuteReader();
            if (rdr.Read())
            {
                product.id = Convert.ToInt32(rdr[0]);
                product.ProductName = rdr[1].ToString();
                product.ProductDescription = rdr[2].ToString();
                product.ProductPrice = Convert.ToInt32(rdr[3]);
                product.ProductImages = rdr[4].ToString();
                product.Category = Convert.ToInt32(rdr[5]);
                product.Brand = Convert.ToInt32(rdr[6]);
            }
            rdr.Close();
            decimal ara =sepet.sepettutarı- (product.ProductPrice * sepetDetay.adet);
            SqlCommand sqlcommand = new SqlCommand("update Sepet set SepetTutari=@ürünyeni where KullaniciId=@ui and Durum=@d", con);
            sqlcommand.Parameters.AddWithValue("@ui", Convert.ToInt32(Session["UserID"]));
            sqlcommand.Parameters.AddWithValue("@d", false);
            sqlcommand.Parameters.AddWithValue("@ürünyeni", ara);
            sqlcommand.ExecuteNonQuery();
           
            SqlCommand cmd = new SqlCommand("delete  from SepetDetay where UrunId=@ürünid and SepetId=@sepetid", con);
            cmd.Parameters.AddWithValue("@ürünid", pid);
            cmd.Parameters.AddWithValue("@sepetid", sepet.id);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("~/Products.aspx");
        }

        protected void BtnBuy_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            if (Session["UserName"] == null)
            {
                Response.Redirect("~/SignIn.aspx");
            }
            else
            {
                Sepet sepet = new Sepet();
                Product product = new Product();
                SqlConnection con = new SqlConnection(ConnectString);
                con.Open();
                SqlCommand command = new SqlCommand("select * from Sepet where KullaniciId=@ui and Durum=@durum", con);
                command.Parameters.AddWithValue("@ui", Convert.ToInt32(Session["UserID"]));
                command.Parameters.AddWithValue("@durum", false);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    sepet.id = Convert.ToInt32(reader[0]);
                    sepet.sepettutarı = Convert.ToDecimal(reader[1]);
                }

                reader.Close();
                SqlCommand sqlCommand = new SqlCommand("insert into Siparis2 (SepetId, KullaniciId,SiparisTarihi,SiparisTutari,Durum) values (@SepetId, @KullaniciId,@SiparisTarihi,@SiparisTutari,@durum)", con);
                sqlCommand.Parameters.AddWithValue("@SepetId", sepet.id);
                sqlCommand.Parameters.AddWithValue("@KullaniciId", Convert.ToInt32(Session["UserID"]));
                sqlCommand.Parameters.AddWithValue("@SiparisTarihi", DateTime.Now);
                sqlCommand.Parameters.AddWithValue("@SiparisTutari", sepet.sepettutarı);
                sqlCommand.Parameters.AddWithValue("@durum", false);
                sqlCommand.ExecuteNonQuery();
                
                con.Close();

                Response.Redirect("~/Buy.aspx");
            }
        }
    }
}