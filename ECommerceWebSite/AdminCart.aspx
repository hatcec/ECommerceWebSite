<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AdminCart.aspx.cs" Inherits="ECommerceWebSite.AdminCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card mb-4">
        <div class="card-header">
            <i class="fas fa-table mr-1"></i>
            Sepetler
        </div>
        <div class="card-body">
            <div class="table-responsive">
                <table class="table table-bordered" id="dataTable">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Sepet Tutarı</th>
                            <th>Sepet Oluştuma Tarihi</th>
                            <th>Kullanıcı Adı </th>
                            <th>Sepet Durumu</th>
                        

                        </tr>
                    </thead>
                   
                    <tbody>
                        <asp:Repeater ID="RepeaterCartCart" runat="server">
                            <ItemTemplate>
                                <tr>

                                    <td class="cart_description">
                                      <a href="AdminCartDetail.aspx?id=<%# Eval("id")%>">  <h4><%# Eval("id") %></h4></a>

                                    </td>

                                    <td class="cart_description">
                                        <span class="cart_description"><%# Eval("SepetTutari") %></span>
                                    </td>
                                    <td class="cart_description">
                                        <span class="cart_description"><%# Eval("OlusturmaTarihi") %></span>
                                    </td>
                                    <td class="cart_description">
                                        <span class="cart_description"><%# Eval("UserName") %></span>
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
