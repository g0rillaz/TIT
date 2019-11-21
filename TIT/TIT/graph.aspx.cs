using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace TIT
{
    public partial class graph : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadChart();
        }

        private void loadChart()
        {


            // Erstellen einer Liste und füllen dieser
            List<ChartData> list_data1 = new List<ChartData>();

            list_data1.Add(new ChartData("Min", "Januar", "{0.8, 10}"));
            list_data1.Add(new ChartData("Min", "Februar", "1.2"));
            list_data1.Add(new ChartData("Min", "März", "4.5"));
            list_data1.Add(new ChartData("Min", "April", "9.1"));
            list_data1.Add(new ChartData("Min", "Mai", "13.4"));
            list_data1.Add(new ChartData("Min", "Juni", "15"));
            list_data1.Add(new ChartData("Min", "Juli", "19"));
            list_data1.Add(new ChartData("Min", "August", "17.9"));
            list_data1.Add(new ChartData("Min", "September", "14"));
            list_data1.Add(new ChartData("Min", "Oktober", "9.6"));
            list_data1.Add(new ChartData("Min", "November", "5.2"));
            list_data1.Add(new ChartData("Min", "Dezember", "1.9"));

            List<ChartData> list_data2 = new List<ChartData>();
            list_data2.Add(new ChartData("Max", "Januar", "-0.5"));
            list_data2.Add(new ChartData("Max", "Februar", "0.4"));
            list_data2.Add(new ChartData("Max", "März", "3.5"));
            list_data2.Add(new ChartData("Max", "April", "8"));
            list_data2.Add(new ChartData("Max", "Mai", "13"));
            list_data2.Add(new ChartData("Max", "Juni", "18"));
            list_data2.Add(new ChartData("Max", "Juli", "23"));
            list_data2.Add(new ChartData("Max", "August", "15"));
            list_data2.Add(new ChartData("Max", "September", "12"));
            list_data2.Add(new ChartData("Max", "Oktober", "9"));
            list_data2.Add(new ChartData("Max", "November", "4"));
            list_data2.Add(new ChartData("Max", "Dezember", "0.8"));


            chart_main.Legends.Add("Legend1");
            chart_main.Legends["Legend1"].LegendStyle = LegendStyle.Table;
            chart_main.Legends["Legend1"].TableStyle = LegendTableStyle.Wide;
            chart_main.Legends["Legend1"].Docking = Docking.Bottom;
            

            ChartArea ChartArea1 = new ChartArea();

            ChartArea1.AxisX.Title = "Monat";
            ChartArea1.AxisX.Interval = 1;
            ChartArea1.AxisX.IsMarginVisible = false;
            ChartArea1.AxisX.TitleAlignment = System.Drawing.StringAlignment.Center;
            ChartArea1.AxisX.TextOrientation = TextOrientation.Auto;


            ChartArea1.AxisY.Title = "Temperatur";
            ChartArea1.AxisY.Interval = 5;
            ChartArea1.AxisY.IsMarginVisible = false;
            ChartArea1.AxisY.TitleAlignment = System.Drawing.StringAlignment.Center;
            ChartArea1.AxisY.TextOrientation = TextOrientation.Auto;
            ChartArea1.AxisY.MajorTickMark.Enabled = true;
            ChartArea1.AxisY.MajorTickMark.Interval = 5;
            ChartArea1.AxisY.MajorTickMark.IntervalType = DateTimeIntervalType.Number;
            ChartArea1.AxisY.MajorTickMark.Size = 1;
            ChartArea1.AxisY.MajorTickMark.TickMarkStyle = TickMarkStyle.OutsideArea;
            ChartArea1.AxisY.MajorTickMark.IntervalOffsetType = DateTimeIntervalType.Number;
            ChartArea1.AxisY.MajorTickMark.IntervalOffset = 5;


            chart_main.ChartAreas.Add(ChartArea1);

            chart_main.Series.Add(createSeries(list_data1, "Series1"));
            chart_main.Series.Add(createSeries(list_data2, "Series2"));

        }

        private Series createSeries(List<ChartData> list_data, string SeriesName)
        {
            Series series = new Series();
            series.Name = SeriesName;
            series.IsValueShownAsLabel = true;
            series.XValueType = ChartValueType.String;
            series.XValueMember = "xValue";
            series.YValueMembers = "yValue";
            series.ChartType = SeriesChartType.SplineArea;
            series.Points.DataBind(list_data, "xValue", "yValue", "Tooltip = Group");

            return series;
        }

    }

    class ChartData
    {
        public string group { get; set; }
        public string xValue { get; set; }
        public string yValue { get; set; }

        public ChartData()
        {

        }

        public ChartData(string group, string xValue, string yValue)
        {
            this.group = group;
            this.xValue = xValue;
            this.yValue = yValue;
        }
    }
}