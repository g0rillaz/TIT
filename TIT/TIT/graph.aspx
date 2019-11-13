<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="graph.aspx.cs" Inherits="TIT.graph" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Chart runat="server" ID="ctl00" DataSourceID="SqlDataSource1">
        <Series>
            <asp:Series Name="Series1" ChartType="Point" XValueMember="X" YValueMembers="Y"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:IN18ConnectionString %>" SelectCommand="SELECT [X], [Y] FROM [diagramm]"></asp:SqlDataSource>
</asp:Content>

