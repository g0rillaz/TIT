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
            List<WeatherData> data = new List<WeatherData>();



            double[] yValues = { 15, 60, 12, 13};
            string[] xValues = { "September", "October", "November", "December" };




            chart_main.Series.Add("Default1");
            chart_main.Series.Add("Default2");
            chart_main.Series.Add("Default3");
            chart_main.Series.Add("Default4");
            chart_main.Series.Add("Default5");

            chart_main.ChartAreas.Add("ChartArea1");
            chart_main.ChartAreas.Add("ChartArea2");

            chart_main.Series[0].ChartArea = "ChartArea1";
            chart_main.Series[0].ChartType = SeriesChartType.SplineArea;

            chart_main.Series[1].ChartArea = "ChartArea2";
            chart_main.Series[1].ChartType = SeriesChartType.Line;

            chart_main.Series["Default1"].Points.DataBindXY(xValues, yValues);
            chart_main.Series["Default2"].Points.DataBindXY(xValues, yValues);
        }

        private class WeatherData
        {

        }
    }
}