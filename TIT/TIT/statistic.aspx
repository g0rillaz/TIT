﻿<%@ Page Title="Statistic" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="statistic.aspx.cs" Inherits="TIT.statistic" %>
<%@ Register Src="~/ModuleComponent.ascx" TagName="WebControl" TagPrefix="TWebControl"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Style/style_statistic.css" rel="stylesheet" />
    <div ID="test" class="container-statistic">



        <asp:Button ID="createNewModule" Text="+ Module" OnClick="createNewModule_Click"  runat="server"  />
        <asp:PlaceHolder ID="ModulePlaceholder" runat="server"></asp:PlaceHolder>

        
        
    </div>


</asp:Content>
