<%@ Page Title="Statistic" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="statistic.aspx.cs" Inherits="TIT.statistic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Style/style_statistic.css" rel="stylesheet" />
    <div class="container-statistic">
        <div class="container">
            <div class="row">
                <div class="clo-sm-2 mt-1">
                    <asp:Button class="btn btn-primary btn-outline" ID="createNewModule" Text="+ Module" OnClick="createNewModule_Click"  runat="server"/>
                </div>
            </div>
        </div>
        <div class="module-container">
            <asp:PlaceHolder ID="ModulePlaceholder"  runat="server"></asp:PlaceHolder>
        </div>
    </div>


</asp:Content>