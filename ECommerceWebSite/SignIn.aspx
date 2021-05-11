<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="ECommerceWebSite.SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Giriş</title>
    <script src="https://code.jquery.com/jquery-3.6.0.js" integrity="sha256-H+K7U5CnXl1h5ywQfKtSj8PCmoN9aaq30gDh27Xc0jk=" crossorigin="anonymous">

    </script>
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
    <!--[if lt IE 9]>
    <script src="js/html5shiv.js"></script>
    <script src="js/respond.min.js"></script>
    <![endif]-->
    <link rel="shortcut icon" href="eshopper/images/ico/favicon.ico">
    <%-- <link rel="apple-touch-icon-precomposed" sizes="144x144" href="eshopper/images/ico/apple-touch-icon-144-precomposed.png">
    <link rel="apple-touch-icon-precomposed" sizes="114x114" href="eshopper/images/ico/apple-touch-icon-114-precomposed.png">
    <link rel="apple-touch-icon-precomposed" sizes="72x72" href="eshopper/images/ico/apple-touch-icon-72-precomposed.png">--%>
    <link rel="apple-touch-icon-precomposed" href="eshopper/images/ico/apple-touch-icon-57-precomposed.png">
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
        <header id="header">
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

                        </div>

                    </div>
                </div>
            </div>
            <!--/header-bottom-->
        </header>


        <!-- Sign in Start Here-->
        <div class="container">
            <div class="form-horizontal">
                <h2>Giriş Formu</h2>
                <hr />
                <div class="form-group">
                    <asp:Label ID="Label1" CssClass="col-md-2 control-label" runat="server" Text="Kullanıcı Adı:"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox ID="TxtUserName" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserName" runat="server" CssClass="text-danger" ErrorMessage="Kullanıcı Adı Giriniz" ControlToValidate="TxtUserName" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="form-horizontal">
                <div class="form-group">
                    <asp:Label ID="Label2" CssClass="col-md-2 control-label" runat="server" Text="Şifre:"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox ID="TxtPass" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPass" runat="server" CssClass="text-danger" ErrorMessage="Şifre Giriniz" ControlToValidate="TxtPass" ForeColor="Red"></asp:RequiredFieldValidator>

                    </div>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="form-horizontal">
                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-6">
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                        <asp:Label ID="Label3" CssClass="control-label" runat="server" Text="Beni Hatırla"></asp:Label>

                    </div>
                </div>
            </div>
        </div>

        <div class="container">
            <div class="form-horizontal">
                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-6">
                        <asp:Button ID="BtnSingUp" CssClass=" RemoveButton1 " runat="server" Text="Kullanıcı Girişi" OnClick="BtnSingUp_Click" />
                        <asp:Button ID="BtnADminSignIn" CssClass=" RemoveButton1 " runat="server" Text="Admin Girişi" OnClick="BtnADminSignIn_Click" />
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/SignUp.aspx">Üye Ol</asp:HyperLink>
                    </div>
                </div>
            </div>
        </div>

        <!--- Forget Password start --->
        <div class="container">
            <div class="form-horizontal">
                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-6">
                        <asp:HyperLink ID="HyperLinkForgotPass" runat="server" NavigateUrl="~/ForgotPass.aspx">Şifremi Unuttum</asp:HyperLink>

                    </div>
                </div>
            </div>
        </div>
        <!--- Forget Password end --->

        <div class="container">
            <div class="form-horizontal">
                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-6">
                        <asp:Label ID="LblError" CssClass="text-danger" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
        </div>


        <!-- Footer Contents Start Here-->
        <footer class="footer-pos">
            <div class="container">
                <p class="pull-right"><a href="#">Yukarı Dön</a></p>
                <p>&copy;2021HaticeAtes.in &middot;<a href="Products.aspx">Ana Sayfa</a>&middot;<a href="Contact.aspx">İletişim</a>&middot;<a href="Products">Ürünler</a></p>
            </div>

        </footer>



        <!-- Footer Contents End Here-->
    </form>
</body>
</html>
