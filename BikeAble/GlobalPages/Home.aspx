<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BikeAble.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>BikeAble</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <link rel="stylesheet" href="../Style/home.css" />
</head>
<body>
    <form id="form1" runat="server" defaultbutton="login">
        <div class="container-fluid">
            <div id="exTab1" class="container">
                <div class="Titre">
                    <h1>Bike Able</h1>
                </div>
                <ul class="nav nav-pills">
                    <li class="nav-item">
                        <a id="LeftPill" class="nav-link active" href="#1a" data-toggle="tab">Client</a>
                    </li>
                    <li class="nav-item"><a id="RightPill" class="nav-link" href="#2a" data-toggle="tab">Coursier</a>
                    </li>
                </ul>
                <div class="tab-content clearfix">
                    <div class="tab-pane active" id="1a">
                        <div class="row Padding5">
                            <div class="col-xs-5 col-md-4 AR">Nom d'utilisateur :</div>
                            <div class="col-xs-7 col-md-8 AL">
                                <asp:TextBox CssClass="InputW" ID="txtUser" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ValidationGroup='login' CssClass="red" runat="server" ControlToValidate="txtUser" Text="*" />
                            </div>
                        </div>
                        <div class="row Padding5">
                            <div class="col-xs-5 col-md-4 AR">Mot de passe :</div>
                            <div class="col-xs-7 col-md-8 AL">
                                <asp:TextBox CssClass="InputW" ID="TxtPWD" type="password" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ValidationGroup='login' CssClass="red" runat="server" ControlToValidate="txtUser" Text="*" />
                            </div>
                        </div>
                        <div class="row Padding5">
                            <div class="col-xs-5 col-md-4 AR"></div>
                            <div class="col-xs-7 col-md-8 AL" id="ALBtn">
                                <asp:Button OnClick="login_Click" ValidationGroup='login' ID="login" CssClass="btn btn-primary HomeBtn" runat="server" Text="S'identifier" />
                                <asp:Button OnClick="SignUpClient_Click" ID="signUpClient" CssClass="btn btn-primary HomeBtn" runat="server" Text="Créer un compte" />
                            </div>
                        </div>
                    </div>




                    <div class="tab-pane" id="2a">
                        <div class="row Padding5">
                            <div class="col-xs-5 col-md-4 AR">Nom d'utilisateur :</div>
                            <div class="col-xs-7 col-md-8 AL">
                                <asp:TextBox CssClass="InputW" ID="UsernameCoursier" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ValidationGroup='loginCoursier' CssClass="red" runat="server" ControlToValidate="UsernameCoursier" Text="*" />
                            </div>
                        </div>
                        <div class="row Padding5">
                            <div class="col-sm-5 col-md-4 AR">Mot de passe :</div>
                            <div class="col-sm-7 col-md-8 AL">
                                <asp:TextBox CssClass="InputW" ID="PasswordCoursier" runat="server" type="password"></asp:TextBox>
                                <asp:RequiredFieldValidator ValidationGroup='loginCoursier' CssClass="red" runat="server" ControlToValidate="PasswordCoursier" Text="*" />
                            </div>
                        </div>
                        <div class="row Padding5">
                            <div class="col-sm-5 col-md-4 AR"></div>
                            <div class="col-sm-7 col-md-8 AL">
                                <asp:Button OnClick="Coursier_Click" ValidationGroup='loginCoursier' ID="Coursier" CssClass="btn btn-primary HomeBtn" runat="server" Text="S'identifier" />
                                <asp:Button OnClick="SignUpCoursier_Click" ID="Button2" CssClass="btn btn-primary HomeBtn" runat="server" Text="Créer un compte" />
                            </div>
                        </div>
                    </div>

                    



                </div>
            </div>

            <div id="Alert" class="alert alert-danger alert-dismissable" runat="server">
                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                <strong>Erreur!</strong><span id="AlertText" runat="server">Nom d'utilisateur ou mot de passe invalide</span> 
            </div>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.11.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/js/bootstrap.min.js"></script>
</body>
</html>
