<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPass.aspx.cs" Inherits="ECommerceWebSite.ForgotPass" %>

<!DOCTYPE html>

<html lang="en">

        <head runat="server">
            <meta charset="utf-8">
            <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no"">
            <meta name="description" content="">
            <meta name="author" content="">
            <title>Şifremi Unuttum</title>
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
            <form id="form2" runat="server">
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
                                             <li><a href="Contact.aspx"><i class="fa fa-crosshairs"></i>İletişim</a></li>
                                              
                                                <li id="btnSingIn" runat="server"><a href="SignIn.aspx"><i class="fa fa-lock"></i>Giriş Yap</a></li>
                                                <li id="btnSingUp" runat="server"><a href="SignUp.aspx"><i class="fa fa-lock"></i>Üye Ol</a></li>
                                                
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

                                    </div>

                                    <div class="navbar-form navbar-right">
                                        <ul>
                                            <asp:TextBox ID="TxtSearch" runat="server" CssClass="form-control" placeholder="Ürün Arama"></asp:TextBox>
                                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/711319.png" OnClick="ImageButton1_Click" Height="20px" Width="50px"></asp:ImageButton>
                                        </ul>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                    <!--/header-bottom-->
                </header>


                <div class="container">
                    <div class="form-horizontal">
                        <h2>Şifre Yenileme</h2>
                        <hr />
                        <h3>Email Adresi Giriniz Ve Size Gelen Doğrulama Linki İle Yeni Şifre Oluşturunuz.</h3>
                        <div class="form-group">
                            <asp:Label ID="LblEmail" CssClass="col-md-2 control-label" runat="server" Text="Email Adresi Giriniz:"></asp:Label>
                            <div class="col-md-3">
                                <asp:TextBox ID="TxtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" CssClas="Text-danger" runat="server" ErrorMessage="Email Adresini Giriniz" ControlToValidate="TxtEmail" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-2"></div>
                        <div class="col-md-6">
                            <asp:Button ID="BtnREsetPass" CssClass="btn btn-default" runat="server" Text="Şifreyi Sıfırla" OnClick="BtnREsetPass_Click" />
                            <asp:Label ID="LblResetPassMsg" CssClass="text-success" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>


















               <footer id="footer">
        <!--Footer-->
        <footer class="footer-pos">
            <div class="container">
                <p class="pull-right"><a href="#">Yukarı Dön</a></p>
               <p>&copy;2021HaticeAtes.in &middot;<a href="Products.aspx">Ana Sayfa</a>&middot;<a href="Contact.aspx">İletişim</a>&middot;<a href="Products">Ürünler</a></p>
            </div>

        </footer>

    </footer>


                <!-- Footer Contents End Here-->
            </form>
        </body>
        </html>
