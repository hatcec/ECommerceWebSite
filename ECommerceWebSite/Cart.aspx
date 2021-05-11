<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="ECommerceWebSite.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="cart_items">
        <div class="table-responsive cart_info">
           
            <h4 class="proNameViewCart" runat="server" id="h4Noitems"></h4>
            <table class="table table-condensed">
                <thead>
                    <tr class="cart_menu">
                        <td class="image"></td>
                        <td class="description">Ürün</td>
                        <td class="price">Adet Fiyatı</td>

                        <td></td>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="RepeaterProductCart" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="cart_product">
                                    <a href="ProductView.aspx?id=<%# Eval("id") %>" target="_blank">
                                        <img src="../<%# Eval("ProductImages") %>" width="100" height="100" alt="" onerror="this.src='Images/resim-yok.jpg'"></a>
                                </td>
                                <td class="cart_description">
                                    <h4><a href="ProductView.aspx?id=<%# Eval("id") %>" target="_blank"><%# Eval("ProductName") %></a></h4>

                                </td>
                                <td class="cart_price">
                                    <span class="proPrice"><%# Eval("ProductPrice") %></span>
                                </td>
                              

                                <td >
                                    <asp:Button CommandArgument='<%# Eval("id")%>' ID="BtnRemoveCard" runat="server" Text="Sil" CssClass=" RemoveButton1 " OnClick="BtnRemoveCard_Click" />

                                </td>
                               
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>

            </table>
          
                <div class="container1">
                    <div class="heading">
                        <p>Sipariş Detayı</p>
                    </div>
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="total_area">
                                <ul>
                                    <li>Sepet Tutarı  <span runat="server" id="CarTotalSpan"></span></li>
                                   <li>    <asp:Button ID="BtnBuy" runat="server" Text="Siparişi Tamamla" CssClass=" buyNowbtn "  OnClick="BtnBuy_Click" /></li>
                                </ul>
                            
                            </div>
                        </div>
                    </div>
                </div>
        </div>
    
    </section>

</asp:Content>
