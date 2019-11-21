<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="TIT.admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script src='https://api.tiles.mapbox.com/mapbox-gl-js/v1.5.0/mapbox-gl.js'></script>
    <link href='https://api.tiles.mapbox.com/mapbox-gl-js/v1.5.0/mapbox-gl.css' rel='stylesheet' />

    <script>
        function sendJson(event) {

            mapboxgl.accessToken = 'pk.eyJ1IjoibmV1bWFubnQiLCJhIjoiY2szNDZpNWg3MGhocjNubGtndnk4dnRmMSJ9.bbmNGULh0MJi1ViUgTcvDA';
            var map = new mapboxgl.Map({
                container: 'map',
                style: 'mapbox://styles/neumannt/ck38irhlb2o2k1cmfnsgqbft5',
                center: [-96, 37.8],
                zoom: 3
            });


            var cookie = document.cookie[GeoJson];
            map.addLayer(cookie);

        };
    </script>
    <asp:Button ID="button_createGeoJson" OnClick="button_createGeoJson_Click" runat="server" Text="Create new GeoJson" />
    <asp:Button ID="button_uploadJson" OnClientClick="sendJson(this)" runat="server" Text="Upload Json" />
</asp:Content>
