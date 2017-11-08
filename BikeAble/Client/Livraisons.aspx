<%@ Page Title="" Language="C#" MasterPageFile="~/Client/Client-Master.Master" AutoEventWireup="true" CodeBehind="Livraisons.aspx.cs" Inherits="BikeAble.Client.Livraison" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../font-awesome/css/font-awesome.min.css"/>  
    <link rel="stylesheet" href="../Style/Livraison.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div id="TitleDiv">
                <h1>Bike Able</h1>
            </div>
        </div>
        <div class="row">
            <div class="btn-toolbar">
                <asp:Button ID="myLivraison" CssClass="btn btn-primary BarBtnLeft" runat="server" Text="Livraisons" />
                <asp:Button ID="createLivr" CssClass="btn btn-primary BarBtnMiddle BarBtn " runat="server" Text="Créer une livraison" OnClick="createLivr_Click"/>
                <asp:Button ID="optionButt" CssClass="btn btn-primary BarBtnMiddle BarBtn " runat="server" Text="Options" OnClick="optionButt_Click" />
                <asp:Button ID="friends" CssClass="btn btn-primary BarBtnMiddle BarBtn " runat="server" Text="Amis" OnClick="friends_Click" />
                <asp:Button ID="deconexion" CssClass="btn btn-primary BarBtnRight BarBtn " runat="server" Text="Déconnexion" OnClick="deconnexion_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                    <asp:GridView ID="tblLivraison" 
                        DataKeyNames="ID"
                        runat="server" 
                        AllowPaging="true" 
                        PageSize="30" 
                        EmptyDataText="Aucune Livraisons" 
                        OnRowDataBound="tblLivraison_RowDataBound" 
                        OnSelectedIndexChanged="tblLivraison_SelectedIndexChanged" 
                        OnPageIndexChanged="tblLivraison_PageIndexChanged" OnRowCommand="tblLivraison_RowCommand"
                        AutoGenerateColumns="false" 
                        ShowHeaderWhenEmpty="True" 
                        CssClass="mydatagrid"
                        PagerStyle-CssClass="pager" 
                        HeaderStyle-CssClass="header" 
                        RowStyle-CssClass="rows" 
                        >
                        <Columns>
                            <asp:BoundField DataField="Nom" HeaderText="Livraison" />
                            <asp:BoundField DataField="Status" HeaderText="Statut" />
                            <asp:BoundField DataField="DateCreation" HeaderText="Heure de création" />
                            <asp:TemplateField HeaderText="Gérer">
                                <ItemTemplate>
                                     <asp:LinkButton CssClass="btn btn-sm BtnDetail" ID="buttGerer" runat="server" CommandName="GererLivraison" Text="Détails" CommandArgument='<%#Eval("ID") %>'><span class="fa fa-cog" aria-hidden="true"></span></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
            </div>
        </div>
        <div class="row">
                <asp:LinkButton  OnClick="ScanQR_Click" CssClass="btn btn-sm" ID="ScanQR" runat="server">Scan QR <span class="fa fa-camera" aria-hidden="true"></span></asp:LinkButton>
        </div>
    </div>
</asp:Content>
