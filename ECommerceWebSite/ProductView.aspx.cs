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
    public partial class ProductView : System.Web.UI.Page
    {
        public static String ConnectString = ConfigurationManager.ConnectionStrings["MyWebsiteDB"].ConnectionString;
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                if (!IsPostBack)
                {
                    //sayfa ilk çalıştığında buradaki kod çalışacak
                    BindProductDetail();
                }
            }
            else
            {
                Response.Redirect("~/Products.aspx");
            }
        }

        private void BindProductDetail()
        {
            id = Convert.ToInt32(Request.QueryString["id"].ToString());
            SqlConnection con = new SqlConnection(ConnectString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Table_Product where id=" + id + "", con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            RepeaterProductDetails.DataSource = dt;
            RepeaterProductDetails.DataBind();
            con.Close();
        }
        protected void BtnAddCard_Click(object sender, EventArgs e)
        {
            if (Session["UserName"] == null && Session["UserID"] == null)
            {
                Response.Redirect("~/SignIn.aspx");
            }
            else
            {
                id = Convert.ToInt32(Request.QueryString["id"]);//product id aldık
                Product product = new Product();
                Sepet sepet = new Sepet();
                SepetDetay sepetDetay = new SepetDetay();
                SqlConnection con = new SqlConnection(ConnectString);
                con.Open();
                SqlCommand komut = new SqlCommand("select * from Table_Product where id = @id", con);
                komut.Parameters.AddWithValue("@id", id);
                SqlDataReader rdr = komut.ExecuteReader();
                if (rdr.Read())
                {
                    product.Id = Convert.ToInt32(rdr[0]);
                    product.ProductName = rdr[1].ToString();
                    product.ProductDescription = rdr[2].ToString();
                    product.ProductPrice = Convert.ToInt32(rdr[3]);
                    product.ProductImages = rdr[4].ToString();
                    product.Category = Convert.ToInt32(rdr[5]);
                    product.Brand = Convert.ToInt32(rdr[6]);
                }
                rdr.Close();
                int count = 0;
                SqlCommand cmd1 = new SqlCommand("select * from Sepet where KullaniciId=@userid", con);
                cmd1.Parameters.AddWithValue("@userid", Convert.ToInt32(Session["UserID"]));
                SqlDataReader reader = cmd1.ExecuteReader();
                while (reader.Read())
                {
                    sepet.Durum = Convert.ToBoolean(reader[4]);
                    count++;
                }
                reader.Close();
                if (count == 0 || sepet.Durum==true)
                {
                    SqlCommand sqlCommand = new SqlCommand("insert into Sepet (SepetTutari,OlusturmaTarihi,KullaniciId,Durum) values(@tutar,@tarih,@userid,@d)", con);
                    sqlCommand.Parameters.AddWithValue("@tutar", 0);
                    sqlCommand.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                    sqlCommand.Parameters.AddWithValue("@userid", Convert.ToInt32(Session["UserID"]));
                    sqlCommand.Parameters.AddWithValue("@d", false);
                    sqlCommand.ExecuteNonQuery();
                }
              
                    SqlCommand sql = new SqlCommand("select * from Sepet where KullaniciId=@ui and Durum=@d", con);
                    sql.Parameters.AddWithValue("@ui", Convert.ToInt32(Session["UserID"]));
                    sql.Parameters.AddWithValue("@d",false);
                    SqlDataReader reader1 = sql.ExecuteReader();
                    if (reader1.Read())
                    {
                        sepet.id = Convert.ToInt32(reader1[0]);
                        sepet.SepetTutari = Convert.ToDecimal(reader1[1]);
                    }
                    reader1.Close();
               
                SqlCommand sqlcommand = new SqlCommand("update Sepet set SepetTutari=@ürünyeni where KullaniciId=@ui  and Durum=@d", con);
                sqlcommand.Parameters.AddWithValue("@ui", Convert.ToInt32(Session["UserID"]));
                sqlcommand.Parameters.AddWithValue("@d", false);
                sqlcommand.Parameters.AddWithValue("@ürünyeni", product.ProductPrice + sepet.SepetTutari);
                //sqlcommand.ExecuteNonQuery();
                SqlDataReader reader2 = sqlcommand.ExecuteReader();
                if (reader2.Read())
                {
                    sepet.id = Convert.ToInt32(reader2[0]);
                }
                reader2.Close();
                sqlcommand.ExecuteNonQuery();

                int sip = sepet.id;
                SqlCommand cmd123 = new SqlCommand("select * from SepetDetay where UrunId=@urunid and SepetId=@sepetid", con);//ürrün kaç tane kontrol için
                cmd123.Parameters.AddWithValue("@urunid", product.Id);
                cmd123.Parameters.AddWithValue("@sepetid", sepet.id);
                SqlDataReader dataReader = cmd123.ExecuteReader();
                if (dataReader.Read())
                {
                    sepetDetay.UrunId = Convert.ToInt32(dataReader[2]);
                    sepetDetay.Adet = Convert.ToInt32(dataReader[4]);
                }
                dataReader.Close();
                if (sepetDetay.UrunId != product.Id)
                {
                    SqlCommand sqlcommand1 = new SqlCommand("insert into SepetDetay (SepetId,UrunId,Fiyat,Adet) values (@SepetId, @UrunId, @Fiyat, 1)", con);
                    sqlcommand1.Parameters.AddWithValue("@SepetId", sip);
                    sqlcommand1.Parameters.AddWithValue("@UrunId", product.Id);
                    sqlcommand1.Parameters.AddWithValue("@fiyat", product.ProductPrice);
                    sqlcommand1.ExecuteNonQuery();

                }
                else
                {
                    SqlCommand sqlcommand2 = new SqlCommand("update SepetDetay  set Fiyat=@ürünfiyat, Adet=@adet where SepetId=@sepetid  ", con);
                    sqlcommand2.Parameters.AddWithValue("@ürünfiyat", product.ProductPrice * sepetDetay.Adet);
                    sqlcommand2.Parameters.AddWithValue("@adet", sepetDetay.Adet + 1);
                    sqlcommand2.Parameters.AddWithValue("@sepetid", sepet.id);
                    sqlcommand2.ExecuteNonQuery();
                }







                con.Close();
                Response.Redirect("~/Cart.aspx");

            }

        }
        public class SepetDetay
        {
            public int Id { get; set; }
            public int SepetId { get; set; }
            public int UrunId { get; set; }
            public decimal Fiyat { get; set; }
            public int Adet { get; set; }
        }
        public class Sepet
        {
            public int id { get; set; }
            public decimal SepetTutari { get; set; }
            public int OlustumaTarihi { get; set; }
            public int KullaniciId { get; set; }
            public Boolean Durum { get; set; }
        }

        public class Product
        {
            public int Id { get; set; }
            public string ProductName { get; set; }
            public string ProductDescription { get; set; }
            public decimal ProductPrice { get; set; }
            public int ProductQuantity { get; set; }
            public string ProductImages { get; set; }
            public int Category { get; set; }
            public int SubCategory { get; set; }
            public int Brand { get; set; }
        }

        protected string GetActiveImgClass(int ItemIndex)//cs kısmında çağırdık-sepette kaç tane eleman var?
        {
            if (ItemIndex == 0)
            {
                return "active";
            }
            else
            {
                return "";
            }
        }


    }
}