<%@ Page Title="Table" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="table.aspx.cs" Inherits="TIT.table" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Style/style_table.css" rel="stylesheet" />
<%--    <div class="container_table">


        <div class="container_options">
            <div class="container_dropdown">
                <p>Country:</p>
                <asp:DropDownList ID="dropdown_country" OnSelectedIndexChanged="dropdown_country_SelectedIndexChanged" AutoPostBack="true" CssClass="dropdown" runat="server"></asp:DropDownList>
            </div>
            <div class="container_dropdown">
                <p>Station:</p>
                <asp:DropDownList ID="dropdown_station" CssClass="dropdown" runat="server"></asp:DropDownList>
            </div>
            <div class="container_dropdown">
                <p>Sort by:</p>
                <asp:DropDownList ID="dropdown_sort" CssClass="dropdown" runat="server"></asp:DropDownList>
            </div>
            <div class="container_time">
                <div class="container_datepicker">
                    <p>From:</p>
                    <input id="datepicker_from" type="date" runat="server" />
                </div>
                <div class="container_datepicker">
                    <p>To:</p>
                    <input id="datepicker_to" type="date" runat="server" />
                </div>
                <asp:CheckBox ID="checkbox_option1" Text="Option1" runat="server" />
                <asp:CheckBox ID="checkbox_option2" Text="Option2" runat="server" />
                <asp:CheckBox ID="checkbox_option3" Text="Option3" runat="server" />
                <asp:Button ID="button_getData" Text="Search" OnClick="button_getData_Click" runat="server" />
            </div>
        </div>

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
    </div>--%>


    <div class="getSelectedOptions">
        <asp:Button ID="getDataButton" Text="GetData" OnClick="getDataButton_Click" runat="server" />
    
        
        <asp:TextBox  ID="Modulname" Text="Modulname(Modul1)" runat="server"></asp:TextBox>
        <asp:Calendar ID="FromDate" runat="server"></asp:Calendar>
        <asp:Calendar ID="ToDate" runat="server"></asp:Calendar>
        
        <asp:DropDownList ID="Region" CssClass="" runat="server"></asp:DropDownList>
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


    </div>
    
</asp:Content>
