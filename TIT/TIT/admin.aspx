<%@ Page Title="Admin" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="TIT.admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script src='https://api.tiles.mapbox.com/mapbox-gl-js/v1.5.0/mapbox-gl.js'></script>
    <link href='https://api.tiles.mapbox.com/mapbox-gl-js/v1.5.0/mapbox-gl.css' rel='stylesheet' />

    <div id='map' style='width: 100%; height: 600px;'></div>

    <script>

        mapboxgl.accessToken = 'pk.eyJ1IjoibmV1bWFubnQiLCJhIjoiY2szNDZpNWg3MGhocjNubGtndnk4dnRmMSJ9.bbmNGULh0MJi1ViUgTcvDA';
        var map = new mapboxgl.Map({
            container: 'map',
            style: 'mapbox://styles/neumannt/ck38irhlb2o2k1cmfnsgqbft5'
        });

        map.on('style.load', function () {
            var cookie = getCookie('GeoJson');

            if (cookie == "") {

                //alert('FEHLER');

            } else {

                sendJson();
            }
        });

        function sendJson() {

            var cookie = getCookie('GeoJson');
            var obj = JSON.parse(cookie);

            map.addSource('Stations', {
                'type': 'geojson',
                'data': obj
            });

            //map.addLayer({
            //    "id": "Stations",
            //    "type": "circle",
            //    "source": "Stations",
            //    "paint": {
            //        "circle-radius": 6,
            //        "circle-color": "#B42222"
            //    },
            //    "filter": ["==", "$type", "Point"],
            //});

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
        }
    </script>

    <asp:Button ID="button_createGeoJson" OnClick="button_createGeoJson_Click" runat="server" Text="Create new GeoJson" />
    <%--<asp:Button ID="button_uploadJson" OnClientClick="sendJson(this)" runat="server" Text="Upload Json"/>--%>
    <button id="button_uploadJson" onclick="sendJson(this)" title="Upload Json">Upload Json</button>
</asp:Content>
