<%@ Page Title="" Language="C#" MasterPageFile="~/Client/Client-Master.Master" AutoEventWireup="true" CodeBehind="CodeQR.aspx.cs" Inherits="BikeAble.Client.CodeQR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../Style/GestionLivraison.css"/> 
    <link rel="stylesheet" href="../font-awesome/css/font-awesome.min.css"/>    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div id="TitleDiv">
            <h1>Bike Able</h1>
        </div>
    </div>
    <div class="row">
        <div id="BlueBox" class="container">
            <div class="row padding5">
                <h2>Voici votre code QR</h2>
            </div>
            <div class="row padding5">
                <div id="qrcode"></div>
            </div>
             <div id="PasswordAlert" runat="server" class="row padding5"><p>Le code suivant doit être transmit seulement au destinataire afin qu'il puisse signaler l'arrivé du colis</p></div>
            <div class="row padding5"><p>Il est important de ne pas dévoiler le code à personne d'autre que le destinataire</p></div>
            <div class="row padding5">
                <div id="PwdBox">                    
                    <p id="TextPwd" runat="server"></p>
                </div>
                <i id="Icon" class="fa fa-clipboard" aria-hidden="true"></i>
            </div>                

            <div class="row padding5">
                <p>Vous devez imprimer ce code QR et le coller sur le colis.</p>                
            </div>
            <div class="row padding5">
                <p>Ce code permettra au destinataire du colis de signaler qu'il a été livré.</p>
            </div>
            <div class="row padding5">
                <asp:Button ID="Retour" CssClass="btn btn-primary" runat="server" Text="Retour" OnClick="Retour_Click" />
                <input id="ID_QR" runat="server" type="hidden" />
            </div>
        </div>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
    <script type="text/javascript" src="../scripts/qrcode.min.js"></script>
    <script type="text/javascript" src="../scripts/code.js"></script>
</asp:Content>
