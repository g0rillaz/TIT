<%@ Page Title="Startseite" Language="C#" MasterPageFile="~/Start.Master" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="TIT.main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container_main">
        <div class="container_message">
            <h1>Welcome at </h1>
            <img src="Images/logo.png" class="image_logo" />
            <h1>- Temperature in Time</h1>
            <h3 class="h3_1">Please choose an option</h3>
        </div>
        <div class="flexbox_main">
            <a class="flexboxitem_main" href="statistic.aspx">
                <i class="icon_main fas fa-table fa-fw"></i>
                <h3>Statistics</h3>
                <hr />
                <p class="text_info">Erhalten Sie ausführliche Informationen über alle gesammelten Wetterdaten.</p>
            </a>
            <a class="flexboxitem_main" href="map.aspx">
                <i class="icon_main fas fa-map fa-fw"></i>
                <h3>Map</h3>
                <hr />
                <p class="text_info">Erhalten Sie eine Übersicht über alle genutzten Wetterstationen in einer großen Kartenübersicht.</p>
            </a>
            <a class="flexboxitem_main" href="info.aspx">
                <i class="icon_main fas fa-info fa-fw"></i>
                <h3>Info</h3>
                <hr />
                <p class="text_info">Erhalten Sie ausführliche Informationen über das Projekt.</p>
            </a>
        </div>
    </div>
</asp:Content>
