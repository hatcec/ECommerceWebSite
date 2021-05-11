<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Buy.aspx.cs" Inherits="ECommerceWebSite.Buy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="cart_items">
        <div class="container">
            <!--/breadcrums-->
            <div class="row">  	
	    		<div class="col-sm-8">
	    			<div class="contact-form">
	    				<h2 class="title text-center">
                                <p>Ödeme Bilgileri</p></h2>
	    				<div class="status alert alert-success" style="display: none"></div>
				    	<form id="main-contact-form" class="contact-form row" name="contact-form" method="post">
				            <div class="form-group col-md-12">
				               <asp:Label ID="Label1" runat="server" Text="Ad Soyad"></asp:Label><br />
                                <asp:TextBox ID="TxtName" runat="server"   Width="720px" BackColor="GradientActiveCaption" BorderColor="GradientActiveCaption" ForeColor="White"></asp:TextBox>
				            </div>
				            <div class="form-group col-md-12">
				                 <asp:Label ID="Label4" runat="server" Text="Adres"></asp:Label>
                                <asp:TextBox ID="TxtAdress" runat="server"  Width="720px" BackColor="GradientActiveCaption" BorderColor="GradientActiveCaption" ForeColor="White"></asp:TextBox>
				            </div>
				            <div class="form-group col-md-12">
				              <asp:Label ID="Label2" runat="server" Text="Kart Numarası"></asp:Label><br />
                                <asp:TextBox ID="TxtCartNo" runat="server" MaxLength="16" Width="720px"  BackColor="GradientActiveCaption" BorderColor="GradientActiveCaption" ForeColor="White"></asp:TextBox>
				            </div>
				            <div class="form-group col-md-12">
				              <asp:Label ID="Label3" runat="server" Text="Güvenlik"></asp:Label><br />
                                <asp:TextBox ID="TxtCvc" runat="server" MaxLength="3"  TextMode="Number" Width="720px" BackColor="GradientActiveCaption" BorderColor="GradientActiveCaption" ForeColor="White" ></asp:TextBox>
				            </div>                        
				            <div class="form-group col-md-12">
				                <asp:Button ID="Button1" runat="server" Text="Ödeme yap" OnClick="Button1_Click" />
				            </div>
				        </form>
	    			</div>
	    		</div>
            <div class="shopper-informations">
                <div class="row">
                    <div class="col-sm-10">
                        <div class="shopper-info">
                            <div class="form-one">

                            </div>
                        </div>

                    </div>

                </div>


                <div class="table-responsive cart_info">

                    <h4 class="proNameViewCart" runat="server" id="h4Noitems"></h4>
                    <table class="table table-condensed">
                        <thead>
                            <tr class="cart_menu">
                                <td class="image">#</td>
                                <td class="description">Ürün Adı</td>
                                <td class="price">Fiyat</td>
                                <td class="price"></td>


                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="RepeaterProductCart" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td class="cart_product">
                                            <a href="ProductView.aspx?id=<%# Eval("id") %>" target="_blank">
                                                <img src="../<%# Eval("ProductImages") %>" width="100" height="100" alt="" onerror="this.src='Images/resim-yok.jpg'"></a>
                                        </td>
                                        <td class="cart_description">
                                            <h4><a href="ProductView.aspx?id=<%# Eval("id") %>" target="_blank"><%# Eval("ProductName") %></a></h4>

                                        </td>
                                        <td class="cart_price">
                                            <span class="proPrice"><%# Eval("ProductPrice") %></span>
                                        </td>

                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                            <tr>
                                <td colspan="4">&nbsp;</td>
                                <td colspan="2">
                                    <table class="table table-condensed total-result">

                                        <tr>

                                            <p>Toplam:
                                                <asp:Label ID="Label6" runat="server" Text=""></asp:Label></p>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                    </table>
                </div>

            </div>

        </div>


    </section>


</asp:Content>
