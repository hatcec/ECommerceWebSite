<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPass.aspx.cs" Inherits="ECommerceWebSite.ForgotPass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Şifremi Unuttum</title>
        <meta charset="utf-8" />
    <meta http-equiv="X-UA-compatible" content="IE-edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <link href="css/Custome.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
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
                          
                            <li ><a href="SignIn.aspx">Giriş</a> </li>


                        </ul>

                    </div>
                </div>


            </div>

        </div>
        <br />
        <br />
        <br />


        <div class="container">
            <div class="form-horizontal">
                <h2>Şifre Yenileme</h2>
<hr />
                <h3>Email Adresi Giriniz Ve Size Gelen Doğrulama Linki İle Yeni Şifre Oluşturunuz.</h3>
            <div class="form-group">
                <asp:Label ID="LblEmail" CssClass="col-md-2 control-label" runat="server" Text="Email Adresi Giriniz:"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="TxtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" CssClas="Text-danger" runat="server" ErrorMessage="Email Adresini Giriniz" ControlToValidate="TxtEmail"  ForeColor="Red"></asp:RequiredFieldValidator></div>
            </div>
            </div>
            <div class="form-group">
                <div  class="col-md-2"></div>
                <div  class="col-md-6">
                    <asp:Button ID="BtnREsetPass" CssClass="btn btn-default" runat="server" Text="Button" OnClick="BtnREsetPass_Click" />
                <asp:Label ID="LblResetPassMsg" CssClass="text-success" runat="server"></asp:Label>
                    </div>
            </div>
        </div>


















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
