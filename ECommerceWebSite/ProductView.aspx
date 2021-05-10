<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ProductView.aspx.cs" Inherits="ECommerceWebSite.ProductView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-sm-9 padding-right">
        <div class="product-details">

            <!--product-details-->
            <div class="col-sm-5">
                <div class="view-product">
                    <asp:Repeater ID="RepeaterProductDetails" runat="server">
                        <ItemTemplate>
                            <div class="item <%#GetActiveImgClass(Container.ItemIndex) %>">
                                <img src="../<%# Eval("ProductImages") %>" alt="" height="300" width="200" onerror="this.src='Images/resim-yok.jpg'">
                            </div>
                            </div>
              
                            </div>
            <div class="col-sm-7">

                <div class="product-information">

                    <h1 class="proNameView"><%# Eval("ProductName") %></h1>
                    <span class="proPrice">₺<%# Eval("ProductPrice") %></span> </p>
                            <h5 class="h5size">Ürün Detayı</h5>
                    <p><%# Eval("ProductDescription") %>   </p>
                    <div>

                        <img src="eshopper/images/product-details/rating.png" alt="" />

                        <asp:Button ID="BtnAddCard" runat="server" Text="Sepete Ekle" Width="130px" Height="37px" CssClass=" add-to-cart fa fa-shopping-cart " OnClick="BtnAddCard_Click" />


                    </div>
                        </ItemTemplate>
                    </asp:Repeater>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
