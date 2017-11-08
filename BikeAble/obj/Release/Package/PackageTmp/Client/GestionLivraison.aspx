<%@ Page Title="" Language="C#" MasterPageFile="~/Client/Client-Master.Master" AutoEventWireup="true" CodeBehind="GestionLivraison.aspx.cs" Inherits="BikeAble.Client.GestionLivraison" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../font-awesome/css/font-awesome.min.css"/>  
    <link rel="stylesheet" href="../Style/GestionLivraison.css" />
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
                    <div class="col-md-6"></div>
                    <div class="col-md-6 ButtonsCenter">
                        <div class="btn-toolbar">
                            <asp:Button ID="depart" OnClick="depart_Click" CssClass="btn btn-primary BarBtnLeft" runat="server" Text="Départ" />
                            <asp:Button ID="arriver" OnClick="arriver_Click" CssClass="btn btn-primary BarBtnRight BarBtn " runat="server" Text="Arriver" />
                            <asp:LinkButton ID="swap" runat="server" OnClick="switch_Click" CssClass="btn btn-sm BtnDetail"><span class="fa fa-exchange" aria-hidden="true"/></asp:LinkButton>
                            <input type="hidden" id="swapValue" runat="server"/>
                        </div>
                    </div>
                </div>


                <div class="row padding5">
                    <div class="col-md-6 AR">
                        Nom de la Livraison :
                    </div>
                    <div class="col-md-6 AL">
                        <asp:TextBox CssClass="InputW" ID="NomLivraison" runat="server"></asp:TextBox>
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

                <div id="personBox" visible="false" runat="server">
                    <div class="row padding5">
                        <div class="col-md-6 AR">
                            Personne :
                        </div>
                        <div class="col-md-6 AL">
                            <asp:DropDownList  CssClass="InputW"  ID="person" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                <!--Changer le nom Personne pour quelque chose de mieux-->
                </div>

                <div class="row padding5">
                    <div class="col-md-6"></div>
                    <div class="col-md-6 ButtonsCenter">
                        <div class="btn-toolbar">
                                <asp:Button ID="Annuler" OnClick="Annuler_Click" CssClass="btn btn-primary BarBtnLeft" runat="server" Text="Annuler" />
                                <asp:Button ID="Sauvegarder" OnClick="Sauvegarder_Click" CssClass="btn btn-primary BarBtnMiddle BarBtn " runat="server" Text="Sauvegarder" />
                                <asp:Button ID="Supprimmer" OnClick="Supprimmer_Click" CssClass="btn btn-primary BarBtnRight BarBtn " runat="server" Text="Supprimer" />
                                <input type="hidden" id="TxtCommandeID" runat="server"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="Alert" class="alert alert-danger alert-dismissable" runat="server">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
            <strong>Erreur!</strong><span id="AlertText" runat="server"> Vous devez changer votre adresse pour modifier l'adresse de départ !</span> 
        </div>
</asp:Content>
