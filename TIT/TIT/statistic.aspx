<%@ Page Title="Statistic" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="statistic.aspx.cs" Inherits="TIT.statistic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Style/style_statistic.css" rel="stylesheet" />
    <div class="container-statistic">




        <div class="getSelectedOptions">

           <%-- here --%>
        <asp:Button ID="getDataButton" Text="GetData" OnClick="getDataButton_Click" runat="server" />

    
        
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



        <br />
        <br />
        <br />



        <div class="container-statistic-module"> </div>

        <div class="container-statistic-module-header">
            <asp:Button ID="Button1" runat="server" Text="Modul" />
        </div>
        <div class="container-statistic-module-body">

            <div class="container-statistic-module-body-left">
                <div class="container-statistic-module-body-left-modulname">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </div>
                <div class="container-statistic-module-body-left-dropdowns">
                    <div class="container-statistic-module-body-left-dropdown">
                        <asp:Label ID="Label1" runat="server" Text="Region"></asp:Label>
                        <%--<asp:DropDownList ID="dropdown_country" OnSelectedIndexChanged="dropdown_country_SelectedIndexChanged" AutoPostBack="true" CssClass="dropdown" runat="server"></asp:DropDownList>--%>
                    </div>
                    <div>
                        <asp:Label ID="Label2" runat="server" Text="Station"></asp:Label>
                        <asp:DropDownList ID="dropdown_station" CssClass="dropdown" runat="server"></asp:DropDownList>
                    </div>
                    <div class="container-statistic-module-body-left-dropdown">
                        <asp:Label ID="Label3" runat="server" Text="Interval"></asp:Label>
                        <asp:DropDownList ID="dropdown_sort" CssClass="dropdown" runat="server"></asp:DropDownList>
                    </div>
                    <div class="container-statistic-module-body-left-dropdown">
                        <asp:Label ID="Label4" runat="server" Text="Order By"></asp:Label>
                        <asp:DropDownList ID="DropDownList1" CssClass="dropdown" runat="server"></asp:DropDownList>
                    </div>

                    <div class="container-statistic-module-body-left-dropdown-time">

                    <div class="container-statistic-module-body-left-dropdown-time-from">
                        <asp:Label ID="Label5" runat="server" Text="From"></asp:Label>
                        <input id="datepicker_from" type="date" runat="server" />
                    </div>
                    <div class="container-statistic-module-body-left-dropdown-time-to">
                        <asp:Label ID="Label6" runat="server" Text="To"></asp:Label>
                        <input id="datepicker_to" type="date" runat="server" />
                    </div>

                    </div>
                </div>

                
                


            <div class="container-statistic-module-body-right">
                <div class="container-statistic-module-body-left-radiobuttons">
                    <div class="container-statistic-module-body-left-radiobutton">
                       <asp:CheckBox ID="checkbox_option1" Text="Raw Temperature" runat="server"/>
                    </div>
                    <div class="container-statistic-module-body-left-radiobutton">
                       <asp:CheckBox ID="checkbox_option2" Text="Mean Temperature" runat="server" />
                    </div>
                    <div class="container-statistic-module-body-left-radiobutton">
                       <asp:CheckBox ID="checkbox_option3" Text="Median Temperature" runat="server" />
                    </div>
                    <div class="container-statistic-module-body-left-radiobutton">
                       <asp:CheckBox ID="checkbox_option4" Text="Min Temperature" runat="server" />
                    </div>
                    <div class="container-statistic-module-body-left-radiobutton">
                       <asp:CheckBox ID="checkbox_option5" Text="Max Temperature" runat="server" />
                    </div>
                    <div class="container-statistic-module-body-left-radiobutton">
                       <asp:CheckBox ID="checkbox_option6" Text="Standard Deviation" runat="server" />
                    </div>
                    <div class="container-statistic-module-body-left-radiobutton">
                       <asp:CheckBox ID="checkbox_option7" Text="Mode Temperature" runat="server" />
                    </div>
                    <div class="container-statistic-module-body-left-radiobutton">
                       <asp:CheckBox ID="checkbox_option8" Text="Range Temperature" runat="server" />
                    </div>
                </div>
                


            </div>


            
        </div>
        </div>


        
    </div>
</asp:Content>
