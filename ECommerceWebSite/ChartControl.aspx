<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ChartControl.aspx.cs" Inherits="ECommerceWebSite.ChartControl" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />



    <div id="container"></div>


    <script src="https://code.highcharts.com/highcharts.js"></script>
    <script src="https://code.highcharts.com/modules/exporting.js"></script>
    <script src="https://code.highcharts.com/modules/export-data.js"></script>
    <script src="https://code.highcharts.com/modules/accessibility.js"></script>
    <script>


        Highcharts.chart('container', {
            chart: {
                type: 'column'
            },
            title: {
                text: "Günlere Göre Sipariş"
            },
            xAxis: {
                title: {
                    text: 'Günler'
                }
          //Categories:[<%=day%>]
            },
            yAxis: {
                title: {
                    text: 'Sipariş Tutari'
                }
            },
            series: [{
                type: 'column',
                name: 'detaylar',
                data:<%=lineData%>,
            }]
          

        });

        
    </script>
    <div id="container2"></div>
    <script>
        Highcharts.chart('container2', {
            chart: {
                type: 'spline'
            },
            title: {
                text: "siparişdetay"
            },
            xAxis: {
                title: {
                    text: 'Ürün'
                },
            },
            yAxis: {
                title: {
                    text: 'Adet'
                }
            },
            series: [{
                type: 'column',
                name: 'detaylar',
                data:<%=lineData2%>,
            }]

        });

    </script>


</asp:Content>
