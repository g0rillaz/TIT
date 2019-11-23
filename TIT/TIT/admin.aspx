<%@ Page Title="Admin" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="TIT.admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script src='https://api.tiles.mapbox.com/mapbox-gl-js/v1.5.0/mapbox-gl.js'></script>
    <link href='https://api.tiles.mapbox.com/mapbox-gl-js/v1.5.0/mapbox-gl.css' rel='stylesheet' />

    <style>
        .mapboxgl-popup {
            max-width: 400px;
            font: 12px/20px 'Helvetica Neue', Arial, Helvetica, sans-serif;
        }
    </style>

    <div id='map' style='width: 100%; height: 600px;'></div>

    <script>

        mapboxgl.accessToken = 'pk.eyJ1IjoibmV1bWFubnQiLCJhIjoiY2szNDZpNWg3MGhocjNubGtndnk4dnRmMSJ9.bbmNGULh0MJi1ViUgTcvDA';
        var map = new mapboxgl.Map({
            container: 'map',
            style: 'mapbox://styles/neumannt/ck38irhlb2o2k1cmfnsgqbft5'
        });

        map.on('load', function () {

            var cookie = getCookie('GeoJson');

            if (cookie == "") {

                alert('FEHLER');

            } else {

                sendJson();
                createPopup();
            }
        });

        //Functions
        function createPopup() {

            var popup = new mapboxgl.Popup({
                closeButton: false,
                closeOnClick: true
            });

            map.on('mouseenter', 'Stations', function (e) {
                // Change the cursor style as a UI indicator.
                map.getCanvas().style.cursor = 'pointer';

                var coordinates = e.features[0].geometry.coordinates.slice();
                var htmlinfo = "<p>Station: " + e.features[0].properties.name + "</p><p>Country: " + e.features[0].properties.country + "</p><p>Latitude: " + e.features[0].properties.latitude + "</p><p>Longitude: " + e.features[0].properties.longitude + "</p>";

                // Ensure that if the map is zoomed out such that multiple
                // copies of the feature are visible, the popup appears
                // over the copy being pointed to.
                while (Math.abs(e.lngLat.lng - coordinates[0]) > 180) {
                    coordinates[0] += e.lngLat.lng > coordinates[0] ? 360 : -360;
                }

                // Populate the popup and set its coordinates
                // based on the feature found.
                popup.setLngLat(coordinates)
                    .setHTML(htmlinfo)
                    .addTo(map);
            });

            map.on('mouseleave', 'places', function () {
                map.getCanvas().style.cursor = '';
                popup.remove();
            });

        };

        function sendJson() {

            var cookie = getCookie('GeoJson');
            var obj = JSON.parse(cookie);

            map.addSource('Stations', {
                'type': 'geojson',
                'data': obj
            });

            map.addLayer({
                "id": "Stations",
                "type": "circle",
                "source": "Stations",
                "paint": {
                    "circle-radius": 6,
                    "circle-color": "#B42222"
                },
                "filter": ["==", "$type", "Point"],
            });

            map.addLayer({
                "id": "Area",
                "type": "fill",
                "source": "Stations",
                "paint": {
                    "fill-color": "#B42222",
                    "fill-opacity": 0.8
                },
                "filter": ["==", "$type", "Polygon"],
            });

        };

        function getCookie(cname) {
            var name = cname + "=";
            var decodedCookie = decodeURIComponent(document.cookie);
            var ca = decodedCookie.split(';');
            for (var i = 0; i < ca.length; i++) {
                var c = String(ca[i]);
                while (c.charAt(0) == ' ') {
                    c = String(c.substring(1));
                }
                if (c.indexOf(name) == 0) {
                    return String(c.substring(name.length, c.length));
                }
            }
            return "";
        };
    </script>

    <asp:Button ID="button_createGeoJson" OnClick="button_createGeoJson_Click" runat="server" Text="Create new GeoJson" />
    <%--<asp:Button ID="button_uploadJson" OnClientClick="sendJson(this)" runat="server" Text="Upload Json"/>--%>
    <%--<button id="button_uploadJson" onclick="sendJson(this)" title="Upload Json">Upload Json</button>--%>
</asp:Content>
