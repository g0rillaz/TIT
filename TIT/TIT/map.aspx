<%@ Page Title="Map" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="map.aspx.cs" Inherits="TIT.map" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src='https://api.mapbox.com/mapbox-gl-js/v1.4.1/mapbox-gl.js'></script>
    <link href='https://api.mapbox.com/mapbox-gl-js/v1.4.1/mapbox-gl.css' rel='stylesheet' />

    <div id='map' style='width: 100%; height: 600px;'></div>
    <script>
        mapboxgl.accessToken = 'pk.eyJ1IjoibmV1bWFubnQiLCJhIjoiY2szNDZpNWg3MGhocjNubGtndnk4dnRmMSJ9.bbmNGULh0MJi1ViUgTcvDA';
        var map = new mapboxgl.Map({
            container: 'map',
            style: 'mapbox://styles/mapbox/streets-v11'
        });
    </script>

</asp:Content>
