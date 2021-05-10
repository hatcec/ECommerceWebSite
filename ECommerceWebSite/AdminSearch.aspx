<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AdminSearch.aspx.cs" Inherits="ECommerceWebSite.AdminSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="card mb-4">
        <div class="card-header">
            <i class="fas fa-table mr-1"></i>
            Ürünler
        </div>
        <div class="card-body">
            <div class="table-responsive">
                <table class="table table-bordered" id="dataTable">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Ürün </th>
                            <th>Ürün Açıklama </th>
                            <th>Fiyat</th>
                            <th>Kategori</th>
                            <th>Marka</th>
                            <th>Düzenle</th>

                        </tr>
                    </thead>
                    <tfoot>
                        <tr>
                            <th>#</th>
                            <th>Ürün </th>
                            <th>Ürün Açıklama </th>
                            <th>Fiyat</th>
                            <th>Kategori</th>
                            <th>Marka</th>
                            <th>Düzenle</th>

                        </tr>
                    </tfoot>
                    <tbody>
                        <asp:Repeater ID="RepeaterProductCart" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="cart_product">

                                        <img src="../<%# Eval("ProductImages") %>" width="100" height="100" alt="" onerror="this.src='Images/resim-yok.jpg'"></a>
                                    </td>
                                    <td class="cart_description">
                                        <h4><%# Eval("ProductName") %></a></h4>

                                    </td>
                                    <td class="cart_price">
                                        <span class="proPrice"><%# Eval("ProductDescription") %></span>
                                    </td>
                                    <td class="cart_price">
                                        <span class="proPrice"><%# Eval("ProductPrice") %></span>
                                    </td>
                                    <td class="cart_price">
                                        <span class="proPrice"><%# Eval("CategoryName") %></span>
                                    </td>
                                    <td class="cart_price">
                                        <span class="proPrice"><%# Eval("Name") %></span>
                                    </td>
                                    <td  >
                                        <a href="ProductEdit.aspx?id=<%# Eval("id") %>" class="btn btn-primary  " style="-moz-animation-delay:inherit;">Düzenle</a>

                                    </td>

                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
