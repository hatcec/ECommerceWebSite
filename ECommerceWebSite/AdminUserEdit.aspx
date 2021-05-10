<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AdminUserEdit.aspx.cs" Inherits="ECommerceWebSite.AdminUserEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card mb-4">
        <div class="card-header">
            <i class="fas fa-table mr-1"></i>
            Ürün Ekle
        </div>
        <br />
        <br />
        <div class="form-group">
            <asp:Label ID="Label1" CssClass="col-md-2 control-label" runat="server" Text="Kullanıcı Adı"></asp:Label>
            <div class="col-md-3">
                <asp:TextBox ID="TxtUserName" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="Label2" CssClass="col-md-2 control-label" runat="server" Text="Email"></asp:Label>
            <div class="col-md-3">
                <asp:TextBox ID="TxtEmail" CssClass="form-control" runat="server" TextMode="Email"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="Label3" CssClass="col-md-2 control-label" runat="server" Text="Ad-Soyad"></asp:Label>
            <div class="col-md-3">
                <asp:TextBox ID="TxtName" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="Label4" CssClass="col-md-2 control-label" runat="server" Text="Rol"></asp:Label>
            <div class="col-md-3">
                <asp:DropDownList ID="DdlRole" CssClass="form-control" runat="server">
                    <asp:ListItem Value="user">user</asp:ListItem>
                    <asp:ListItem>admin</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-2"></div>
            <div class="col-md-6">
                <asp:Button ID="BtnUpdate" class="btn btn-success" runat="server" Text="Güncelle" OnClick="BtnUpdate_Click" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-2"></div>
            <div class="col-md-6">
                <asp:Button ID="BtnDel" class="btn btn-danger" runat="server" Text="Sil" OnClick="BtnDel_Click" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-2"></div>
            <div class="col-md-6">
                <asp:Button ID="BtnCanCEl" class="btn btn-default" runat="server" Text="İptal" OnClick="BtnCanCEl_Click" />
            </div>
        </div>
    </div>
</asp:Content>
