<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="ECommerceWebSite.OrderList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card mb-4">
        <div class="card-header">
            <i class="fas fa-table mr-1"></i>
            Siparişler
        </div>
        <div class="card-body">
            <div class="table-responsive">
                <table class="table table-bordered" id="dataTable">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Sepet ID </th>
                            <th>Kullanıcı Adı </th>
                            <th>Sipariş Tarihi</th>
                            <th>Sipariş Tutarı</th>
                            <th>Sipariş Durumu</th>
                          

                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="RepeaterOrderCart" runat="server">
                            <ItemTemplate>
                                <tr>
                                   
                                    <td class="cart_description">
                                        <h4><%# Eval("Id") %></a></h4>

                                    </td>
                                    <td class="cart_description">
                                        <a href="AdminCartDetail.aspx?id=<%# Eval("SepetId")%>"> <span class="cart_description"><%# Eval("SepetId") %></span>
                                    </td>
                                    <td class="cart_description">
                                        <span class="cart_description"><%# Eval("UserName") %></span>
                                    </td>
                                    <td class="cart_description">
                                        <span class="cart_description"><%# Eval("SiparisTarihi") %></span>
                                    </td>
                                    <td class="cart_description">
                                        <span class="cart_description"><%# Eval("SiparisTutari") %></span>
                                    </td>
                                    <td class="cart_description">
                                        <span class="cart_description"><%# Eval("Durum") %></span>
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
