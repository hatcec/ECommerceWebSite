using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;

namespace ECommerceWebSite
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    /// 
  //  [System.Web.Script.Services.ScriptService()]
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        public class Durum
        {
            public string Durumu;
            public int Toplam;
        }

        [WebMethod]
        public List<Durum> Sonuc()
        {
            int count=0;
            List<Durum> lstSales = new List<Durum>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyWebsiteDB"].ConnectionString);


            SqlCommand objComm = new SqlCommand("SELECT Durum, COUNT(*) AS Toplam FROM Sepet GROUP BY Durum  ", con);
            con.Open();
           
            SqlDataReader sdr = objComm.ExecuteReader();

            while (sdr.Read())
            {
                Durum objValues = new Durum();
                string durum1 = sdr["Durum"].ToString();
                if (durum1== "true")
                {
                    objValues.Durumu = sdr["Durum"].ToString();
                   

                }
                objValues.Toplam = Convert.ToInt32(sdr["Toplam"]);


                lstSales.Add(objValues);
            }

            con.Close();
            sdr.Close();
            return lstSales;
        }
        public class Siparis
        {
            public string Day { get; set; }
            public decimal Saleprice { get; set; }
        }
        [WebMethod]
        public static List<object> GetChartData()
        {
            string query = "select Gün ,tutar from Table_chart ";
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
    }
}
