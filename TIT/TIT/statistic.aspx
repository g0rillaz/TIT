<%@ Page Title="Statistic" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="statistic.aspx.cs" Inherits="TIT.statistic" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <link href="Style/style_statistic.css" rel="stylesheet" />
        <script>
            window.onload = function () {

                var chart = new CanvasJS.Chart("chartContainer", {
                    animationEnabled: true,
                    title: {
                        text: "Product Trends By Month"
                    },
                    axisY: {
                        includeZero: false
                    },
                    toolTip: {
                        shared: true
                    },
                    data: [{
                        type: "line",
                        name: "Desktops",
                        showInLegend: true,
                        dataPoints: @Html.Raw(ViewBag.DataPoints1)
            }, {
                type: "line",
                name: "Laptops",
                showInLegend: true,
                dataPoints: @Html.Raw(ViewBag.DataPoints2)
                    }, {
                type: "line",
                    name: "Mobiles",
                        showInLegend: true,
                            dataPoints: @Html.Raw(ViewBag.DataPoints3)
            }]
                });
            chart.render();

            }
        </script>
        <div class="container">
            <div class="row">
                <div class="col-sm-7"></div>
                <div class="clo-sm-2 mt-1">
                    <asp:Button class="btn btn-primary btn-outline" ID="Button1" Text="+ Modul" OnClick="getDataButton_Click" runat="server" />
                </div>
                <div class="m-3 col-sm-8 mt-5 border border-left-6">
                    <div class="input-group mt-3">
                        <div class="input-group-prepend mb-3 ml-3">
                            <asp:Button class="btn btn-outline-secondary" ID="getDataButton" Text="Modulname" OnClick="getDataButton_Click" runat="server" />
                        </div>
                        <asp:TextBox class="form-control" ID="Modulname" Text="Modulname" runat="server"></asp:TextBox>
                    </div>
                    <div class="dropdown-toggle">
                        <div class="container-fluid">
                            <div class="row mb-1">
                                <div class="col-sm">
                                    <asp:DropDownList ID="DropDownList1" OnSelectedIndexChanged="Region_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control p-3" runat="server"></asp:DropDownList>
                                    <asp:DropDownList ID="DropDownList2" CssClass="form-control p-3" runat="server"></asp:DropDownList>
                                    <br>
                                </div>
                                <div class="col-sm">
                                    <asp:DropDownList ID="Interval" CssClass="form-control p-3" runat="server"></asp:DropDownList>
                                    <asp:DropDownList ID="OrderedBy" CssClass="form-control p-3" runat="server"></asp:DropDownList>
                                </div>

                                <div class="col-sm">
                                    <div class="col-sm-4">
                                        <div class="form-check">
                                            <asp:CheckBox ID="CheckBox1" Text="RawTemperature" runat="server" />
                                            <label class="form-check-label" for="RawTemperature"></label>
                                        </div>
                                        <div class="form-check">
                                            <asp:CheckBox ID="CheckBox2" Text="MeanTemperature" runat="server" />
                                            <label class="form-check-label" for="MeanTemperature"></label>
                                        </div>
                                        <div class="form-check">
                                            <asp:CheckBox ID="CheckBox3" Text="MinTemperature" runat="server" />
                                            <label class="form-check-label" for="MinTemperature"></label>
                                        </div>
                                        <div class="form-check">
                                            <asp:CheckBox ID="CheckBox4" Text="MaxTemperature" runat="server" />
                                            <label class="form-check-label" for="MaxTemperature"></label>
                                        </div>
                                        <div class="form-check">
                                            <asp:CheckBox ID="CheckBox5" Text="StandardDeviation" runat="server" />
                                            <label class="form-check-label" for="StandardDeviation"></label>
                                        </div>
                                        <div class="form-check">
                                            <asp:CheckBox ID="CheckBox6" Text="ModeTemperature" runat="server" />
                                            <label class="form-check-label" for="ModeTemperature"></label>
                                        </div>
                                        <div class="form-check">
                                            <asp:CheckBox ID="CheckBox7" Text="RangeTemperature" runat="server" />
                                            <label class="form-check-label" for="RangeTemperature"></label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <asp:TextBox textmode="Date" Class="form-control" ID="FromDate" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-sm-4">
                                    <asp:TextBox textmode="Date" Class="form-control" ID="TextBox1" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-sm-2">
                                </div>
                                <div class="col-sm">
                                    <asp:Button class="btn btn-primary btn-outline" ID="Button2" Text="Get Data" OnClick="getDataButton_Click" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="m-3 col-sm-8 border mt-2">

                    <i class="fa fa-arrow-down" aria-hidden="true"></i>
                    <asp:Table id="Table1" runat="server" CellPadding="10" GridLines="Both" HorizontalAlign="Center" class="table table-sm table-dark mt-2">
                        <asp:TableHeaderRow id="Table1HeaderRow" runat="server">
                            <asp:TableHeaderCell Scope="Column" Text="ID" />
                            <asp:TableHeaderCell Scope="Column" Text="Region" />
                            <asp:TableHeaderCell Scope="Column" Text="Station" />
                            <asp:TableHeaderCell Scope="Column" Text="Date Time" />
                            <asp:TableHeaderCell Scope="Column" Text="Mean Temperatur" />
                            <asp:TableHeaderCell Scope="Column" Text="Median Temperatur" /></asp:TableHeaderRow>
                        <asp:TableRow>
                            <asp:TableCell>TestID</asp:TableCell>
                            <asp:TableCell>Test Woher</asp:TableCell>
                            <asp:TableCell>Station ID</asp:TableCell>
                            <asp:TableCell>Date</asp:TableCell>
                            <asp:TableCell>Temp</asp:TableCell>
                            <asp:TableCell>Woher</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow></asp:TableRow>
                    </asp:Table>
                </div>
                <div class="m-3 col-sm-8 border mt-2">
                    <i class="fa fa-arrow-down" aria-hidden="true"></i>
                    <div id="chartContainer" style="height: 370px; width: 100%;"></div>

                    <%--  https://canvasjs.com/asp-net-mvc-charts/ --%>


                     
                    <script src="https://canvasjs.com/assets/script/canvasjs.min.js"></script>

                </div>
            </div>
        </DIV>
    </asp:Content>