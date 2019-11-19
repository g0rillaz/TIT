<%@ Page Title="Table" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="table.aspx.cs" Inherits="TIT.table" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Style/style_table.css" rel="stylesheet" />
    <div class="container_table">
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
    </div>
</asp:Content>
