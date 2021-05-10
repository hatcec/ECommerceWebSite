<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AddBrand.aspx.cs" Inherits="ECommerceWebSite.AddBrand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card mb-4">
        <div class="card-header">
            <i class="fas fa-table mr-1"></i>
          Marka Ekle
        </div>
        <div class="card-body">
            <div class="table-responsive">
             
                <div class="form-group">
                    <asp:Label ID="Label1" CssClass="col-md-2 control-label" runat="server" Text="Marka Adı:"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox ID="TxtBrandName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>



        <div class="container">
            <div class="form-horizontal">
                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-6">
                        <asp:Button ID="BtnBrandAdd" class="btn btn-success" runat="server" Text="Marka Ekle" OnClick="BtnBrandAdd_Click" />
                    </div>
                </div>
            </div>
        </div>


        <table class="table table-bordered" id="dataTable">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Marka </th>
                    <th>Sil</th>

                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="RepeaterBrand" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td class="cart_price">
                                <span class="proPrice"><%# Eval("BrandId") %></span>
                            </td>
                            <td class="cart_price">
                                <span class="proPrice"><%# Eval("Name") %></span>
                            </td>

                            <td class="cart_delete">
                                <asp:Button CommandArgument='<%# Eval("BrandId")%>' ID="BtnSil" runat="server" CssClass="btn btn-danger" Text="Sil" OnClick="BtnSil_Click1" />

                            </td>

                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
   
</asp:Content>
