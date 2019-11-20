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
            list_data1.Add(new ChartData("Min", "Juni", "16.5"));
            list_data1.Add(new ChartData("Min", "Juli", "18.6"));
            list_data1.Add(new ChartData("Min", "August", "17.9"));
            list_data1.Add(new ChartData("Min", "September", "14"));
            list_data1.Add(new ChartData("Min", "Oktober", "9.6"));
            list_data1.Add(new ChartData("Min", "November", "5.2"));
            list_data1.Add(new ChartData("Min", "Dezember", "1.9"));

            List<ChartData> list_data2 = new List<ChartData>();
            list_data2.Add(new ChartData("Max", "Januar", "-0.5"));
            list_data2.Add(new ChartData("Max", "Februar", "0.4"));
            list_data2.Add(new ChartData("Max", "März", "3.5"));
            list_data2.Add(new ChartData("Max", "April", "10"));
            list_data2.Add(new ChartData("Max", "Mai", "15"));
            list_data2.Add(new ChartData("Max", "Juni", "20"));
            list_data2.Add(new ChartData("Max", "Juli", "23"));
            list_data2.Add(new ChartData("Max", "August", "21"));
            list_data2.Add(new ChartData("Max", "September", "12"));
            list_data2.Add(new ChartData("Max", "Oktober", "9"));
            list_data2.Add(new ChartData("Max", "November", "4"));
            list_data2.Add(new ChartData("Max", "Dezember", "0.8"));


            ChartArea ChartArea1 = new ChartArea();
            ChartArea1.AxisX.Interval = 1;
            ChartArea1.AxisX.IsMarginVisible = false;

            chart_main.ChartAreas.Add(ChartArea1);

            Series Series1 = new Series();
            Series1.IsValueShownAsLabel = true;
            Series1.XValueType = ChartValueType.String;
            Series1.XValueMember = "xValue";
            Series1.YValueMembers = "yValue";
            Series1.ChartType = SeriesChartType.SplineArea;
            Series1.Points.DataBind(list_data1, "xValue", "yValue", "Tooltip = Group");
            chart_main.Series.Add(Series1);


            chart_main.Series.Add("Series2");
            chart_main.Series["Series2"].ChartType = SeriesChartType.SplineArea;

            chart_main.Series["Series2"].IsValueShownAsLabel = true;
            chart_main.Series["Series2"].XValueType = ChartValueType.String;
            chart_main.Series["Series2"].XValueMember = "xValue";
            chart_main.Series["Series2"].YValueMembers = "yValue";
            chart_main.Series["Series2"].Points.DataBind(list_data2, "xValue", "yValue", "Tooltip = Group");
          

        }

        private class ChartData
        {
            public string group { get; set; }
            public string xValue { get; set; }
            public string yValue { get; set; }

            public ChartData()
            {

            }

            public ChartData(string group,string xValue, string yValue)
            {
                this.group = group;
                this.xValue = xValue;
                this.yValue = yValue;
            }
        }
    }
}