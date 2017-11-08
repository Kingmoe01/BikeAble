<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Livraisons.aspx.cs" Inherits="BikeAble.Coursier.Livraisons" EnableEventValidation="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<meta name="viewport" content="width=device-width, initial-scale=1" />
    <title></title>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/css/bootstrap.min.css" />
<link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />  
<link rel="stylesheet" href="../font-awesome/css/font-awesome.min.css"/>   
<link rel="stylesheet" href="../Style/Livraison.css" />
<link rel="stylesheet" href="../Style/GMapCoursier.css" />
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
                <div class="btn-toolbar">
                    <asp:Button ID="Button1" CssClass="btn btn-primary BarBtnLeft" runat="server" Text="Livraisons Disponible" />
                    <asp:Button ID="options" CssClass="btn btn-primary BarBtnMiddle BarBtn " runat="server" Text="Options" OnClick="options_Click" />
                    <asp:Button ID="friends" CssClass="btn btn-primary BarBtnMiddle BarBtn " runat="server" Text="Amis" OnClick="friends_Click" />
                    <asp:Button ID="Button4" CssClass="btn btn-primary BarBtnRight BarBtn " runat="server" Text="Déconnexion" OnClick="deconnexion_Click" />
                </div>
            </div>
            <div class="BoxWrapper">
                <div class="Bluebox">
                    <div class="row">
                        <div class="col-lg-12">
                            <asp:GridView ID="tblLivraison"
                                DataKeyNames="LivraisonID"
                                runat="server"
                                AllowPaging="true"
                                PageSize="10"
                                EmptyDataText="Aucune Livraisons"
                                OnRowDataBound="tblLivraison_RowDataBound"
                                OnSelectedIndexChanged="tblLivraison_SelectedIndexChanged"
                                OnPageIndexChanged="tblLivraison_PageIndexChanged" OnRowCommand="tblLivraison_RowCommand"
                                AutoGenerateColumns="false"
                                ShowHeaderWhenEmpty="True"
                                CssClass="mydatagrid"
                                PagerStyle-CssClass="pager"
                                HeaderStyle-CssClass="header"
                                RowStyle-CssClass="rows">
                                <Columns>
                                    <asp:BoundField DataField="Distance" HeaderText="Distance" />
                                    <asp:BoundField DataField="Grosseur" HeaderText="Grosseur" />
                                    <asp:BoundField DataField="Prix" HeaderText="Prix" />
                                    <asp:TemplateField HeaderText="Détails">
                                        <ItemTemplate>
                                            <asp:LinkButton CssClass="btn btn-sm BtnDetail" ID="BtnDétail" runat="server" CommandName="DetailLivraison" Text="Détails" CommandArgument='<%#Eval("LivraisonID") %>'><span class="fa fa-info-circle" aria-hidden="true"></span></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12" id="ColMap">
                            <div id="GoogleMap"></div> <!--Map-->
                        </div>
                    </div>
                    <div class="row">
                        <asp:Button ID="ModeVelo" CssClass="btn btn-primary" runat="server" Text="Mode Vélo" OnClick="ModeVelo_Click" />
                    </div>
                </div>

                <div id="Alert" class="alert alert-danger alert-dismissable" runat="server">
                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                    <strong>Erreur!</strong><span id="AlertText" runat="server"> Vous devez réserver une livraison avant de pouvoir y accéder</span>
                </div>

                <div class="row">
                    <footer id="Footer"><span>@Bike Able -Term of Use- -Contact Us-</span></footer>
                </div>
            </div>
            
        </div>
        <input id="hiddenLat" type="hidden" runat="server"/>
        <input id="hiddenLng" type="hidden" runat="server"/>
    </form>
    <script> var destination = "<%=GetDestination()%>";</script>
    <script src="../scripts/googlemaps.js"></script>
    <script async defer src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCKT1an_V-Lxn_tKTVULovEa2arGAJK_4g&callback=initMap"></script>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.11.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/js/bootstrap.min.js"></script>
</body>
</html>
