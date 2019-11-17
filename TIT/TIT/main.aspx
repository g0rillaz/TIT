<%@ Page Title="Startseite" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="TIT.main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container_main">
        <div class="container_message">
            <h1>Willkommen bei TiT - Temperature in Time</h1>
            <h3>Bitte wähle eine Funktion aus</h3>
        </div>
        <div class="flexbox_main">
            <a class="flexboxitem_main" href="graph.aspx">
                <i class="icon_main fas fa-chart-line"></i>
                <h3>Graph</h3>
                <p class="text_info">Erhalten Sie ausführliche Informationen über aller gesammelten Wetterdaten in aussagekräftigen Diagrammen.</p>
            </a>
            <a class="flexboxitem_main" href="map.aspx">
                <i class="icon_main fas fa-map"></i>
                <h3>Map</h3>
                <p class="text_info">Erhalten Sie ausführliche Informationen über aller gesammelten Wetterdaten in einer großen Kartenübersicht.</p>
            </a>
            <a class="flexboxitem_main" href="table.aspx">
                <i class="icon_main fas fa-table"></i>
                <h3>Table</h3>
                <p class="text_info">Erhalten Sie ausführliche Informationen über aller gesammelten Wetterdaten in Tabellenform.</p>
            </a>
        </div>
    </div>
</asp:Content>
