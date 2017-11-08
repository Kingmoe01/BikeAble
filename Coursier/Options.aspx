<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Options.aspx.cs" Inherits="BikeAble.Coursier.Options" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Options</title>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/css/bootstrap.min.css" />
<link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />  
<link rel="stylesheet" href="../Style/Options.css" />

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
                <div id="BlueBox" class="container">
                    <div class="row">
                        <div class="col-lg-6">
                            <div id="OrangeBox">
                                <div class="Header">
                                    <div id="Distance">
                                        Limite de Distance :
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div id="Distance-range"></div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <div id="OrangeBox1">
                                <div class="Header">
                                    <div id="Grosseur">
                                        Limite de Grosseur :
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div id="Grosseur-range"></div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6"></div>
                        <div class="col-lg-6 ButtonsCenter">
                            <div class="btn-group">
                                <asp:Button ID="Sauvegarder" CssClass="btn btn-primary BarBtnLeft" runat="server" Text="Sauvegarder" OnClick="Sauvegarder_Click" />
                                <asp:Button ID="Annuler" CssClass="btn btn-primary BarBtnMiddle BarBtn" runat="server" Text="Annuler" OnClick="Annuler_Click" />
                                <asp:Button ID="ParamAvancé" CssClass="btn btn-primary BarBtnRight BarBtn" runat="server" Text="Paramètres avancés" OnClick="ParamAvancé_Click" />
                            </div>
                        </div>
                    </div>
                    <div id="UpdateBtn" class="row">

                    </div>
                </div>
                
            </div>
            <div class="row">
                <footer id="Footer"><span>@Bike Able -Term of Use- -Contact Us-</span></footer>
            </div>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jqueryui-touch-punch/0.2.3/jquery.ui.touch-punch.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.11.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/js/bootstrap.min.js"></script>
    <script src="../scripts/Sliders.js"></script>
</body>
</html>
