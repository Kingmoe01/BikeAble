<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="BikeAble.Admin.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jasny-bootstrap/3.1.3/css/jasny-bootstrap.min.css" />
    <link rel="stylesheet" href="../font-awesome/css/font-awesome.min.css" />
    <link rel="stylesheet" href="../Style/AdminLogin.css" />
    <title>Admin</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="Titre">
                <h1>Bike Able</h1>
            </div>
            <div class="GrayBox">
                <div class="Margin">
                    <div class="row Padding5">
                        <div class="col-sm-5 AR">Nom d'utilisateur :</div>
                        <div class="col-sm-7 AL">
                            <asp:TextBox CssClass="InputW" ID="txtUser" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup='login' CssClass="red" runat="server" ControlToValidate="txtUser" Text="*" />
                        </div>
                    </div>
                    <div class="row Padding5">
                        <div class="col-sm-5 AR">Mot de passe :</div>
                        <div class="col-sm-7 AL">
                            <asp:TextBox CssClass="InputW" ID="TxtPWD" type="password" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup='login' CssClass="red" runat="server" ControlToValidate="txtUser" Text="*" />
                        </div>
                    </div>
                    <div class="row Padding5">
                        <div class="col-sm-5 AR"></div>
                        <div class="col-sm-7 AL">
                            <asp:Button OnClick="Login_Click" ValidationGroup='login' ID="login" CssClass="btn btn-primary HomeBtn" runat="server" Text="S'identifier" />
                        </div>
                    </div>
                </div>
            </div>


            <div id="Alert" class="alert alert-danger alert-dismissable" runat="server">
                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                <strong>Erreur! </strong><span id="AlertText" runat="server">Nom d'utilisateur ou mot de passe invalide</span> 
            </div>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.11.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/js/bootstrap.min.js"></script>
</body>
</html>
