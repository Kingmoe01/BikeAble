<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin-Master.Master" AutoEventWireup="true" CodeBehind="AdminSettings.aspx.cs" Inherits="BikeAble.Admin.AdminSettings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div id="BlueBox" class="container">
            <div class="row padding5">
                <div class="col-md-12">
                    <span>Modification des tarifs de livraison</span>
                </div>
                <div class="col-md-6">
                    Tarif initial d'une lettre: 
                </div>
                <div class="col-md-6">
                    <asp:TextBox CssClass="InputW" ID="tarifLettre" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    Tarif initial d'un petit colis: 
                </div>
                <div class="col-md-6">
                    <asp:TextBox CssClass="InputW" ID="tarifPetit" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    Tarif initial d'un moyen colis: 
                </div>
                <div class="col-md-6">
                    <asp:TextBox CssClass="InputW" ID="tarifMoyen" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    Tarif initial d'un gros colis: 
                </div>
                <div class="col-md-6">
                    <asp:TextBox CssClass="InputW" ID="tarifGros" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    Tarif de livraison en fonction du kilometrage ($/KM): 
                </div>
                <div class="col-md-6">
                    <asp:TextBox CssClass="InputW" ID="tarifKM" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <asp:Button ID="validateChange" OnClick="tarifChange_OnClick"  runat="server" Text="Valider les changements"></asp:Button>
                </div>

                <div id="Alert" class="alert alert-danger alert-dismissable" runat="server">
                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                    <strong>Erreur!</strong><span id="AlertText" runat="server">Les champs ne peuvent que contenir des valeurs numériques.</span> 
                </div>
                 
            </div>
        </div>
    </div>
</asp:Content>
