<%@ Page Title="" Language="C#" MasterPageFile="~/Client/Client-Master.Master" AutoEventWireup="true" CodeBehind="NewLivraison.aspx.cs" Inherits="BikeAble.Client.NewLivraison" %>
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
                    <div class="col-md-6 AR">
                        Nom de la Livraison :
                    </div>
                    <div class="col-md-6 AL">
                        <asp:TextBox CssClass="InputW" ID="NomLivraison" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup='NewLivraisonValid' CssClass="red" runat="server" ControlToValidate="NomLivraison" ErrorMessage="Nom" Text="*" />
                    </div>
                </div>
                <div class="row padding5">
                    <div class="col-md-6 AR">
                        Adresse de Livraison :
                    </div>
                    <div class="col-md-6 AL">
                        <asp:DropDownList  CssClass="InputW"  ID="Destinateur" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Destinateur_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
                <div id="adresseBox" runat="server">



                    <div class="row padding5">
                        <div class="col-md-6 AR">
                            No :
                        </div>
                        <div class="col-md-6 AL">
                            <asp:TextBox CssClass="InputW" ID="no" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup='NewLivraisonValid' CssClass="red" runat="server" ControlToValidate="no" ErrorMessage="Numéro" Text="*" />
                        </div>
                    </div>

                    <div class="row padding5">
                        <div class="col-md-6 AR">
                            App :
                        </div>
                        <div class="col-md-6 AL">
                            <asp:TextBox CssClass="InputW" ID="app" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row padding5">
                        <div class="col-md-6 AR">
                            Rue :
                        </div>
                        <div class="col-md-6 AL">
                            <asp:TextBox CssClass="InputW" ID="street" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup='NewLivraisonValid' CssClass="red" runat="server" ControlToValidate="no" ErrorMessage="Rue" Text="*" />
                        </div>
                    </div>

                    <div class="row padding5">
                        <div class="col-md-6 AR">
                            Code Postal :
                        </div>
                        <div class="col-md-6 AL">
                            <asp:TextBox CssClass="InputW" ID="postalCode" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup='NewLivraisonValid' CssClass="red" runat="server" ControlToValidate="no" ErrorMessage="Code Postal" Text="*" />
                        </div>
                    </div>

                    <div class="row padding5">
                        <div class="col-md-6 AR">
                            Ville :
                        </div>
                        <div class="col-md-6 AL">
                            <asp:TextBox CssClass="InputW" ID="city" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row padding5">
                        <div class="col-md-6 AR">
                            Province :
                        </div>
                        <div class="col-md-6 AL">
                            <asp:TextBox CssClass="InputW" ID="province" runat="server"></asp:TextBox>
                        </div>
                    </div>

                </div>
                <div class="row padding5">
                    <div class="col-md-6 AR">
                        Grosseur du colis :
                    </div>
                    <div class="col-md-6 AL">
                        <asp:DropDownList ID="GrosseurColis" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="row padding5">
                    <div class="col-md-6">
                        
                    </div>
                    <div class="col-md-6">
                       <asp:Button OnClick="Calculer_Click" CssClass="btn btn-sm" Text="Calculer" runat="server" ID="Calculer"/> Total : <span id="prix" runat="server"></span>
                    </div>
                </div>
                <div class="row padding5">
                    <div class="col-md-6"></div>
                    <div class="col-md-6 ButtonsCenter">
                        <div class="btn-group">
                                <asp:Button ID="Annuler" CssClass="btn btn-primary BarBtnLeft" runat="server" Text="Annuler" OnClick="Annuler_Click" />
                                <asp:Button ID="ajouter" ValidationGroup='NewLivraisonValid' CssClass="btn btn-primary BarBtnRight BarBtn " runat="server" Text="Paypal" OnClick="Ajouter_Click" />
                        </div>
                    </div>
                </div>
                <div class="row padding5">
                    <div class="col-md-12">
                        <asp:ValidationSummary ID="vsSummary" ValidationGroup='NewLivraisonValid' CssClass="alert alert-danger " runat="server" HeaderText="Il manque des informations afin de créer votre compte!" />
                     </div>
                </div>
            </div>
        </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
    <script src="../scripts/newAdresse.js"></script>
</asp:Content>
