<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ModuleComponent.ascx.cs" Inherits="TIT.ModuleComponent" %>

<script runat="server">
	  public int MinValue = 0;
	</script>
<div class="getSelectedOptions">
            
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


            <%--<asp:GridView ID="GridView1" runat="server"></asp:GridView>
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
        </asp:GridView>--%>
    </div>