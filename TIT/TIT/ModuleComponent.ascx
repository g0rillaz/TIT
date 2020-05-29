<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ModuleComponent.ascx.cs" Inherits="TIT.ModuleComponent" %>

<script runat="server">
    public int MinValue = 0;
</script>
<div class="module-component">

    <link href="Style/style_statistic.css" rel="stylesheet" />

    <div class="container">
        <div class="row">
            <%--<div class="col-sm-7"></div>--%>
            <asp:PlaceHolder ID="ModulePlaceholder" runat="server"></asp:PlaceHolder>
            <div class="m-3 col-sm-12 mt-5 border border-left-6">
                <div class="input-group mt-3">
                    <%--<asp:TextBox class="form-control" ID="Modulname" Text="Modulname" runat="server"></asp:TextBox>--%>
                </div>
                <div>
                    <div class="container-fluid  ">
                        <div class="row m-1 p-1">
                            <div class="col-sm-6">
                                <%--                           <asp:DropDownList ID="Source" CssClass="" runat="server">
                                    <asp:ListItem Text="Meteo" Value="METEO" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="NOAA" Value="NOAA"></asp:ListItem>
                                </asp:DropDownList>--%>
                                <asp:DropDownList ID="Region" CssClass="" OnSelectedIndexChanged="Region_SelectedIndexChanged" AutoPostBack="true" runat="server">
                                </asp:DropDownList>
                                <asp:DropDownList ID="Station" CssClass="" runat="server">
                                </asp:DropDownList>
                                <asp:DropDownList ID="Interval" CssClass="" runat="server">
                                    <asp:ListItem Text="Daily" Value="d"></asp:ListItem>
                                    <asp:ListItem Text="Weekly" Value="w"></asp:ListItem>
                                    <asp:ListItem Text="Monthly" Value="m"></asp:ListItem>
                                    <asp:ListItem Text="Yearly" Value="y" Selected="True"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-6">
                                
                                <asp:DropDownList ID="OrderedBy" CssClass="" runat="server">
                                    <asp:ListItem Text="Date" Value="date" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Country" Value="country"></asp:ListItem>
                                    <asp:ListItem Text="Station" Value="st_name"></asp:ListItem>
                                    <asp:ListItem Text="Mean" Value="mean"></asp:ListItem>
                                    <asp:ListItem Text="Median" Value="median"></asp:ListItem>
                                    <asp:ListItem Text="Min" Value="min"></asp:ListItem>
                                    <asp:ListItem Text="Max" Value="max"></asp:ListItem>
                                    <asp:ListItem Text="Deviation" Value="s_dev"></asp:ListItem>
                                    <asp:ListItem Text="Range" Value="range"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="Direction" CssClass="" runat="server">
                                    <asp:ListItem Text="Aufsteigend" Value="auf" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Absteigend" Value="ab"></asp:ListItem>
                                </asp:DropDownList>                                
                                <asp:Button class="btn btn-primary btn-outline" ID="button_order" Text="Order" OnClick="button_order_Click" runat="server" />
                            </div>
                            </div>
                                <div class="row">
                                   
                                    <div class="col-sm-4">
<%--                                        <div class="form-check">
                                            <asp:CheckBox ID="MeanTemperature" Text="MeanTemperature" runat="server" />
                                            <label class="form-check-label" for="MeanTemperature"></label>
                                        </div>
                                        <div class="form-check">
                                            <asp:CheckBox ID="MedianTemperature" Text="MedianTemperature" runat="server" />
                                            <label class="form-check-label" for="MedianTemperature"></label>
                                        </div>
                                        <div class="form-check">
                                            <asp:CheckBox ID="MinTemperature" Text="MinTemperature" runat="server" />
                                            <label class="form-check-label" for="MinTemperature"></label>
                                        </div>
                                        <div class="form-check">
                                            <asp:CheckBox ID="MaxTemperature" Text="MaxTemperature" runat="server" />
                                            <label class="form-check-label" for="MaxTemperature"></label>
                                        </div>
                                        <div class="form-check">
                                            <asp:CheckBox ID="StandardDeviation" Text="StandardDeviation" runat="server" />
                                            <label class="form-check-label" for="StandardDeviation"></label>
                                        </div>
                                        <div class="form-check">
                                            <asp:CheckBox ID="RangeTemperature" Text="RangeTemperature" runat="server" />
                                            <label class="form-check-label" for="RangeTemperature"></label>
                                        </div>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-4">             
                                <asp:TextBox TextMode="Date" Class="form-control" ID="FromDate" runat="server" Text="From date"></asp:TextBox>                            
                                <asp:TextBox TextMode="Date" Class="form-control" ID="ToDate" runat="server" Text="To date"></asp:TextBox>
                            </div>
                            <div class="col-sm-2">
                                <asp:Button class="btn btn-primary btn-outline" ID="Button2" Text="Get Data" OnClick="getDataButton_Click" runat="server" />   
                            </div>
                            <div class="col-sm">
                                <%--<asp:Button class="btn btn-primary btn-outline" ID="removeModule" Text="Remove Module" OnClick="removeModule_Click" runat="server" />--%>                                                             
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    <div class="row">
        <div class="m-3 col-sm-12 mt-3 border border-left-6">
            <asp:GridView ID="gridview_main" runat="server" AutoGenerateColumns="False" CssClass="gridview_main">
                <Columns>
                    <asp:TemplateField HeaderText="ID" ItemStyle-CssClass="" HeaderStyle-CssClass="">
                        <ItemTemplate>
                            <asp:Label ID="gridview_ID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name" ItemStyle-CssClass="" HeaderStyle-CssClass="">
                        <ItemTemplate>
                            <asp:Label ID="gridview_CountryName" runat="server" Text='<%# Eval("CountryName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="StationName" ItemStyle-CssClass="" HeaderStyle-CssClass="">
                        <ItemTemplate>
                            <asp:Label ID="gridview_StationName" runat="server" Text='<%# Eval("StationName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date" ItemStyle-CssClass="" HeaderStyle-CssClass="">
                        <ItemTemplate>
                            <asp:Label ID="gridview_Date" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mean" ItemStyle-CssClass="" HeaderStyle-CssClass="">
                        <ItemTemplate>
                            <asp:Label ID="gridview_Mean" runat="server" Text='<%# Eval("Mean") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Median" ItemStyle-CssClass="" HeaderStyle-CssClass="">
                        <ItemTemplate>
                            <asp:Label ID="gridview_Median" runat="server" Text='<%# Eval("Median") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Min" ItemStyle-CssClass="" HeaderStyle-CssClass="">
                        <ItemTemplate>
                            <asp:Label ID="gridview_Min" runat="server" Text='<%# Eval("Min") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Max" ItemStyle-CssClass="" HeaderStyle-CssClass="">
                        <ItemTemplate>
                            <asp:Label ID="gridview_Max" runat="server" Text='<%# Eval("Max") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Deviation" ItemStyle-CssClass="" HeaderStyle-CssClass="">
                        <ItemTemplate>
                            <asp:Label ID="gridview_Deviation" runat="server" Text='<%# Eval("Deviation") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Range" ItemStyle-CssClass="" HeaderStyle-CssClass="">
                        <ItemTemplate>
                            <asp:Label ID="gridview_Range" runat="server" Text='<%# Eval("Range") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>        
    </div>
            
        </div>
            <div class="row">   
                <div class="m-3 col-sm-12 border mt-2">
            
                <asp:Chart ID="Chart_WeatherData" style="margin-bottom: 10vh; width: 40vw; height: 100%" Height="500px" Width="700px" runat="server">
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
        
            </div>
            
        </div>
