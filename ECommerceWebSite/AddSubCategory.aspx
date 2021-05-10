<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AddSubCategory.aspx.cs" Inherits="ECommerceWebSite.AddSubCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
     <br />
     <br />
    <div>  <div class="container">
            <div class="form-horizontal">
                <h2>Alt Kategori Ekle</h2>
                <hr />
                <div class="form-group">
                    <asp:Label ID="Label2" CssClass="col-md-2 control-label" runat="server" Text="Kategori Adı:"></asp:Label>
                    <div class="col-md-3">
                        <asp:DropDownList ID="DdlMainCategoryID" CssClass="form-control" runat="server"></asp:DropDownList>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidatorMainCat" runat="server" CssClass="text-danger" ErrorMessage="Kategori Adı Seçiniz" ControlToValidate="DdlMainCategoryID" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label1" CssClass="col-md-2 control-label" runat="server" Text="Alt Kategori Adı:"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox ID="TxtSubCategoryName" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorSubCategoryName" runat="server" CssClass="text-danger" ErrorMessage="Alt Kategori Adı Giriniz" ControlToValidate="TxtSubCategoryName" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
        </div>
     
    

        <div class="container">
            <div class="form-horizontal">
                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-6">
                        <asp:Button ID="BtnSubCategoryAdd" class="btn btn-success" runat="server" Text="Alt Kategori Ekle" OnClick="BtnCategoryAdd_Click"  />
                         </div>
                </div>
            </div>
        </div>
      
    <div class="panel panel-default">

        <div class="panel-heading">Tüm Alt Kategoriler</div>


        <asp:Repeater ID="RepeaterSubCat" runat="server">

            <HeaderTemplate>
                <table class="table">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Alt Kategori</th>
                            <th>Kategori</th>
                            <th>Düzenle</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <th><%# Eval("SubCatID") %> </th>
                    <td><%# Eval("SubCatName") %>   </td>
                    <td><%# Eval("CategoryName") %>   </td>

                    <td>Düzenle</td>
                </tr>
            </ItemTemplate>


            <FooterTemplate>
                </tbody>

              </table>
            </FooterTemplate>

        </asp:Repeater>
    </div>
    
       </div> 
</asp:Content>
