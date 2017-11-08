var positionActuelle;
var divPosLat;
var divPosLng;
var map;
var pos = null;

function initMap() {
    //Set Map
    map = new google.maps.Map(document.getElementById('GoogleMap'), {
        zoom: 70,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    });

    //service de l'API de Google Maps
    var directionsService = new google.maps.DirectionsService();
    var directionsDisplay = new google.maps.DirectionsRenderer({
        suppressMarkers: true,
    });



    // Create the DIV to hold the control and call the CenterControl()
    // constructor passing in this DIV.
    var centerControlDiv = document.createElement('div');
    var centerControl = new CenterControl(centerControlDiv, map);

    centerControlDiv.index = 1;
    map.controls[google.maps.ControlPosition.TOP_CENTER].push(centerControlDiv);


    //GeoLocalisation
    if (navigator.geolocation) {
        navigator.geolocation.watchPosition(function (position) {
            //defini la position
            pos = getPos(position);

            //Direction
            directionsDisplay.setMap(map);
            directionsDisplay.setPanel(document.getElementById('panel'));

            //definit la requetes a effectuer
            var request = {
                origin: pos.lat + "," + pos.lng,
                destination: destination, /*variable qui contient l'adresse de destination*/
                travelMode: google.maps.DirectionsTravelMode.BICYCLING,
                provideRouteAlternatives: true
            };

            //définit l'URL des markers de depart et de fin
            var icons = {
                start: new google.maps.MarkerImage('../img/marker.png'),
                end: new google.maps.MarkerImage('../img/arrival.png')
            };

            //effectue la requete de destination d'un point A à B
            directionsService.route(request, function (response, status) {
                if (status == google.maps.DirectionsStatus.OK) {
                    directionsDisplay.setDirections(response);
                }

                //fait qqch. Je sais pas trop quoi par contre..... mais utile sinon ça affiche pas les marker
                var leg = response.routes[0].legs[0];
                makeMarker(leg.start_location, icons.start);
                makeMarker(leg.end_location, icons.end);
            });

            //fonction qui crée les marqueur
            function makeMarker(position, icon) {
                new google.maps.Marker({
                    position: position,
                    map: map,
                    icon: icon
                });
            }

        }, function () {
            handleLocationError(true, infoWindow, map.getCenter());
        });
    } else {
        // Browser doesn't support Geolocation
        handleLocationError(false, infoWindow, map.getCenter());
    }


}

function handleLocationError(browserHasGeolocation, infoWindow, pos) {
    infoWindow.setPosition(pos);
    infoWindow.setContent(browserHasGeolocation ?
                          'Error: The Geolocation service failed.' :
                          'Error: Your browser doesn\'t support geolocation.');
}


//retourne la position
function getPos(position) {
    pos = { lat: position.coords.latitude, lng: position.coords.longitude };
    setPos(pos);
    return pos;
}

//ecrit la position dans un hidden input
function setPos(positionActuelle) {
    document.getElementById("hiddenLat").value = positionActuelle.lat;
    document.getElementById("hiddenLng").value = positionActuelle.lng;
}


//bouton du haut
function CenterControl(controlDiv, map) {
    // Set CSS for the control border.
    // Set CSS for the control border.
    var controlUI = document.createElement('div');
    controlUI.style.backgroundColor = 'rgba(255,255,255,0.7)';
    controlUI.style.border = '2px solid #fff';
    controlUI.style.borderRadius = '3px';
    controlUI.style.boxShadow = '0 2px 6px rgba(0,0,0,.3)';
    controlUI.style.cursor = 'pointer';
    controlUI.style.marginBottom = '22px';
    controlUI.style.textAlign = 'center';
    controlUI.title = 'Click to recenter the map';
    controlDiv.appendChild(controlUI);

    // Set CSS for the control interior.
    var controlText = document.createElement('div');
    controlText.style.color = 'rgb(25,25,25)';
    controlText.style.fontFamily = 'Roboto,Arial,sans-serif';
    controlText.style.fontSize = '16px';
    controlText.style.lineHeight = '38px';
    controlText.style.paddingLeft = '5px';
    controlText.style.paddingRight = '5px';
    controlText.innerHTML = 'Moi';
    controlUI.appendChild(controlText);

    // lorsquon click sur Moi (à changer) il met un event qu'à chaque 25ms il recommence
    controlUI.addEventListener('click', function () {
        setInterval(function () {
            var moi = doCenter();
            map.setCenter(moi);
            map.setZoom(17);

        },500);
    });
}

//retourne la position qui est ecrit dans le div | à améliorer.
function doCenter() {
    var positionLat = parseFloat(document.getElementById("hiddenLat").value);
    var positionLng = parseFloat(document.getElementById("hiddenLng").value);
    return { lat: positionLat, lng: positionLng };
}