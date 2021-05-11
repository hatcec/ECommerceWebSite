<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="ECommerceWebSite.AddCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card mb-4">
        <div class="card-header">
            <i class="fas fa-table mr-1"></i>
            Kategori Ekle
        </div>
        <div class="card-body">
            <div class="table-responsive">

                <div class="form-group">
                    <asp:Label ID="Label1" CssClass="col-md-2 control-label" runat="server" Text="Kategori Adı:"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox ID="TxtCategoryName" CssClass="form-control" runat="server"></asp:TextBox>
                    
                    </div>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="form-horizontal">
                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-6">
                        <asp:Button ID="BtnCategoryAdd" class="btn btn-success" runat="server" Text="Kategori Ekle" OnClick="BtnCategoryAdd_Click" />
                    </div>
                </div>
            </div>
        </div>



        <table class="table table-bordered" id="dataTable">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Kategori </th>
                    <th>Sil</th>

                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="RepeaterCategory" runat="server">
                        <ItemTemplate>
                            <tr>
                                 <td class="cart_price">
                                    <span class="proPrice"><%# Eval("CategoryId") %></span>
                                </td>
                                <td class="cart_price">
                                    <span class="proPrice"><%# Eval("CategoryName") %></span>
                                </td>

                                <td class="cart_delete">
                                    <asp:Button CommandArgument='<%# Eval("CategoryId")%>' ID="BtnSil" runat="server" CssClass="btn btn-danger" Text="Sil" OnClick="BtnSil_Click1" />

                                </td>

                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>
