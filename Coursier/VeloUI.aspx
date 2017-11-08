<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VeloUI.aspx.cs" Inherits="BikeAble.Coursier.VeloUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<meta name="viewport" content="width=device-width, initial-scale=1" />
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/css/bootstrap.min.css" />
<link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" /> 
<link rel="stylesheet" href="../Style/VeloUI.css" />
    <title>Coursier</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div id="Background"></div>
            <div class="WrapWarning" id="Warning"><span class="Warning">L'écran doit être placé Horizontalement</span></div>
            <div class="WrapWarning" id="Warning2"><span class="Warning">Vous devez utilisez un appareil mobile</span> </div>
                <div class="row">
                    <div class="col-3">
                        <div class="row">
                            <div id="TitleDiv" class="MarginLeft">
                                <h1>Bike Able</h1>
                            </div>
                        </div>
                        <div class="row">
                            <asp:Button ID="Button1" CssClass="btn btn-primary MarginLeft" runat="server" Text="Livraisons" />
                        </div>
                        <div class="row">
                            <div id="InfoBox" class="container">
                                <div class="col-12" id="InfoBoxTitle">Info</div>
                                <div class="col-12">km/h</div>
                                <div class="col-12">Restant</div>
                                <div class="col-12">Arrivé :</div>
                            </div>
                        </div>
                    </div>
                    <div class="col-9" id="ColMap">
                        <div id="GoogleMap"></div>
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


<!--  -->