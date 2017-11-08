<%@ Page Title="" Language="C#" MasterPageFile="~/Client/Client-Master.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="BikeAble.GlobalPages.SignUp" %>
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
                        Prénom :
                    </div>
                    <div class="col-md-6 AL">
                        <asp:TextBox CssClass="InputW" ID="FirstName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup='SignUpValid' CssClass="red" runat="server" ControlToValidate="FirstName" ErrorMessage="Prénom" Text="*" />
                    </div>
                </div>
                <div class="row padding5">
                    <div class="col-md-6 AR">
                        Nom :
                    </div>
                    <div class="col-md-6 AL">
                        <asp:TextBox CssClass="InputW" ID="LastName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup='SignUpValid' CssClass="red" runat="server" ControlToValidate="LastName" ErrorMessage="Nom" Text="*" />
                    </div>
                </div>
                <div class="row padding5">
                    <div class="col-md-6 AR">
                        Email :
                    </div>
                    <div class="col-md-6 AL">
                        <asp:TextBox CssClass="InputW" ID="EmailUser" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup='SignUpValid' CssClass="red" runat="server" ControlToValidate="EmailUser" ErrorMessage="Email" Text="*" />
                    </div>
                </div>
                <div class="row padding5">
                    <div class="col-md-6 AR">
                        Mot de Passe :
                    </div>
                    <div class="col-md-6 AL">
                        <asp:TextBox CssClass="InputW" ID="MDP" runat="server" type="password"></asp:TextBox>
                    </div>
                </div>
                <div class="row padding5">
                    <div class="col-md-6 AR">
                        No :
                    </div>
                    <div class="col-md-6 AL">
                        <asp:TextBox CssClass="InputW" ID="Adresse" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup='SignUpValid' CssClass="red" runat="server" ControlToValidate="Adresse" Text="*" ErrorMessage="Adresse" />
                    </div>
                </div>
                <div class="row padding5">
                    <div class="col-md-6 AR">
                        Rue :
                    </div>
                    <div class="col-md-6 AL">
                        <asp:TextBox CssClass="InputW" ID="Rue" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup='SignUpValid' CssClass="red" runat="server" ControlToValidate="Rue" Text="*" ErrorMessage="Rue" />
                    </div>
                </div>
                <div class="row padding5">
                    <div class="col-md-6 AR">
                        App. :
                    </div>
                    <div class="col-md-6 AL">
                        <asp:TextBox CssClass="InputW" ID="App" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row padding5">
                    <div class="col-md-6 AR">
                        Ville :
                    </div>
                    <div class="col-md-6 AL">
                        <asp:TextBox CssClass="InputW" ID="Ville" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup='SignUpValid' CssClass="red" runat="server" ControlToValidate="Ville" Text="*"  ErrorMessage="Ville"/>
                    </div>
                </div>
                <div class="row padding5">
                    <div class="col-md-6 AR">
                        Province :
                    </div>
                    <div class="col-md-6 AL">
                        <asp:TextBox CssClass="InputW" ID="Province" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup='SignUpValid' CssClass="red" runat="server" ControlToValidate="Province" Text="*" ErrorMessage="Province" />
                    </div>
                </div>
                <div class="row padding5">
                    <div class="col-md-6 AR">
                        Code postale :
                    </div>
                    <div class="col-md-6 AL">
                        <asp:TextBox CssClass="InputW" ID="CodePost" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup='SignUpValid' CssClass="red" runat="server" ControlToValidate="CodePost" Text="*" ErrorMessage="Code Postal" />
                    </div>
                </div>
                <div class="row padding5">
                    <div class="col-md-6 AR">
                        Numéro de téléphone :
                    </div>
                    <div class="col-md-6 AL">
                        <asp:TextBox CssClass="InputW" ID="TelNum" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup='SignUpValid' CssClass="red" runat="server" ControlToValidate="TelNum"  ErrorMessage="Numéro de tééphone" Text="*" />
                    </div>
                </div>
                <div class="row padding5">
                    <div class="col-md-6"></div>
                    <div class="col-md-6 ButtonsCenter">
                        <div class="btn-group">
                                <asp:Button ID="Annuler" OnClick="Annuler_Click" CssClass="btn btn-primary BarBtnLeft" runat="server" Text="Annuler" />
                                <asp:Button OnClick="Terminer_Click" ValidationGroup="SignUpValid" ID="Terminer" CssClass="btn btn-primary BarBtnRight BarBtn " runat="server" Text="Terminer" />
                        </div>
                    </div>
                </div>

                <div class="row padding5">
                    <div class="col-md-12">
                        <asp:ValidationSummary ID="vsSummary" ValidationGroup='SignUpValid' CssClass="alert alert-danger " runat="server" HeaderText="Il manque des informations afin de créer votre compte!" />
                     </div>
                </div>
            </div>
        </div>
</asp:Content>
