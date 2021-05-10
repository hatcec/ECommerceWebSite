using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.DataVisualization.Charting;

namespace ECommerceWebSite
{
    public partial class ChartControl : System.Web.UI.Page
    {
        public static String ConnectString = ConfigurationManager.ConnectionStrings["MyWebsiteDB"].ConnectionString;
        public string lineData, gnler, lineData2,ürün,day;
        protected void Page_Load(object sender, EventArgs e)
        {

            LoadData();
            Günler();          
        }
        
        //SELECT top (10) P.ProductName FROM SepetDetay S inner join Table_Product P on P.id=S.UrunId ORDER BY Adet DESC

    
        public void LoadData()
        {
            siparis siparis = new siparis();
            //DATENAME(DW, SiparisTarihi)
            SqlConnection con = new SqlConnection(ConnectString);
            con.Open();

            SqlCommand cmdd = new SqlCommand("select datename(weekday,SiparisTarihi) as Gün, SiparisTutari from Siparis2", con);//datepart(weekday,SiparisTarihi)
            DataTable dt = new DataTable();
            dt.Load(cmdd.ExecuteReader());
            lineData = "[";
          //  day = "[";
            foreach (DataRow dr in dt.Rows)
            {
               // day += "[" + dr["Gün"] + "],";
                lineData += "[" + dr["Gün"] + ","+ dr["SiparisTutari"] + "],";
                
            }
            
            lineData = lineData.Remove(lineData.Length - 1) + ']';
           // day = day.Remove(day.Length - 1) + ']';
         

        }

        public void Günler()
        {
            SqlConnection con = new SqlConnection(ConnectString);
            con.Open();

            SqlCommand cmdd = new SqlCommand("select  datepart(weekday,SiparisTarihi) as Gün, SiparisTutari from Siparis2", con);
            DataTable dt = new DataTable();
            dt.Load(cmdd.ExecuteReader());
            day = "[";
            foreach (DataRow dr in dt.Rows)
            {

                if (Convert.ToInt32(dr["Gün"]) == 1)
                {
                    day += "[" + "Pazar"+  "],";
                   
                }
                if (Convert.ToInt32(dr["Gün"]) == 2)
                {
                    day += "[" + "Pazartesi" + "],";
                   
                }
                if (Convert.ToInt32(dr["Gün"]) == 3)
                {
                    day += "[" + "Salı" + "],";
                }
                if (Convert.ToInt32(dr["Gün"]) == 4)
                {
                    day += "[" + "Çarşamba" + "],";
                }
                if (Convert.ToInt32(dr["Gün"]) == 5)
                {
                    day += "[" + "Perşembe" + "],";
                }
                if (Convert.ToInt32(dr["Gün"]) == 6)
                {
                    day += "[" + "Cuma" + "],";
                }
                if (Convert.ToInt32(dr["Gün"]) == 7)
                {
                    day += "[" + "Cumartesi" + "],";
                }

            }

            day = day.Remove(day.Length - 1) + ']';

        }
        public void LoadData2()
        {
            siparis siparis = new siparis();
            //DATENAME(DW, SiparisTarihi)
            SqlConnection con = new SqlConnection(ConnectString);
            con.Open();

            SqlCommand cmdd = new SqlCommand("SELECT top (5) ProductName, Adet FROM SepetDetay S inner join Table_Product P on P.id=S.UrunId ORDER BY Adet DESC", con);
            DataTable dt = new DataTable();
            dt.Load(cmdd.ExecuteReader());
            //gridview1.DataSource = dt;
            //gridview1.DataBind();
            lineData2 = "[";
            foreach (DataRow dr in dt.Rows)
            {
                lineData2 += "[" + dr["ProductName"] + "," + dr["Adet"] + "],";
            }
            lineData2 = lineData2.Remove(lineData2.Length - 1) + ']';

          
        }
        public class siparis
        {
            public string SiparisTarihi { get; set; }
        }
        //public void LoadData2()
        //{
        //    DataTable dt = new DataTable();
        //    using (SqlConnection con = new SqlConnection(ConnectString))
        //    {
        //        con.Open();
        //        SqlCommand cmd = new SqlCommand("select SiparisTutari, KullaniciId from Siparis2 where Durum='True' ", con);
        //        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //        sda.Fill(dt);
        //        con.Close();
        //    }
        //    string[] x = new string[dt.Rows.Count];
        //    int[] y = new int[dt.Rows.Count];
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        x[i] = dt.Rows[i][0].ToString();
        //        y[i] = Convert.ToInt32(dt.Rows[i][1]);
        //    }
        //    chart1.Series[0].Points.DataBindXY(x, y);
        //    chart1.Series[0].ChartType = SeriesChartType.Spline;
        //}





        //private void ShowData()
        //{
        //    String myConnection = ConfigurationManager.ConnectionStrings["MyWebsiteDB"].ToString();
        //    SqlConnection con = new SqlConnection(myConnection);
        //    String query = "Select top 5 SpetTutari   From Sepet Where Durum = 'True' order by id desc";
        //    SqlCommand cmd = new SqlCommand(query, con);
        //    DataTable tb = new DataTable();
        //    try
        //    {
        //        con.Open();
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        tb.Load(dr, LoadOption.OverwriteChanges);
        //        con.Close();
        //    }
        //    catch { }

        //    if (tb != null)
        //    {
        //        String chart = "";
        //        // You can change your chart height by modify height value
        //        chart = "<canvas id=\"line-chart\" width =\"100%\" height=\"40\"></canvas>";
        //        chart += "<script>";
        //        chart += "new Chart(document.getElementById(\"line-chart\"),  { type: 'line', data: {  labels:[";

        //        // more details in x-axis
        //                for (int i = 0; i < 100; i++)
        //                    chart += i.ToString() + ",";
        //                chart = chart.Substring(0, chart.Length - 1);

        //                chart += "],datasets: [{ data: [";

        //                // put data from database to chart
        //                String value = "";
        //                for (int i = 0; i < tb.Rows.Count; i++)
        //                    value += tb.Rows[i]["SepetTutari"].ToString() + ",";
        //              //  value = value.Substring(0, value.Length - 1);

        //                chart += value;

        //                chart += "],label: \"Air Temperature\", borderColor: \"#3e95cd\",fill: true}"; // Chart color
        //                chart += "]},options: { title: { display: true,text:  'Air Temperature (oC)'}  } "; // Chart title
        //        chart += "});";
        //        chart += "</script>";

        //        ltChart.Text = chart;
        //    }
        //}


    }
}
//SqlCommand cmdd = new SqlCommand("select datepart(weekday,SiparisTarihi) as Gün, SiparisTutari from Siparis2", con);//datepart(weekday,SiparisTarihi)
//DataTable dt = new DataTable();
//dt.Load(cmdd.ExecuteReader());
////gridview1.DataSource = dt;
////gridview1.DataBind();
//lineData = "[";
////  day = "[";
//foreach (DataRow dr in dt.Rows)
//{
//    // day += "[" + dr["Gün"] + "],";
//    lineData += "[" + dr["Gün"] + "," + dr["SiparisTutari"] + "],";

//}

//lineData = lineData.Remove(lineData.Length - 1) + ']';
//           // day = day.Remove(day.Length - 1) + ']';
         

//        }