<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserHome.aspx.cs" Inherits="ECommerceWebSite.UserHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hesabım</title>
    <script src="https://code.jquery.com/jquery-3.6.0.js" integrity="sha256-H+K7U5CnXl1h5ywQfKtSj8PCmoN9aaq30gDh27Xc0jk=" crossorigin="anonymous">

    </script>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-compatible" content="IE-edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <link href="css/Custome.css" rel="stylesheet" />
    <link href="eshopper/css/bootstrap.min.css" rel="stylesheet">
    <link href="eshopper/css/font-awesome.min.css" rel="stylesheet">
    <link href="eshopper/css/prettyPhoto.css" rel="stylesheet">
    <link href="eshopper/css/price-range.css" rel="stylesheet">
    <link href="eshopper/css/animate.css" rel="stylesheet">
    <link href="eshopper/css/main.css" rel="stylesheet">
    <link href="eshopper/css/responsive.css" rel="stylesheet">

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <script>
        $(document).ready(function myFunction() {
            $("#BtnCart").click(function myFunction() {
                window.location.href = "/Cart.aspx";
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <%-- <div>
            <div class="navbar navbar-default navbar-fixed-top" role="navigation">
                <div class="container">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                            <span class="sr-only">toogle navigation </span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand" href="Default.aspx"><span>
                            <img src="#" alt="E ticaret Sitesi" height="30" /></span>E-Ticaret</a>
                    </div>
                    <div class="navbar-collapse collapsed">
                        <ul class="nav navbar-nav navbar-right">
                            <li><a href="Default.aspx">Ana Sayfa</a> </li>
                            <li><a href="#">Hakkımızda</a> </li>
                            <li><a href="#">İletişim</a> </li>
                            <li><a href="Products.aspx">Ürünler</a> </li>

                            <li class="dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown">Ürünler<b class="caret"></b></a>
                                <ul class="dropdown-menu">
                                    <li class="dropdown-header">Erkek </li>
                                    <li role="separator" class="divider"></li>
                                    <li><a href="#">Tişört</a> </li>
                                    <li><a href="#">Pantolon</a> </li>
                                    <li><a href="#">Ev Giyim</a> </li>
                                </ul>
                                <ul class="dropdown-menu">
                                    <li role="separator" class="divider"></li>
                                    <li class="dropdown-header">Kadın </li>
                                    <li role="separator" class="divider"></li>
                                    <li><a href="#">Tişört</a> </li>
                                    <li><a href="#">Pantolon</a> </li>
                                    <li><a href="#">Ev Giyim</a> </li>
                                </ul>
                            </li>
                            <li > 
                                <asp:Button ID="BtnLogOut" CssClass="btn btn-default navbar-btn" runat="server" Text="Çıkış" OnClick="BtnLogOut_Click"  />
                            </li>
                           


                        </ul>

                    </div>
                </div>


            </div>


        </div>--%>

        <%--    <div class="container">
            <div class="form-horizontal">
                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-6">
                         <asp:Label ID="LblSuccess" runat="server" CssClass="text-success"></asp:Label>

                          </div>
                </div>
            </div>
        </div>--%>
        <header id="header">
            <!--header-->
            <%-- %><div class="header_top"><!--header_top-->
            <%--  
			<div class="container">
				<div class="row">
					<div class="col-sm-6">
						<div class="contactinfo">
							<ul class="nav nav-pills">
								<%--<li><a href="#"><i class="fa fa-phone"></i> +2 95 01 88 821</a></li>--
								<li><a href="#"><i class="fa fa-envelope"></i> htccnbz06@gmail.com</a></li>
							</ul>
						</div>
					</div>
					<%--<div class="col-sm-6">
						<div class="social-icons pull-right">
							<ul class="nav navbar-nav">
							
								<li><a href="https://www.facebook.com/"><i class="fa fa-facebook"></i></a></li>
								<li><a href="https://twitter.com/"><i class="fa fa-twitter"></i></a></li>							
							</ul>
						</div>
					</div>-
				</div>
			</div>- 
		</div><!--/header_top-->--%>
            <div class="header-middle">
                <!--header-middle-->
                <div class="container">
                    <div class="row">
                        <div class="col-md-4 clearfix">
                            <div class="logo pull-left">
                                <a href="index.html">
                                    <img src="images/home/logo.png" alt="" /></a>
                            </div>
                            <div class="btn-group pull-right clearfix">
                                <div class="btn-group">
                                </div>


                            </div>
                        </div>
                        <div class="col-md-8 clearfix">
                            <div class="shop-menu clearfix pull-right">
                                <ul class="nav navbar-nav">
                                    <li><a href="Products.aspx">Ürünler</a></li>
                                    <li class="active"><a href="UserHome.aspx"><i class="fa fa-user"></i>Hesabım</a></li>
                                    <li><a href="Buy.aspx?Uid=" <%# Eval("Session['UserID']") %>><i class="fa fa-crosshairs"></i>Ödeme</a></li>
                                    <li>
                                        <button id="BtnCart" class="btn btn-default fa fa-shopping-cart " type="button" runat="server">Sepetim<span class="badge" id="ProductCount1" runat="server"></span></button>


                                    </li>
                                    <li>
                                        <asp:Button ID="BtnLogIn" CssClass="btn btn-default fa fa-lock" runat="server" Text="Giriş Yap" OnClick="BtnLogIn_Click" /></li>
                                    <li>
                                        <asp:Button ID="BtnLogOut" CssClass="btn btn-default fa fa-lock" runat="server" Text="Çıkış Yap" OnClick="BtnLogOut_Click1" /></li>

                                    <%--<li role="button" onclick="BtnLogIn_Click"><a href="SignIn.aspx"><i class="fa fa-lock" ></i> Giriş Yap</a></li>--%>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!--/header-middle-->
            <div class="header-bottom">
                <!--header-bottom-->
                <div class="container">
                    <div class="row">
                        <div class="col-sm-9">
                            <div class="navbar-header">
                                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                                    <span class="sr-only">Toggle navigation</span>
                                    <span class="icon-bar"></span>
                                    <span class="icon-bar"></span>
                                    <span class="icon-bar"></span>
                                </button>
                            </div>
                            <div class="mainmenu pull-left">
                                <ul class="nav navbar-nav collapse navbar-collapse">
                                    <%--<li><a href="Default.aspx">Ana Sayfa</a></li>--%>
                                </ul>
                            </div>
                        </div>


                        <div class="col-sm-3">
                            <div class="navbar-form navbar-right">
                                <asp:TextBox ID="TxtSearch" runat="server" CssClass="form-control" placeholder="Ürün Arama"></asp:TextBox>
                            </div>

                        </div>
                    </div>

                </div>
            </div>
            </div><!--/header-bottom-->
        </header>
        <!--/header-->


        <section>
            <div class="container">
                <div class="row">


                    <asp:Label ID="LblSuccess" runat="server" CssClass="text-success"></asp:Label>
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
                                                       <span class="cart_description"><%# Eval("SepetId") %></span>
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
                </div>


            </div>
        </section>

        <footer id="footer">
            <!--Footer-->
            <div class="footer-top">
                <div class="container">
                    <div class="row">
                        <div class="container">
                            <p class="pull-right"><a href="#">Yukarı Dön</a></p>
                            <p>&copy;2021HaticeAtes.in &middot;<a href="Products.aspx">Ana Sayfa</a>&middot;<a href="Contact.aspx">İletişim</a>&middot;<a href="Products">Ürünler</a></p>
                        </div>
                    </div>
                </div>
            </div>

        </footer>

        <!--/Footer-->



        <script src="js/jquery.js"></script>
        <script src="js/bootstrap.min.js"></script>
        <script src="js/jquery.scrollUp.min.js"></script>
        <script src="js/price-range.js"></script>
        <script src="js/jquery.prettyPhoto.js"></script>
        <script src="js/main.js"></script>



        <%--  <!-- Footer Contents Start Here-->
        <footer class="footer-pos">
            <div class="container">
                <p class="pull-right"><a href="#">Yukarı Dön</a></p>
                <p>&copy;2021HaticeAtes.in &middot;<a href="Default.aspx">Ana Sayfa</a>&middot;<a href="#">Hakkımızda</a>&middot;<a href="#">İletişim</a>&middot;<a href="#">Ürünler</a></p>
            </div>

        </footer>



        <!-- Footer Contents End Here-->--%>
    </form>
</body>
</html>
