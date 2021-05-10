<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AdminCartDetail.aspx.cs" Inherits="ECommerceWebSite.AdminCartDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="card mb-4">
        <div class="card-header">
            <i class="fas fa-table mr-1"></i>
           Sepet Detayı
        </div>
        <div class="card-body">
            <div class="table-responsive">
                <table class="table table-bordered" id="dataTable">
                    <thead>
                        <tr>
                            
                            <th>Sepet ID </th>
                            <th>Ürün Adı </th>
                            <th>Ürün Fiyatı</th>
                            <th>Ürün Adedi</th>
                            

                        </tr>
                    </thead>
         
                    <tbody>
                        <asp:Repeater ID="RepeaterCartDetail" runat="server">
                            <ItemTemplate>
                                <tr>
                                   
                                    <td class="cart_description">
                                        <h4><%# Eval("id") %></a></h4>

                                    </td>
                                    
                                    <td class="cart_description">
                                        <span class="cart_description"><%# Eval("ProductName") %></span>
                                    </td>
                                    <td class="cart_description">
                                        <span class="cart_description"><%# Eval("Fiyat") %></span>
                                    </td>
                                    <td class="cart_description">
                                        <span class="cart_description"><%# Eval("Adet") %></span>
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
