﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin-Master.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="BikeAble.Admin.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../Style/Admin.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="row" id="BlackBox">
            <div  class="AL">
                <span>Vos tarifs de livraison actifs</span>
                    <div class="row padding5">
                    <div class="col-md-6 AR">
                        Tarif en fonction du kilométrage:
                    </div>
                        <asp:Label id="tarifKM" runat="server"></asp:Label>
                    <div class="col-md-6 AR">
                        Tarif de base pour une lettre:
                    </div>
                        <asp:Label id="tarifLettre" runat="server"></asp:Label>
                    <div class="col-md-6 AR">
                        Tarif de base pour un petit colis:
                    </div>
                        <asp:Label id="tarifPetit" runat="server"></asp:Label>
                    <div class="col-md-6 AR">
                        Tarif de base pour un colis moyen:
                    </div>
                        <asp:Label id="tarifMoyen" runat="server"></asp:Label>
                    <div class="col-md-6 AR">
                        Tarif de base pour un gros colis:
                    </div>
                        <asp:Label id="tarifGros" runat="server"></asp:Label>
                    
                </div>
            </div>
        </div>
    </div>
</asp:Content>
