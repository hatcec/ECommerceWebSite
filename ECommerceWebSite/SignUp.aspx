<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="ECommerceWebSite.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Üye Ol</title>
    <script src="https://code.jquery.com/jquery-3.6.0.js" integrity="sha256-H+K7U5CnXl1h5ywQfKtSj8PCmoN9aaq30gDh27Xc0jk=" crossorigin="anonymous">

    </script>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-compatible" content="IE-edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <link href="eshopper/css/bootstrap.min.css" rel="stylesheet">
    <link href="eshopper/css/font-awesome.min.css" rel="stylesheet">
    <link href="eshopper/css/prettyPhoto.css" rel="stylesheet">
    <link href="eshopper/css/price-range.css" rel="stylesheet">
    <link href="eshopper/css/animate.css" rel="stylesheet">
    <link href="eshopper/css/main.css" rel="stylesheet">
    <link href="eshopper/css/responsive.css" rel="stylesheet">
    <link href="css/Custome.css" rel="stylesheet">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <link href="css/Custome.css" rel="stylesheet" />
    <%-- <link href="css/bootstrap.min.css" rel="stylesheet" />--%>
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

        <div>

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

                                    <ul class="dropdown-menu">
                                    </ul>
                                </div>

                                <div class="btn-group">

                                    <ul class="dropdown-menu">
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-8 clearfix">
                            <div class="shop-menu clearfix pull-right">
                                <ul class="nav navbar-nav">
                                    <li><a href="Products.aspx">Ürünler</a></li>
                                    <li><a href="UserHome.aspx"><i class="fa fa-user"></i>Hesabım</a></li>
                                    <li><a href="Buy.aspx"><i class="fa fa-crosshairs"></i>Ödeme</a></li>
                                    <li><a href="Cart.aspx"><i class="fa fa-shopping-cart"></i>Sepetim</a></li>
                                    <li><a href="Contact.aspx"><i class="fa fa-calendar"></i>İletişim</a></li>
                                    <li id="btnSingIn" runat="server"><a href="SignIn.aspx"><i class="fa fa-lock"></i>Giriş Yap</a></li>
                                    <li id="Li1" runat="server"><a href="SignUp.aspx"><i class="fa fa-lock"></i>Üye Ol</a></li>

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
                                </ul>
                            </div>
                        </div>
                        <%--     <li ><a href="Products.aspx">Ürünler</a>--%>
                        <%-- <ul role="menu" class="sub-menu">
                                        <li><a href="shop.html">Products</a></li>
										<li><a href="product-details.html">Product Details</a></li> 
										<li><a href="checkout.html">Checkout</a></li> 
										<li><a href="cart.html">Cart</a></li> 
										<li><a href="login.html">Login</a></li> 
                                    </ul>--%>
                        <%--   </li>--%>
                        <%--<li class="dropdown"><a href="#">Blog<i class="fa fa-angle-down"></i></a>
                                    <ul role="menu" class="sub-menu">
                                        <li><a href="blog.html">Blog List</a></li>
										<li><a href="blog-single.html">Blog Single</a></li>
                                    </ul>
                                </li> 
								<li><a href="404.html">404</a></li>
								<li><a href="contact-us.html">Contact</a></li>--%>
                    </div>

                </div>
            </div>
        </div>
        <!--/header-bottom-->
        </header>


        <!-- Singup Page -->

        <div class="container">


            <div class="col-xs-9">
                <asp:TextBox ID="TxtUName" runat="server" class="form-control" placeholder="Kullanıcı Adınızı Giriniz.."></asp:TextBox>
                <br />
            </div>
            <div class="col-xs-9">
                <asp:TextBox ID="TxtPass" runat="server" class="form-control" placeholder="Şifreyi Giriniz.." TextMode="Password"></asp:TextBox>
                <br />
            </div>

            <div class="col-xs-9">
                <asp:TextBox ID="TxtCPass" runat="server" class="form-control" placeholder="Şifreyi Tekrar Giriniz.." TextMode="Password"></asp:TextBox>
                <br />
            </div>
            <div class="col-xs-9">
                <asp:TextBox ID="TxtName" runat="server" class="form-control" placeholder="Ad Soyad Giriniz.."></asp:TextBox>
                <br />
            </div>
            <div class="col-xs-9">
                <asp:TextBox ID="TxtMail" runat="server" class="form-control" placeholder="Email Giriniz.." TextMode="Email"></asp:TextBox>
                <br />
            </div>
            <label class="col-xs-9"></label>
            <div class="col-xs-11">
                <asp:Button ID="BtnSingUp" CssClass=" RemoveButton1 " runat="server" Text="Üye Ol" OnClick="BtnSingUp_Click" />
                <asp:Label ID="LblMsg" runat="server" Text=""></asp:Label>
            </div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
        </div>






        <!-- Singup Page end-->
        <!-- Footer Contents Start Here-->
        <footer class="footer-pos">
            <div class="container">
                <p class="pull-right"><a href="#">Yukarı Dön</a></p>
                <p>&copy;2021HaticeAtes.in &middot;<a href="Default.aspx">Ana Sayfa</a>&middot;<a href="#">Hakkımızda</a>&middot;<a href="#">İletişim</a>&middot;<a href="#">Ürünler</a></p>
            </div>

        </footer>



        <!-- Footer Contents End Here-->
    </form>
</body>
</html>
