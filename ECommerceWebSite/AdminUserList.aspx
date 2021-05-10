<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AdminUserList.aspx.cs" Inherits="ECommerceWebSite.AdminUserList" %>

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
                            <th>ID</th>
                            <th>Kullanıcı Adı </th>
                            <th>Email </th>
                            <th>Role</th>
                            <th>Düzenle</th>
                        </tr>
                    </thead>
                    <tfoot>
                        <tr>
                            <th>ID</th>
                            <th>Kullanıcı Adı </th>
                            <th>Email </th>
                            <th>Role</th>
                            <th>Düzenle</th>
                        </tr>
                    </tfoot>
                    <tbody>
                        <asp:Repeater ID="RepeaterAdminUser" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="cart_description">
                                        <h4><%# Eval("Uid") %></a></h4>

                                    </td>
                                    <td class="cart_description">
                                        <h4><%# Eval("UserName") %></a></h4>

                                    </td>
                                    <td class="cart_price">
                                        <span class="proPrice"><%# Eval("Email") %></span>
                                    </td>
                                    <td class="cart_price">
                                        <span class="proPrice"><%# Eval("Name") %></span>
                                    </td>
                                    <td class="cart_price">
                                        <span class="proPrice"><%# Eval("UserType") %></span>
                                    </td>

                                    <td class="cart_delete">
                                        <a href="AdminUserEdit.aspx?id=<%# Eval("Uid") %>" class="btn btn-default glyphicon-edit"><i class="fa fa-dashboard"></i>Düzenle</a>

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
