<%@ Page Title="" Language="C#" ValidateRequest="false" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="ECommerceWebSite.AddProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card mb-4">
        <div class="card-header">
            <i class="fas fa-table mr-1"></i>
            Ürün Ekle
        </div>
        <br />
        <br />
        <div class="form-group">
            <asp:Label ID="Label1" CssClass="col-md-2 control-label" runat="server" Text="Ürün Adı"></asp:Label>
            <div class="col-md-3">
                <asp:TextBox ID="TxtProduceName" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="Label2" CssClass="col-md-2 control-label" runat="server" Text="Fiyat"></asp:Label>
            <div class="col-md-3">
                <asp:TextBox ID="TxtPrice" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="Label4" CssClass="col-md-2 control-label" runat="server" Text="Marka"></asp:Label>
            <div class="col-md-3">
                <asp:DropDownList ID="DdlBrand" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="Label5" CssClass="col-md-2 control-label" runat="server" Text="Kategori"></asp:Label>
            <div class="col-md-3">
                <asp:DropDownList ID="DdlCategory" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="Label6" CssClass="col-md-2 control-label" runat="server" Text="Ürün Detayı"></asp:Label>
            <div class="col-md-3">
                <asp:TextBox ID="TxtDescription" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="Label8" CssClass="col-md-2 control-label" runat="server" Text="Ürün Resmi Yükle"></asp:Label>
            <div class="col-md-3">
                <asp:FileUpload ID="FuImg01" runat="server" />

            </div>
        </div>
        <div class="form-group">
            <div class="col-md-2"></div>
            <div class="col-md-6">
                <asp:Button ID="BtnAdd" class="btn btn-success" runat="server" Text="Ürün Ekle&raquo;" OnClick="BtnAdd_Click" />
            </div>
        </div>
    </div>


</asp:Content>
