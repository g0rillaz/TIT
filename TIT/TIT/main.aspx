<%@ Page Title="Startseite" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="TIT.main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">--%>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.11.2/css/all.css">
    <link rel="stylesheet" href="/Style/style_main.css">

    <div class="container_main">
        <div class="container_message">
            <h1>Willkommen bei TiT - Temperature in Time</h1>
            <h3>Bitte wähle eine Funktion aus</h3>
            <p>Ein Projekt der IN18</p>
        </div>
        <ul class="list_main">
            <li class="listitem_main"><a href="graph.aspx"><i class="fas fa-chart-line"></i></a></li>
            <li class="listitem_main"><a href="map.aspx"><i class="fa fa-map"></i></a></li>
            <li class="listitem_main"><a href="graph.aspx"><i class="fa fa-car"></i></a></li>
            <li class="listitem_main"><a href="graph.aspx"><i class="fa fa-car"></i></a></li>
            <li class="listitem_main"><a href="graph.aspx"><i class="fa fa-car"></i></a></li>
        </ul>
    </div>

</asp:Content>
