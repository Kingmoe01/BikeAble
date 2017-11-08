<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Détails.aspx.cs" Inherits="BikeAble.Coursier.Détails" EnableEventValidation="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Détails</title>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/css/bootstrap.min.css" />
<link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />  
<link rel="stylesheet" href="../Style/Détails.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div id="TitleDiv">
                    <h1>Bike Able</h1>
                </div>
            </div>
            <div class="row">
                    <div id="Bluebox" class="container">
                        <div class="row">
                            <div class="col-sm-6 AR"><span class="Header">Adresse de livraison</span></div>
                            <div class="col-sm-6 AL"><span id="AdresseLivraison" runat="server"></span></div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6 AR"><span class="Header">Adresse de départ</span></div>
                            <div class="col-sm-6 AL"><span id="AdresseDépart" runat="server"></span></div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6 AR"><span class="Header">Grosseur du colis</span></div>
                            <div class="col-sm-6 AL"><span id="GrosseurColis" runat="server"></span></div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6 AR"><span class="Header">Distance</span></div>
                            <div class="col-sm-6 AL"><span id="Distance" runat="server"></span></div>
                        </div>
                    </div>
                </div>
            <div class="row">
                <div class="btn-group">
                    <asp:Button OnClick="RéserverBtn_Click" ID="RéserverBtn" CssClass="btn btn-primary btnleft" runat="server" Text="Réserver" />
                    <asp:Button OnClick="RetourBtn_Click" ID="RetourBtn" CssClass="btn btn-primary btnright" runat="server" Text="Retour" />
                    <input type="hidden" id="IDcommande" runat="server"/>
                    <input type="hidden" id="IDCoursier" runat="server"/>
                    <input type="hidden" id="IDLivraison" runat="server"/>
                </div>
            </div>
            <div id="Alert" class="alert alert-danger alert-dismissable" runat="server">
                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                <strong>Erreur!</strong><span id="AlertText" runat="server"> Vous avez déja une réservation</span> 
            </div>
            <div class="row"><footer id="Footer"><span>@Bike Able -Term of Use- -Contact Us-</span></footer></div>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.11.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/js/bootstrap.min.js"></script>
</body>
</html>
