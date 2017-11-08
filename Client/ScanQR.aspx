<%@ Page Title="" Language="C#" MasterPageFile="~/Client/Client-Master.Master" AutoEventWireup="true" CodeBehind="ScanQR.aspx.cs" Inherits="BikeAble.Client.ScanQR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../Style/GestionLivraison.css"/> 
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
                <h2>Scan du code QR</h2>
            </div>
            <div class="row padding5">
                <input id="input" type="file"  onchange="previewFile();" />
                <label id="Filelabel" for="input"><strong>Choisir le code QR ...</strong></label>
            </div>
            <div class="row padding5">
                <img id="picture" src="" height="250" alt="Image preview..."/>
            </div>
            <div class="row padding5">
                <asp:Button ID="decode" OnClick="Decode_Click" OnClientClick="DecodeQR(); return false;" runat="server" Text="Terminer la livraison" CssClass="btn btn-primary" />                        
            </div>
            <div class="row padding5">
                <p>Il est important de seulement scanner le colis quand il est livré</p>                
            </div>
            <div class="row padding5">
                <p>Scanner le code permettra a Bike Able de savoir que le colis à été livré</p>
            </div>
            <div class="row padding5">
                <asp:Button ID="Retour" CssClass="btn btn-primary" runat="server" Text="Retour" OnClick="Retour_Click" />
                <input name="HiddenID" id="ID_QR" runat="server" type="hidden" />
            </div>
        </div>
    </div>
    <div class="row">
        <div id="Alert" class="alert alert-danger alert-dismissable" runat="server">
                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                <strong>Erreur!</strong><span id="AlertText" runat="server">Nom d'utilisateur ou mot de passe invalide</span> 
            </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
    <script src="../scripts/qrcode.min.js"></script>
    <script type="text/javascript" src="../scripts/QRJz/grid.js"></script>
    <script type="text/javascript" src="../scripts/QRJz//version.js"></script>
    <script type="text/javascript" src="../scripts/QRJz//detector.js"></script>
    <script type="text/javascript" src="../scripts/QRJz//formatinf.js"></script>
    <script type="text/javascript" src="../scripts/QRJz//errorlevel.js"></script>
    <script type="text/javascript" src="../scripts/QRJz//bitmat.js"></script>
    <script type="text/javascript" src="../scripts/QRJz//datablock.js"></script>
    <script type="text/javascript" src="../scripts/QRJz//bmparser.js"></script>
    <script type="text/javascript" src="../scripts/QRJz//datamask.js"></script>
    <script type="text/javascript" src="../scripts/QRJz//rsdecoder.js"></script>
    <script type="text/javascript" src="../scripts/QRJz//gf256poly.js"></script>
    <script type="text/javascript" src="../scripts/QRJz//gf256.js"></script>
    <script type="text/javascript" src="../scripts/QRJz//decoder.js"></script>
    <script type="text/javascript" src="../scripts/QRJz//qrcode.js"></script>
    <script type="text/javascript" src="../scripts/QRJz//findpat.js"></script>
    <script type="text/javascript" src="../scripts/QRJz//alignpat.js"></script>
    <script type="text/javascript" src="../scripts/QRJz//databr.js"></script>

     <script type="text/javascript" src="../scripts/ScanQR.js"></script>
</asp:Content>
