<%@ Page Title="Statistic" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="statistic.aspx.cs" Inherits="TIT.statistic" %>
<%@ Register Src="~/ModuleComponent.ascx" TagName="WebControl" TagPrefix="TWebControl"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Style/style_statistic.css" rel="stylesheet" />
    <div ID="test" class="container-statistic">

        <TWebControl:WebControl ID="Header" runat="server" MinValue="100" />


        <div class="getSelectedOptions">
        <asp:Button ID="getDataButton" Text="GetData" OnClick="getDataButton_Click" runat="server" />
        <asp:Button ID="createNewModule" Text="+ Module" OnClick="createNewModule_Click"  runat="server" />

        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        <asp:PlaceHolder ID="MyPlaceholder" runat="server"></asp:PlaceHolder>
        <div id="dwd" runat="server"></div>
        <asp:TextBox  ID="Modulname" Text="Modulname(Modul1)" runat="server"></asp:TextBox>
        <asp:TextBox  textmode="Date" ID="FromDate"  runat="server"></asp:TextBox>
        <asp:TextBox  textmode="Date" ID="ToDate" runat="server"></asp:TextBox>

        
        <asp:DropDownList ID="Region"  OnSelectedIndexChanged="Region_SelectedIndexChanged" AutoPostBack="true" CssClass="" runat="server"></asp:DropDownList>
        <asp:DropDownList ID="Station" CssClass="" runat="server"></asp:DropDownList>
        <asp:DropDownList ID="Interval" CssClass="" runat="server"></asp:DropDownList>
        <asp:DropDownList ID="OrderedBy" CssClass="" runat="server"></asp:DropDownList>


        <asp:CheckBox ID="RawTemperature" Text="RawTemperature" runat="server" />
        <asp:CheckBox ID="MeanTemperature" Text="MeanTemperature" runat="server" />
        <asp:CheckBox ID="MedianTemperature" Text="MedianTemperature" runat="server" />
        <asp:CheckBox ID="MinTemperature" Text="MinTemperature" runat="server" />
        <asp:CheckBox ID="MaxTemperature" Text="MaxTemperature" runat="server" />
        <asp:CheckBox ID="StandardDeviation" Text="StandardDeviation" runat="server" />
        <asp:CheckBox ID="ModeTemperature" Text="ModeTemperature" runat="server" />
        <asp:CheckBox ID="RangeTemperature" Text="RangeTemperature" runat="server" />


            <br />


            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            <asp:GridView ID="gridview_main" runat="server" AutoGenerateColumns="False" CssClass="gridview_main">
            <Columns>
                <asp:TemplateField HeaderText="ID" ItemStyle-CssClass="" HeaderStyle-CssClass="">
                    <ItemTemplate>
                        <asp:Label ID="gridview_ID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name" ItemStyle-CssClass="" HeaderStyle-CssClass="">
                    <ItemTemplate>
                        <asp:Label ID="gridview_Name" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="IsoCode" ItemStyle-CssClass="" HeaderStyle-CssClass="">
                    <ItemTemplate>
                        <asp:Label ID="gridview_IsoCode" runat="server" Text='<%# Eval("IsoCode") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </div>


</asp:Content>
