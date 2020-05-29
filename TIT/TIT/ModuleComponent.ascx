<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ModuleComponent.ascx.cs" Inherits="TIT.ModuleComponent" %>

<script runat="server">
    public int MinValue = 0;
</script>
<div class="module-component">

    <link href="Style/style_statistic.css" rel="stylesheet" />

    <div class="container">
        <div class="row">
            <div class="col-sm-7"></div>
            <asp:PlaceHolder ID="ModulePlaceholder" runat="server"></asp:PlaceHolder>
            <div class="m-3 col-sm-8 mt-5 border border-left-6">
                <div class="input-group mt-3">
                    <%--<asp:TextBox class="form-control" ID="Modulname" Text="Modulname" runat="server"></asp:TextBox>--%>
                </div>
                <div>
                    <div class="container-fluid">
                        <div class="row mb-1">
                            <div class="col-sm">
<%--                           <asp:DropDownList ID="Source" CssClass="" runat="server">
                                    <asp:ListItem Text="Meteo" Value="METEO" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="NOAA" Value="NOAA"></asp:ListItem>
                                </asp:DropDownList>--%>
                                <asp:DropDownList ID="Region" CssClass="" OnSelectedIndexChanged="Region_SelectedIndexChanged" AutoPostBack="true" runat="server">
                                </asp:DropDownList>
                                <asp:DropDownList ID="Station" CssClass="" runat="server">
                                </asp:DropDownList>
                                <br>
                            </div>
                            <div class="col-sm">
                                <asp:DropDownList ID="Interval" CssClass="" runat="server">
                                    <asp:ListItem Text="Daily" Value="d"></asp:ListItem>
                                    <asp:ListItem Text="Weekly" Value="w"></asp:ListItem>
                                    <asp:ListItem Text="Monthly" Value="m"></asp:ListItem>
                                    <asp:ListItem Text="Yearly" Value="y" Selected="True"></asp:ListItem>
                                </asp:DropDownList>
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
                            </div>

                            <div class="col-sm">
                                <div class="col-sm-4">
                                    <div class="form-check">
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
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-4">

                                <asp:TextBox TextMode="Date" Class="form-control" ID="FromDate" runat="server"></asp:TextBox>

                            </div>
                            <div class="col-sm-4">
                                <asp:TextBox TextMode="Date" Class="form-control" ID="ToDate" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-2">
                            </div>
                            <div class="col-sm">
                                <%--<asp:Button class="btn btn-primary btn-outline" ID="removeModule" Text="Remove Module" OnClick="removeModule_Click" runat="server" />--%>
                               
                                <asp:Button class="btn btn-primary btn-outline" ID="Button2" Text="Get Data" OnClick="getDataButton_Click" runat="server" />
                                <asp:Button class="btn btn-primary btn-outline" ID="button_order" Text="Order" OnClick="button_order_Click" runat="server" />
                          
                                </div>
                        </div>
                    </div>
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
        <div class="m-3 col-sm-8 border mt-2">
            <%--<i class="fa fa-arrow-down" aria-hidden="true"></i>--%>
            <div id="chartContainer" style="height: 370px; width: 100%;"></div>

            <script src="https://canvasjs.com/assets/script/canvasjs.min.js"></script>
            <script type="text/javascript">
                var timeTempData = new Array();


                function getData() {
                    //Get The Control ID for the dropdown                                
                    //Check if the object is not null
                    DataPoints: [{ y: 6, label: "Apple" },
                    { y: 4, label: "Mango" },
                    { y: 5, label: "Orange" },];
                    window.alert("Das Array aus dem Backend " + Skills);
                    windows.alert(Skills[0]);
                    alert("Mein Debugger");


                    var cookie = getCookie('WeatherData');

                    if (timeTempData != null) {
                        for (var i = 0; i < timeTempData.length; i++) {
                            // Create and Element Object of type "option"
                            // var opt = document.createElement("option");

                            //Add the option element to the select item


                            timeTempData.add(Skills[i]);
                            //Reading Element From Array
                            //timeTempData = ;
                        }
                        window.alert(timeTempData)


                    }

                }


                var v = $('#mydate').val();

                window.onload = function () {
                    var chart = new CanvasJS.Chart("chartContainer", {
                        title: {
                            text: "Temperaturverlauf"
                        },
                        axisX: {
                            title: "Zeit"
                        },

                        axisY: {
                            title: "Temperatur C"
                        },

                        data: [{
                            type: "line",
                            dataPoints: [{ y: 6, label: "Apple" },
                            { y: 4, label: "Mango" },
                            { y: 5, label: "Orange" },]
                        }]
                    })



                        ;
                    chart.render();
                }
            </script>


            <script src="https://canvasjs.com/assets/script/canvasjs.min.js"></script>

        </div>
    </div>
</div>
