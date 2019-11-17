<%@ Page Title="Table" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="table.aspx.cs" Inherits="TIT.table" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container_table">
        <asp:DropDownList ID="dropdown_country" OnSelectedIndexChanged="dropdown_country_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
        <asp:DropDownList ID="dropdown_station" runat="server"></asp:DropDownList>
        <input id="datepicker_from" type="date" runat="server" />
        <input id="datepicker_to" type="date" runat="server" />
        <asp:Button ID="button_getData" Text="Search" OnClick="button_getData_Click" runat="server" />

        <asp:GridView ID="gridview_main" runat="server">
        </asp:GridView>
    </div>
</asp:Content>
