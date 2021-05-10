<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="ECommerceWebSite.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   

    <div class="col-sm-9 padding-right">
        <div class="features_items">
            <!--features_items-->
             
            <h2 class="title text-center">Ürünler</h2>
            <asp:Repeater ID="RepeaterProducts" runat="server">
                <ItemTemplate>

                    <div class="col-sm-4">
                        <div class="product-image-wrapper">
                            <div class="single-products">
                                <div class="card" style="width: 28rem; height: 25rem;">

                                    <div class="productinfo text-center">
                                        <img src="../<%# Eval("ProductImages") %>" alt=""  style="width: 28rem; height: 18rem;"onerror="this.src='Images/resim-yok.jpg'" />


                                        <div class="proName"><%# Eval("ProductName") %></div>
                                        <div class="proName"><%# Eval("Name") %></div>
                                        <div class="proPrice"><span class="proPrice"><%# Eval ("ProductPrice") %></span> </div>

                                    </div>
                                    <div class="product-overlay">
                                        <div class="overlay-content">

                                            <a href="ProductView.aspx?id=<%# Eval("id") %>" class="btn btn-default add-to-cart"><i class="fa fa-dashboard"></i>Detay</a>
                                        </div>
                                    </div>

                                </div>
                            </div>
                           

                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
          <%--  <ul class="pagination">
                <li class="active"><a href="">1</a></li>
                <li><a href="">2</a></li>
                <li><a href="">3</a></li>
                <li><a href="">&raquo;</a></li>
            </ul>--%>
        </div>
        <!--features_items-->
    </div>
</asp:Content>
