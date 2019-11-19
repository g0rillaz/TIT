<%@ Page Title="Startseite" Language="C#" MasterPageFile="~/Start.Master" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="TIT.main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container_main">
        <div class="container_message">
            <h1>Welcome at TiT - Temperature in Time</h1>
            <h3>Please choose an option or <a href="info.aspx">learn more about TiT</a></h3>
        </div>
        <div class="flexbox_main">
            <a class="flexboxitem_main" href="graph.aspx">
                <i class="icon_main fas fa-chart-line fa-fw"></i>
                <h3>Graph</h3>
                <p class="text_info">Erhalten Sie ausführliche Informationen über alle gesammelten Wetterdaten in aussagekräftigen Diagrammen.</p>
            </a>
            <a class="flexboxitem_main" href="map.aspx">
                <i class="icon_main fas fa-map fa-fw"></i>
                <h3>Map</h3>
                <p class="text_info">Erhalten Sie ausführliche Informationen über alle gesammelten Wetterdaten in einer großen Kartenübersicht.</p>
            </a>
            <a class="flexboxitem_main" href="table.aspx">
                <i class="icon_main fas fa-table fa-fw"></i>
                <h3>Table</h3>
                <p class="text_info">Erhalten Sie ausführliche Informationen über alle gesammelten Wetterdaten in Tabellenform.</p>
            </a>
        </div>
    </div>
</asp:Content>
