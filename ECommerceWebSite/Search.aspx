<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="ECommerceWebSite.Search" %>
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
                                        <img src="../<%# Eval("ProductImages") %>" alt="" style="width: 28rem; height: 18rem;" />


                                        <div class="proName"><%# Eval("ProductName") %></div>
                                        <div class="proName"><%# Eval("Brand") %></div>
                                        <div class="proPrice"><span class="proOgPrice"><%# Eval ("ProductPrice") %></span> </div>

                                    </div>
                                    <div class="product-overlay">
                                        <div class="overlay-content">

                                           <li><a href="ProductView.aspx?id=<%# Eval("id") %>" style="text-decoration: none;"><i class="fa fa-dashboard"></i>Detay&raquo;</a></li>
                                        </div>
                                    </div>

                                </div>
                            </div>
                           

                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            
        </div>
        <!--features_items-->
    </div>
</asp:Content>
