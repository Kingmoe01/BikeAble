<%@ Page Title="" Language="C#" MasterPageFile="~/Client/Client-Master.Master" AutoEventWireup="true" CodeBehind="Friends.aspx.cs" Inherits="BikeAble.Client.Friends" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../Style/Friends.css"/> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
            <div id="TitleDiv">
                <h1>Bike Able</h1>
            </div>
        </div>
        <div class="row">
            <div class="btn-toolbar">
                <asp:Button ID="actual" CssClass="btn btn-primary BarBtnLeft" runat="server" Text="Mes amis" OnClick="actual_Click" />
                <asp:Button ID="pending" CssClass="btn btn-primary BarBtnRight BarBtn " runat="server" Text="Amis en attentes" OnClick="pending_Click"/>
            </div>
        </div>
        <div runat="server" class="row" id="tableAmis" visible="false">
            <div class="col-lg-6">
                <asp:GridView ID="tbFriendsPending" 
                DataKeyNames="ID_User"
                runat="server" 
                AllowPaging="true" 
                PageSize="10" 
                EmptyDataText="Aucune Demande en attente"
                OnSelectedIndexChanged="tbFriendsPending_SelectedIndexChanged"
                OnPageIndexChanged="tbFriendsPending_PageIndexChanged" OnRowCommand="tbFriendsPending_RowCommand"
                AutoGenerateColumns="false" 
                ShowHeaderWhenEmpty="True" 
                CssClass="mydatagrid"
                PagerStyle-CssClass="pager" 
                HeaderStyle-CssClass="header" 
                RowStyle-CssClass="rows">
                <Columns>
                    <asp:BoundField DataField="NomEtPrenom" HeaderText="En attente" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="buttAdd" runat="server" CommandName="GererAmi" Text="Accepter" CommandArgument='<%#Eval("ID_User") %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </div>
        </div>
        <div class="row">
            <div id="BlueBox" class="container">
                <div class="row padding5">
                    <div class="col-md-6 AR">
                        Mes amis :
                    </div>
                    <div class="col-md-6 AL">
                        <asp:DropDownList  CssClass="InputW"  ID="friends" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="row padding5">
                    <div class="col-md-6 AR">
                        Nouvel ami :
                    </div>
                    <div class="col-md-6 AL">
                        <asp:TextBox title="Entrer l'ardresse email de la personne" CssClass="InputW" ID="newFriends" runat="server" onkeyup="isFriendsExists(this)" ></asp:TextBox> <img src="../img/none.jpg" id="isOk" />
                    </div>
                </div>
                <div class="row padding5">
                    <div class="col-md-6"></div>
                    <div class="col-md-6 ButtonsCenter">
                        <div class="btn-group">
                                <asp:Button ID="Annuler" CssClass="btn btn-primary BarBtnLeft" runat="server" Text="Annuler" OnClick="Annuler_Click" />
                                <asp:Button ID="Ajouter" CssClass="btn btn-primary BarBtnRight BarBtn" runat="server" Text="Ajouter" OnClick="Ajouter_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div id="Alert" class="alert alert-danger alert-dismissable" runat="server">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
            <strong>Erreur!</strong><span id="AlertText" runat="server">Le courriel est invalide</span> 
        </div>

    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
    <script src="../scripts/friends.js"></script>
</asp:Content>
