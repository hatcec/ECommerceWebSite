<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AdminChart.aspx.cs" Inherits="ECommerceWebSite.AdminChart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      
  
    <%-- <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"> </script>--%>
    <script src="https://code.highcharts.com/highcharts.js"> </script>
    <script src="https://code.highcharts.com/modules/exporting.js"></script>
    <script src="https://code.highcharts.com/modules/export-data.js"></script>
    <script src="https://code.highcharts.com/modules/accessibility.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.0/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.16/js/jquery.dataTables.min.js"></script>
 <script> $('#container').load('/AdminChart.aspx') </script>

    <div id="chart" style="width: 900px; height: 500px;">


<script type="text/javascript" src="https://www.google.com/jsapi"></script>
<script type="text/javascript">
    google.load("visualization", "1", { packages: ["corechart"] });
    google.setOnLoadCallback(drawChart);
    function drawChart() {
        var container = document.createElement('div');
        document.body.appendChild(container);
        var options = {
            title: 'Günlere Göre Satış Tutarı',
            width: 600,
            height: 400,
            bar: { groupWidth: "95%" },
            legend: { position: "none" },
            isStacked: true
        };
        $.ajax({
            type: "POST",
            url: "AdminChart.aspx/GetChartData",
            data: '{}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                var data;
                var container;

              
                var data = google.visualization.arrayToDataTable(r.d);
                var container = new google.visualization.ColumnChart($("#chart")[0]);
               
                container.draw(data, options);
            },
            failure: function (r) {
                alert(r.d);
            },
            error: function (r) {
                alert(r.d);
            }
        });
    }
</script>

</div>
     <div id = "SepetDurum" style = "width: 500px; height: 300px;"> 
         <script>

    google.load("visualization", "1", { packages: ["corechart"] });
    google.setOnLoadCallback(createPIE);

    function createPIE() {
    
        var options = {
            title: 'Sepetin Siparişe Çevrilme Oranı',
            colors: ['#888', 'orange'],
            is3D: true
        };

        $.ajax({
            url: "WebService.asmx/Sonuc",
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                var arrValues = [['Durumu', 'Toplam']];        
                var iCnt = 0;

                $.each(data.d, function () {
                
                    arrValues.push([data.d[iCnt].Durumu, data.d[iCnt].Toplam]);
                    iCnt += 1;
                });

               
                var figures = google.visualization.arrayToDataTable(arrValues)

             
                var chart = new google.visualization.PieChart(document.getElementById('SepetDurum'));

                chart.draw(figures, options);      
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert('Hata Oluştu');
            }
        });
    }
         </script>
     </div>









  
</asp:Content>
